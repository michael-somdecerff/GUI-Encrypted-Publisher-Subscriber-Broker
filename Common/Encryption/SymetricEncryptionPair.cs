using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Encryption {
    public class SymetricEncryptionPair {
        [JsonProperty]
        public byte[] SymetricKey { get; private set; }

        [JsonProperty]
        public byte[] InitVector { get; private set; }

        [JsonConstructor]
        public SymetricEncryptionPair(byte[] key, byte[] iv) {
            if (key == null)
                throw new ArgumentNullException("Key argument is null");
            if (iv == null)
                throw new ArgumentNullException("Iv argument is null");

            SymetricKey = key;
            InitVector = iv;
        }
    }
}
