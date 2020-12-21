using System;
using System.Security.Cryptography;

namespace Common.Encryption {
    public static class SymetricKeyEncryption {
        private static Aes _aes = Aes.Create();
        public static byte[] GenerateSymetricKey() {
            _aes.GenerateKey();
            return _aes.Key;
        }

        public static string Encode(string str, byte[] key) {
            throw new NotImplementedException();
        }

        public static string Decode(string str, byte[] key) {
            throw new NotImplementedException();
        }
    }
}
