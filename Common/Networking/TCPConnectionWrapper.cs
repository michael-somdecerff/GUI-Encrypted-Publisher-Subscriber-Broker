using System;
using System.Net.Sockets;

namespace Common.Networking {
    public abstract class TCPConnectionWrapper : IDisposable {
        private bool _isDisposed = false;

        private NetworkStream _connectionStream;
        private byte[] _symetricKey;

        public TCPConnectionWrapper(NetworkStream stream, byte[] symetricKey) {
            if(stream == null || symetricKey == null)
                throw new ArgumentNullException();

            _connectionStream = stream;
            _symetricKey = symetricKey;
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
