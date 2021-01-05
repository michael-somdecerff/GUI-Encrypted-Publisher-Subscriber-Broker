using Common.Encryption;
using System;

namespace DevelopmentConsole {
    internal class Program {
        private static void Main(string[] args) {
            string str = "This is an important string";
            PublicPrivateEncryptionPair pair = PublicPrivateEncryption.GenerateEncryptionPair();
            Console.WriteLine(str);

        }
    }
}
