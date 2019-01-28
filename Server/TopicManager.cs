using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class TopicManager
    {
        private List<Topic> topicList;
        Mutex mutex;

        public TopicManager()
        {
            topicList = new List<Topic>();
            mutex = new Mutex();
        }

        public void AddTopic(string name)
        {
            Topic t = new Topic(name);
            mutex.WaitOne();
            topicList.Add(t);
            Thread topicThread = new Thread(new ThreadStart(() => startTopic(t)));
            topicThread.Start();
            mutex.ReleaseMutex();
        }

        /// <summary>
        /// This function starts a topic server. It waits client to connects to it, wait their username
        /// and then create a thread where they will interact with the server.
        /// </summary>
        /// <param name="topic"></param>
        public void startTopic(Topic topic)
        {
            int port = topic.Port;
            string ipAddress = "127.0.0.1";
            Socket serverListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ipAddress), port);
            serverListener.Bind(ep);
            serverListener.Listen(100);
            Socket clientSocket = default(Socket);

            Console.WriteLine("Topic " + topic.Name + " is running");
            while (true)
            {
                clientSocket = serverListener.Accept();
                Console.WriteLine("A client wants to enter the Topic " + topic.Name);
                byte[] usernameFromClient = new byte[1024];
                int size = clientSocket.Receive(usernameFromClient);
                BinaryFormatter bf = new BinaryFormatter();
                MemoryStream fs = new MemoryStream();
                fs.Write(usernameFromClient, 0, usernameFromClient.Length);
                fs.Position = 0;
                Message o = (Message)bf.Deserialize(fs);
                Client c = new Client(o.Msg, clientSocket);
                topic.addClient(o.Msg, clientSocket);
                topic.sendMessage(c.Username + " has joind the server.");
                Thread UserThread = new Thread(new ThreadStart(() => ClientLoop(c, topic)));
                UserThread.Start();
            }
        }

        /// <summary>
        /// When a client asks the server to enter a topic, he is redirected to this function
        /// He is then in a loop where he can send message or disconnect.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="topic"></param>
        public void ClientLoop(Client client, Topic topic)
        {
            bool x = true;
            while (x)
            {
                try
                {
                    byte[] msgFromClient = new byte[1024];
                    int size = client.Socket.Receive(msgFromClient);
                    BinaryFormatter bf = new BinaryFormatter();
                    MemoryStream fs = new MemoryStream();
                    fs.Write(msgFromClient, 0, msgFromClient.Length);
                    fs.Position = 0;
                    Object o = (Object)bf.Deserialize(fs);
                    if (o is UserDisconnect)
                    {
                        o = (UserDisconnect)o;
                        topic.removeUser(((UserDisconnect)o).login);
                        Console.WriteLine(client.Username + " has been disconnected from " + topic.Name);
                        x = false;
                    }
                    else if (o is Message)
                    {
                        topic.sendMessage(client.Username, ((Message)o).Msg);
                    }
                }
                catch (SocketException)
                {
                    Console.WriteLine(client.Username + " FROM " + topic.Name + " had a connection failure.");
                    x = false;
                }
                catch (Exception)
                {
                    Console.WriteLine(client.Username + " FROM " + topic.Name + " had a connection failure.");
                    x = false;
                }
                
            }
        }

        public override string ToString()
        {
            string a = "";
            mutex.WaitOne();
            foreach(Topic t in topicList)
            {
                a += t.Name + "; " + t.Port + "\n";
            }
            mutex.ReleaseMutex();
            return a;
        }

        public List<TopicToClient> SendTopicList()
        {
            List<TopicToClient> topicToClients = new List<TopicToClient>();
            mutex.WaitOne();
            foreach(Topic topic in topicList)
            {
                topicToClients.Add(new TopicToClient(topic.Name, topic.Port));
            }
            mutex.ReleaseMutex();
            return topicToClients;
        }
    }
}
