using System.Net.Sockets;
using System.Text;

namespace Common.Extensions {
    public static class NetworkStreamExtensions {
        public static string ReadAllDataAsASCIIString(this NetworkStream networkStream, int bufferSize = 256) {
            byte[] networkReadBuffer = new byte[bufferSize];
            StringBuilder myCompleteMessage = new StringBuilder();
            int numberOfBytesRead;

            do {
                numberOfBytesRead = networkStream.Read(networkReadBuffer, 0, networkReadBuffer.Length);
                myCompleteMessage.AppendFormat("{0}", Encoding.ASCII.GetString(networkReadBuffer, 0, numberOfBytesRead));
            }
            while (networkStream.DataAvailable);

            return myCompleteMessage.ToString();
        }
    }
}
