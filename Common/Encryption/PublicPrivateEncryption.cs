using Common.Extensions;
using System.Security.Cryptography;

namespace Common.Encryption {
    public static class PublicPrivateEncryption {
        public static PublicPrivateEncryptionPair GenerateEncryptionPair() {
            RSA rsa = RSA.Create();
            return new PublicPrivateEncryptionPair(rsa.ExportParameters(false), rsa.ExportParameters(true));
        }

        public static string Encode(string str, RSAParameters publicKey) {
            RSA rsa = RSA.Create();
            rsa.ImportParameters(publicKey);

            return rsa.Encrypt(str.AsUTF8Bytes(), RSAEncryptionPadding.Pkcs1).AsUTF8String();
        }

        public static string Decode(string str, RSAParameters privateKey) {
            RSA rsa = RSA.Create();
            rsa.ImportParameters(privateKey);

            return rsa.Decrypt(str.AsUTF8Bytes(), RSAEncryptionPadding.Pkcs1).AsUTF8String();
        }
    }
}
