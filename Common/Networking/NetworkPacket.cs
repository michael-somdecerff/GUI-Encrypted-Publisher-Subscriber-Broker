using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Common.Networking {
    public enum PacketType : byte { Connect, Disconnect, ResetSymetricKey, CreateTopic, RenameTopic, 
        SendMessageTopic, DeleteTopic, SubscribeToTopic, UnsubFromTopic, /*Account related packet types*/ }
        
    public class NetworkPacket {
        [JsonProperty]
        public PacketType Type { get; private set; }
        [JsonProperty]
        public List<byte[]> Data { get; private set; }

        public NetworkPacket(PacketType type) : this(type, new List<byte[]>()) 
            { }

        [JsonConstructor]
        public NetworkPacket(PacketType type, List<byte[]> data) {
            if (data == null) {
                throw new ArgumentNullException("Packet data can't be null");
            }

            Type = type;
            Data = data;
        }

        public int PacketDataLength() { return Data.Count; }

        public static string Serialize(NetworkPacket packet) {
            return JsonConvert.SerializeObject(packet);
        }

        public static NetworkPacket Deserialize(string packet) {
            return JsonConvert.DeserializeObject<NetworkPacket>(packet);
        }
    }
}
