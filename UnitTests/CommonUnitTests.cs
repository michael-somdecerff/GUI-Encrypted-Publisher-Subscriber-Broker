using Common.Encryption;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace UnitTests {
    [TestClass]
    public class CommonUnitTests {
        [TestMethod]
        public void SymetricKeyEncryption_Encode_Decode() {
            // Setup test string
            string str = "This is a important string";

            // Generate encryption data 
            SymetricEncryptionPair pair = SymetricKeyEncryption.GenerateEncryptionPair();
            byte[] key = pair.SymetricKey;
            byte[] iv = pair.InitVector;

            // Encode and decode the string
            string encrypted = SymetricKeyEncryption.Encode(str, key, iv);
            string decrypted = SymetricKeyEncryption.Decode(encrypted, key, iv);

            // Assert
            Assert.AreEqual(str, decrypted, "Input string and decrypted output string are not the same");
        }

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
            string publicKeyJson = JsonConvert.SerializeObject(pair.PublicKey);
            RSAParameters publicKeyFromJson = JsonConvert.DeserializeObject<RSAParameters>(publicKeyJson);

            // Encode and decode the string
            byte[] encrpyted = PublicPrivateEncryption.Encode(message, publicKeyFromJson);
            string decrpyted = PublicPrivateEncryption.Decode(encrpyted, pair.PrivateKey);

            // Assert
            Assert.AreEqual(message, decrpyted, "Input string and decrypted output string are not the same");
        }
    }
}
