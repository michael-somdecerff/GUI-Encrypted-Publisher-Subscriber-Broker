using Common.Encryption;
using Common.Networking;
using System;
using System.Net.Sockets;

namespace Client.Networking {
    public class ClientTCPConnection : TCPConnectionWrapper {
        public ClientTCPConnection(NetworkStream stream, SymetricEncryptionPair encryptionPair) : base(stream, encryptionPair) 
            { }

        public override bool ResetSymetricKey() {
            throw new NotImplementedException();
        }
    }
}
