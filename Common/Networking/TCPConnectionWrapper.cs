using Common.Encryption;
using Common.Extensions;
using Newtonsoft.Json;
using System;
using System.Net.Sockets;

namespace Common.Networking {
    public class TCPConnectionWrapper : IDisposable {
        private bool _isDisposed = false;

        private readonly NetworkStream _connectionStream;
        private SymetricEncryptionPair _encryptionPair;

        public TCPConnectionWrapper(NetworkStream stream, SymetricEncryptionPair encryptionPair) {
            _connectionStream = stream ?? throw new ArgumentNullException("Stream can't be null");
            _encryptionPair = encryptionPair ?? throw new ArgumentNullException("EncryptionPair can't be null");
        }

        public void SendMessage(NetworkPacket packet) {
            if (_isDisposed) {
                throw new ObjectDisposedException("TCPConnectionWrapper");
            }

            string packetJSON = JsonConvert.SerializeObject(packet);
            string encryptedMessage = SymetricKeyEncryption.Encode(packetJSON, _encryptionPair.SymetricKey, _encryptionPair.InitVector);
            byte[] packetBytes = encryptedMessage.AsUTF8Bytes();
            _connectionStream.Write(packetBytes, 0, packetBytes.Length);
        }

        public NetworkPacket LockForPacket() {
            if (_isDisposed) {
                throw new ObjectDisposedException("TCPConnectionWrapper");
            }

            string encryptedData = _connectionStream.ReadAllDataAsUTF8String();
            string decrpytedPacketJSON = SymetricKeyEncryption.Decode(encryptedData, _encryptionPair.SymetricKey, _encryptionPair.InitVector);
            NetworkPacket packet = JsonConvert.DeserializeObject<NetworkPacket>(decrpytedPacketJSON);
            return packet;
        }

        public void SetSymetricKey(SymetricEncryptionPair pair) {
            if (_isDisposed) {
                throw new ObjectDisposedException("TCPConnectionWrapper");
            }

            _encryptionPair = pair ?? throw new ArgumentNullException("Key can't be null");
        }

        ~TCPConnectionWrapper() {
            Dispose();
        }

        public void Dispose() {
            _connectionStream?.Close();
            _isDisposed = true;
        }
    }
}
