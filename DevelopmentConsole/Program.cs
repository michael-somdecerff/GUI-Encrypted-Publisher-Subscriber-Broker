using System;
using Common.Encryption;

namespace DevelopmentConsole {
    class Program {
        static void Main(string[] args) {
            string str = "This is an important string";
            var pair = PublicPrivateEncryption.GenerateEncryptionPair();
            Console.WriteLine(str);

        }
    }
}
