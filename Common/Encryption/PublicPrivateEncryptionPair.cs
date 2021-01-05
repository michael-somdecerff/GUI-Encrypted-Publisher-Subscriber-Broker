using System.Security.Cryptography;

namespace Common.Encryption {
    public class PublicPrivateEncryptionPair {
        public RSAParameters PublicKey { get; private set; }
        public RSAParameters PrivateKey { get; private set; }

        public PublicPrivateEncryptionPair(RSAParameters publicKey, RSAParameters privateKey) {
            PublicKey = publicKey;
            PrivateKey = privateKey;
        }
    }
}
