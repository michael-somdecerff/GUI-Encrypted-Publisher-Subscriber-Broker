using Newtonsoft.Json;
using System;

namespace Common.Networking {
    public enum PacketType : byte {  }
        
    public class NetworkPacket {
        [JsonProperty]
        public PacketType Type { get; private set; }
        [JsonProperty]
        public string[] Data { get; private set; }

        public NetworkPacket(PacketType type) : this(type, new string[0]) 
            { }

        [JsonConstructor]
        public NetworkPacket(PacketType type, string[] data) {
            if (data == null) {
                throw new ArgumentNullException("Packet data can't be null");
            }

            Type = type;
            Data = data;
        }

        public int PacketDataLength() { return Data.Length; }

        public static string Serialize(NetworkPacket packet) {
            return JsonConvert.SerializeObject(packet);
        }

        public static NetworkPacket Deserialize(string packet) {
            return JsonConvert.DeserializeObject<NetworkPacket>(packet);
        }
    }
}
