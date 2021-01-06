using Common.Encryption;
using Common.Extensions;
using Common.Networking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace UnitTests {
    [TestClass]
    public class PublicPrivateEncryptionUnitTests {
        [TestMethod]
        public void PublicPrivateEncrpytion_Encode_Decode() {
            // Setup test string
            string str = "This is an important string";

            // Generate encryption daa
            PublicPrivateEncryptionPair pair = PublicPrivateEncryption.GenerateEncryptionPair();

            // Encode and decode the string
            byte[] encrypted = PublicPrivateEncryption.Encode(str, pair.PublicKey);
            string decrpyted = PublicPrivateEncryption.Decode(encrypted, pair.PrivateKey);

            // Assert
            Assert.AreEqual(str, decrpyted, "Input string and decrypted output string are not the same");
        }

        [TestMethod]
        public void PublicPrivateEncryption_JsonEncode_Decode() {
            // Setup test string
            string message = "This is an important message";

            // Generate Encryption Data
            PublicPrivateEncryptionPair pair = PublicPrivateEncryption.GenerateEncryptionPair();

            // Serialize public key into json, then into a byte[] to be send with the network packet 
            NetworkPacket packet = new NetworkPacket(PacketType.Connect, new List<byte[]>() {
                JsonConvert.SerializeObject(pair.PublicKey).AsUTF8Bytes()
            });

            // Serialize the packet into json, then into a byte[] to be sent along a stream
            string packetJson = NetworkPacket.Serialize(packet);
            byte[] packetBytes = packetJson.AsUTF8Bytes();

            // Simulate recieving the packet byte[] on the other end of a stream
            string restoredJson = packetBytes.AsUTF8String();

            // Convert the packet JSON string back into a NetworkPacket
            NetworkPacket recievedPacket = NetworkPacket.Deserialize(restoredJson);

            // Extract the public key JSON
            string publicKeyJson = recievedPacket.Data[0].AsUTF8String();

            // Restore the public key object
            RSAParameters publicKeyFromJson = JsonConvert.DeserializeObject<RSAParameters>(publicKeyJson);

            // Encode and decode the string
            byte[] encrpyted = PublicPrivateEncryption.Encode(message, publicKeyFromJson);
            string decrpyted = PublicPrivateEncryption.Decode(encrpyted, pair.PrivateKey);

            // Assert
            Assert.AreEqual(message, decrpyted, "Input string and decrypted output string are not the same");
        }
    }
}
