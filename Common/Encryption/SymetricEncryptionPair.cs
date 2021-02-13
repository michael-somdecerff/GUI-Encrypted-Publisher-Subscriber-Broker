using Newtonsoft.Json;
using System;

namespace Common.Encryption {
    public class SymetricEncryptionPair {
        [JsonProperty]
        public byte[] SymetricKey { get; private set; }

        [JsonProperty]
        public byte[] InitVector { get; private set; }

        [JsonConstructor]
        public SymetricEncryptionPair(byte[] key, byte[] iv) {
            SymetricKey = key ?? throw new ArgumentNullException("Key argument is null");
            InitVector = iv ?? throw new ArgumentNullException("Iv argument is null");
        }
    }
}
