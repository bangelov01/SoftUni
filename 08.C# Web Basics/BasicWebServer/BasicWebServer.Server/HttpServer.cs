using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BasicWebServer.Server
{
    public class HttpServer
    {
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener serverListener;

        public HttpServer(string ipAddress, int port)
        {
            this.ipAddress = IPAddress.Parse(ipAddress);
            this.port = port;

            this.serverListener = new TcpListener(this.ipAddress, this.port);
        }

        public void Start()
        {
            this.serverListener.Start();

            Console.WriteLine($"Server started on port {port}." +
                              $"\r\nListening for requests...");

            while (true)
            {
                var connection = serverListener.AcceptTcpClient();

                var networkStream = connection.GetStream();

                WriteResponse(networkStream, "Hello from the Server!");

                var requestText = this.ReadRequest(networkStream);

                Console.WriteLine(requestText);

                connection.Close();
            }
        }

        private void WriteResponse(NetworkStream networkStream, string content)
        {
            var contentLength = Encoding.UTF8.GetByteCount(content);

            var response = $@"HTTP/1.1 200 OK 
Content-Type: text/plain; charset=UTF-8 
Content-Length: {contentLength} 

{content}";

            var responseBytes = Encoding.UTF8.GetBytes(response);

            networkStream.Write(responseBytes);
        }

        private string ReadRequest(NetworkStream networkStream)
        {
            var bufferLength = 1024;
            var buffer = new byte[bufferLength];

            var totalBytes = 0;

            var requestBuilder = new StringBuilder();

            do
            {
                var bytesRead = networkStream.Read(buffer, 0, bufferLength);
                Thread.Sleep(1); //Force the loop to a halt as there can be delayed packets.
                                 //Not the best solutuon.

                totalBytes += bytesRead;

                if (totalBytes > 10 * 1024)
                {
                    throw new InvalidOperationException("Request is too large.");
                }

                requestBuilder.Append(Encoding.UTF8.GetString(buffer,0,bytesRead));

            } while (networkStream.DataAvailable);

            return requestBuilder.ToString();

        }
    }
}
