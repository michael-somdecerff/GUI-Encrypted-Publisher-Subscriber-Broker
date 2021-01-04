using System;
using System.IO;
using System.Security.Cryptography;

namespace Common.Encryption {
    public static class SymetricKeyEncryption {
        private static readonly Aes _aes = Aes.Create();

        public static SymetricEncryptionPair GenerateEncryptionPair() {
            _aes.GenerateKey();
            _aes.GenerateIV();
            return new SymetricEncryptionPair(_aes.Key, _aes.IV);
        }

        public static string Encode(string str, byte[] key, byte[] iv) {
            byte[] encryptedBytes;

            ICryptoTransform encryptor = _aes.CreateEncryptor(key, iv);
            using (MemoryStream memoryStream = new MemoryStream()) {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write)) {
                    using (StreamWriter streamWriter = new StreamWriter(cryptoStream)) {
                        streamWriter.Write(str);
                    }

                    encryptedBytes = memoryStream.ToArray();
                }
            }

            return Convert.ToBase64String(encryptedBytes);
        }

        public static string Decode(string str, byte[] key, byte[] iv) {
            byte[] buffer = Convert.FromBase64String(str);

            ICryptoTransform decryptor = _aes.CreateDecryptor(key, iv);

            using (MemoryStream memoryStream = new MemoryStream(buffer)) {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read)) {
                    using (StreamReader streamReader = new StreamReader(cryptoStream)) {
                        return streamReader.ReadToEnd();
                    }
                }
            }
        }
    }
}
