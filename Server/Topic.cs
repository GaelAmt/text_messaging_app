using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class Topic
    {
        public string Name { set; get; }
        private static int nextPort = 13005;
        private List<Client> connectedClient;
        public int Port { set; get; }
        Mutex m;

        public Topic(string name)
        {
            Name = name;
            Port = nextPort;
            nextPort ++;
            connectedClient = new List<Client>();
            m = new Mutex();
        }

        public void addClient(string name, Socket s)
        {
            m.WaitOne();
            connectedClient.Add(new Client(name, s));
            m.ReleaseMutex();
        }

        public void removeUser(string name)
        {
            m.WaitOne();
            foreach(Client client in connectedClient)
            {
                if (client.Username == name)
                {
                    connectedClient.Remove(client);
                    break;
                }
            }
            m.ReleaseMutex();
        }

        public void sendMessage(string name, string messageToClients)
        {
            string output;
            output = name + ": " + messageToClients + "\n";
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream fs = new MemoryStream();
            Message message = new Message(output);
            bf.Serialize(fs, message);
            byte[] msg = fs.ToArray();
            m.WaitOne();
            foreach(Client client in connectedClient)
            {
                client.Socket.Send(msg, 0, msg.Length, SocketFlags.None);
            }
            m.ReleaseMutex();
        }

        public void sendMessage(string messageToClients)
        {
            string output;
            output = messageToClients + "\n";
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream fs = new MemoryStream();
            Message message = new Message(output);
            bf.Serialize(fs, message);
            byte[] msg = fs.ToArray();
            m.WaitOne();
            foreach (Client client in connectedClient)
            {
                client.Socket.Send(msg, 0, msg.Length, SocketFlags.None);
            }
            m.ReleaseMutex();
        }

        public void ChangeName(string name)
        {
            Name = name;
        }
    }

    [Serializable]
    public class TopicToClient : ISerializable
    {
        public string Name { set; get; }
        public int Port { set; get; }

        public TopicToClient(string name, int port)
        {
            Name = name;
            Port = port;
        }

        public TopicToClient(SerializationInfo info, StreamingContext ctxt)
        {
            Name = (string)info.GetValue("name", typeof(string));
            Port = (int)info.GetValue("port", typeof(int));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("name", Name);
            info.AddValue("port", Port);
        }

        public override string ToString()
        {
            return Name + " (port: " + Port + ")";
        }
    }
}
