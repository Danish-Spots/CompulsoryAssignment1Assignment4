using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using CompulsoryAssignment1Assignment1;

namespace CompulsoryAssignment1Assignment4
{
    public class TCPService
    {
        private TcpClient _connectionSocket;

        public TCPService(TcpClient connection)
        {
            _connectionSocket = connection;
        }

        private List<Book> getBooks()
        {
            return BooksList.books;
        }

        private Book getBook(string isbn13)
        {
            return BooksList.books.FirstOrDefault(b => b.ISBN13 == isbn13);
        }

        private void saveBook(Book saveBook)
        {
            BooksList.books.Add(saveBook);
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
                        answer = JsonSerializer.Serialize(getBook(messageArray[1]));
                        break;
                    case "getAll":
                        answer = JsonSerializer.Serialize(getBooks());
                        break;
                    case "save":
                        saveBook(JsonSerializer.Deserialize<Book>(messageArray[1]));
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
