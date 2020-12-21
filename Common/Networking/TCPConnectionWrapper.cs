using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Common.Networking {
    public abstract class TCPConnectionWrapper : IDisposable {
        private bool _isDisposed = false;

        private NetworkStream _connectionStream;
        private byte[] _symetricKey;

        public TCPConnectionWrapper(NetworkStream stream, byte[] symetricKey) { 
            
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
