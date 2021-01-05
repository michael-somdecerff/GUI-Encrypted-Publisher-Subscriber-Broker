using Common.Encryption;
using Common.Networking;
using Common.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace UnitTests {
    [TestClass]
    public class EymetricKeyEncryptionUnitTests {
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
    }
}
