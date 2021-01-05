using System.Text;

namespace Common.Extensions {
    public static class StringExtensions {
        public static byte[] AsUTF8Bytes(this string str) {
            return Encoding.UTF8.GetBytes(str);
        }

        public static string AsUTF8String(this byte[] buffer) {
            return Encoding.UTF8.GetString(buffer);
        }
    }
}
