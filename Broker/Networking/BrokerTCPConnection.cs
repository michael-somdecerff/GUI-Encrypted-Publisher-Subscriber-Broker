using Common.Networking;
using System;
using System.Net.Sockets;

namespace Broker.Networking {
    public class BrokerTCPConnection : TCPConnectionWrapper {
        public BrokerTCPConnection(NetworkStream stream, byte[] symetricKey) : base(stream, symetricKey) { }

        public override bool ResetSymetricKey() {
            throw new NotImplementedException();
        }
    }
}
