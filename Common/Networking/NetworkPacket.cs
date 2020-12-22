using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Networking {
    public enum PacketType { Connect, Disconnect, }
        
    public class NetworkPacket {
        public PacketType Type { get; private set; }
        public string[] Data { get; private set; }

        public NetworkPacket(PacketType type, string[] data) {
            Type = type;
            Data = data;
        }

        public int PacketDataLength() { return Data.Length; }
    }
}
