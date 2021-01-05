using Common.Encryption;
using Common.Networking;
using System.Net.Sockets;

namespace Broker.Networking {
    public class BrokerTCPConnection : TCPConnectionWrapper {
        public BrokerTCPConnection(NetworkStream stream, SymetricEncryptionPair encryptionPair) : base(stream, encryptionPair) 
            { }


    }
}
