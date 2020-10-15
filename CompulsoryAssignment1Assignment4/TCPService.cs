using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace CompulsoryAssignment1Assignment4
{
    public class TCPService
    {
        private TcpClient _connectionSocket;
        private TcpListener _serverSocket;

        public TCPService(TcpClient connection)
        {
            _connectionSocket = connection;
        }

        public TCPService(ref TcpClient connection, ref TcpListener server)
        {
            _connectionSocket = connection;
            _serverSocket = server;
        }

        internal void SendReceiveData()
        {
            Stream networkStream = _connectionSocket.GetStream();
            StreamReader sr = new StreamReader(networkStream);
            StreamWriter sw = new StreamWriter(new BufferedStream(networkStream));
            sw.AutoFlush = true;

            string message = sr.ReadLine();
            string answer = "";

            while (!string.IsNullOrEmpty(message))
            {
                Console.WriteLine("Client: " + message);
                string[] messageArray = message.Split(' ');

                switch (messageArray[0])
                {
                    case "get":
                        answer = JsonSerializer.Serialize();
                        break;
                    case "getAll":
                        answer = JsonSerializer.Serialize();
                        break;
                    case "save":
                        answer = JsonSerializer.Serialize();
                        break;
                    default:
                        answer = "Request Does Not Exist";
                        break;
                }

                sw.WriteLine(answer);
                message = sr.ReadLine();
            }

            networkStream.Close();
            _connectionSocket.Close();
        }
    }
}
