using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Extensions {
    public static class StringExtensions {
        public static byte[] AsASCIIBytes(this string str) {
            return Encoding.ASCII.GetBytes(str);
        }
    }
}
