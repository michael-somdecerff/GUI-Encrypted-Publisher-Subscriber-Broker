using Common.Encryption;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            Assert.AreEqual(str, decrypted, "Input string and decrpted output string are not the same");
        }
    }
}
