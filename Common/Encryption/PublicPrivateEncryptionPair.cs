using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Encryption {
    public class PublicPrivateEncryptionPair {
        public string PublicKey { get; private set; }
        public string PrivateKey { get; private set; }

        public PublicPrivateEncryptionPair(string publicKey, string privateKey) {
            if (publicKey == null)
                throw new ArgumentNullException("publicKey can't be null");
            if (privateKey == null)
                throw new ArgumentNullException("privateKey can't be null");

            PublicKey = publicKey;
            PrivateKey = privateKey;
        }
    }
}
