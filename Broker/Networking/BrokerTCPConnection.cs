using Common.Encryption;
using Common.Networking;
using System;
using System.Net.Sockets;

namespace Broker.Networking {
    public class BrokerTCPConnection : TCPConnectionWrapper {
        public BrokerTCPConnection(NetworkStream stream, SymetricEncryptionPair encryptionPair) : base(stream, encryptionPair) 
            { }

        public override bool ResetSymetricKey() {
            throw new NotImplementedException();
        }
    }
}
