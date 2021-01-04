using System;
using Common.Encryption;

namespace DevelopmentConsole {
    class Program {
        static void Main(string[] args) {
            string str = "This is a important string";
            Console.WriteLine(str);
            var pair = SymetricKeyEncryption.GenerateEncryptionPair();
            byte[] key = pair.SymetricKey;
            byte[] iv = pair.InitVector;
            string encrypted = SymetricKeyEncryption.Encode(str, key, iv);
            Console.WriteLine(encrypted);
            string decrypted = SymetricKeyEncryption.Decode(encrypted, key, iv);
            Console.WriteLine(decrypted);
        }
    }
}
