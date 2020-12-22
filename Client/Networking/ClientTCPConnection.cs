using Common.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Client.Networking {
    public class ClientTCPConnection : TCPConnectionWrapper {
        public ClientTCPConnection(NetworkStream stream, byte[] symetricKey) : base(stream, symetricKey) {}

        public override bool ResetSymetricKey() {
            throw new NotImplementedException();
        }
    }
}
