using Common.Encryption;
using System;
using System.Net.Sockets;

namespace Common.Networking {
    public abstract class TCPConnectionWrapper : IDisposable {
        private bool _isDisposed = false;

        private NetworkStream _connectionStream;
        private SymetricEncryptionPair _encryptionPair;

        public TCPConnectionWrapper(NetworkStream stream, SymetricEncryptionPair encryptionPair) {
            if(stream == null)
                throw new ArgumentNullException("Stream can't be null");
            if (encryptionPair == null)
                throw new ArgumentNullException("EncryptionPair can't be null");

            _connectionStream = stream;
            _encryptionPair = encryptionPair;
        }

        public bool SendMessage(NetworkPacket packet) {
            throw new NotImplementedException();
        }

        public NetworkPacket YieldForPacket() {
            throw new NotImplementedException();
        }

        public abstract bool ResetSymetricKey();

        ~TCPConnectionWrapper() {
            Dispose();
        }

        public void Dispose() {
            _connectionStream?.Close();
            _isDisposed = true;
        }
    }
}
