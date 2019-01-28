using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Server;

namespace Client
{
    class UserConnection
    {
        int port;
        string ipAddress;
        Socket clientSocket;
        IPEndPoint ep;

        public UserConnection()
        {
            //We Connect with the server
            port = 13000;
            ipAddress = "127.0.0.1";
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ep = new IPEndPoint(IPAddress.Parse(ipAddress), port);
            clientSocket.Connect(ep);
        }

        public string Login(string login, string password)
        {
            //First, we serialize UserLogin
            UserLogin user = new UserLogin(login, password);
            byte[] messageToServer;
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream fs = new MemoryStream();
            bf.Serialize(fs, user);
            fs.Seek(0, SeekOrigin.Begin);
            messageToServer = fs.ToArray();

            //We then send the object to the server
            clientSocket.Send(messageToServer, 0, messageToServer.Length, SocketFlags.None);

            //We wait for a response
            byte[] msgFromServer = new byte[1024];
            int size = clientSocket.Receive(msgFromServer);

            //We then deserialize the response
            fs.Write(msgFromServer, 0, msgFromServer.Length);
            fs.Position = 0;
            Message message = (Message)bf.Deserialize(fs);

            return message.Msg;
        }

        public string Register(string login, string password)
        {
            //We serialize UserRegister
            UserRegister user = new UserRegister(login, password);
            byte[] messageToServer;
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream fs = new MemoryStream();
            bf.Serialize(fs, user);
            fs.Seek(0, SeekOrigin.Begin);
            messageToServer = fs.ToArray();

            //We send the serialized object to the server
            clientSocket.Send(messageToServer, 0, messageToServer.Length, SocketFlags.None);

            //We receive the response, deserialize and return it
            byte[] msgFromServer = new byte[1024];
            int size = clientSocket.Receive(msgFromServer);
            fs.Write(msgFromServer, 0, msgFromServer.Length);
            fs.Position = 0;
            Message message = (Message)bf.Deserialize(fs);

            return message.Msg;
        }

        public void CloseConnection()
        {
            clientSocket.Close();
        }
    }
}
