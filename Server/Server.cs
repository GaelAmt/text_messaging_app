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
    class Server
    {
        
        private static UserManager userManager;
        private static TopicManager topicManager;
        private static Mutex topicMutex;

        public Server()
        {

            //We initialize the variables
            userManager = new UserManager();
            userManager.userRetrieve();
            topicMutex = new Mutex();
            Console.WriteLine(userManager.getString());
            topicManager = new TopicManager();

            //We add some topic
            //We might use a database in the future to save and retrieve the topic
            topicManager.AddTopic("General Topic");
            topicManager.AddTopic("New members");
            topicManager.AddTopic("We talk about science here");
            Console.WriteLine(topicManager);
        }

        /// <summary>
        /// We start each server in a separate thread
        /// </summary>
        public void Start()
        {
            Thread UserThread = new Thread(new ThreadStart(() => UserSocket()));
            UserThread.Start();
            
            Thread TopicThread = new Thread(new ThreadStart(() => TopicList()));
            TopicThread.Start();

            Thread AddTopicThread = new Thread(new ThreadStart(() => AddTopic()));
            AddTopicThread.Start();

            //Create a Form that has only one button
            StopServerForm stop = new StopServerForm();
            stop.ShowDialog();
            //When the button is clicked, the form is closed, the rest of the code is then executed

            //We Save the user in the Sql Server
            userManager.UserSave();
            Console.WriteLine("Server shutting down...");
            Console.WriteLine("You can now close the server's console.");
        }

        /// <summary>
        /// This thread is used to send the topic list to a User when he needs them
        /// </summary>
        public void TopicList()
        {
            //get topic list port
            int port = 13001;
            string ipAddress = "127.0.0.1";
            Socket serverListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ipAddress), port);
            serverListener.Bind(ep);
            serverListener.Listen(100);
            Socket clientSocket = default(Socket);

            Console.WriteLine("Topic List port : Running");

            while (true)
            {
                //We accept every connection
                clientSocket = serverListener.Accept();
                Console.WriteLine("A client wants to get the Topic");

                List<TopicToClient> topicList = topicManager.SendTopicList();

                byte[] message;
                BinaryFormatter bf = new BinaryFormatter();
                MemoryStream fs = new MemoryStream();
                bf.Serialize(fs, topicList);
                fs.Seek(0, SeekOrigin.Begin);
                message = fs.ToArray();
                clientSocket.Send(message, 0, message.Length, SocketFlags.None);
                Thread.Sleep(50);
                clientSocket.Close();
            }
        }

        /// <summary>
        /// This function listen to client that wants to add a topic
        /// </summary>
        public void AddTopic()
        {
            //add topic port
            int port = 13002;
            string ipAddress = "127.0.0.1";

            Socket serverListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ipAddress), port);
            serverListener.Bind(ep);
            serverListener.Listen(100);
            Socket clientSocket = default(Socket);

            Console.WriteLine("Add topic port : Running");

            while (true)
            {
                //We wait and accept the connection with a client
                clientSocket = serverListener.Accept();
                
                //We receive the topic name from the client
                byte[] msgFromServer = new byte[1024];
                int size = clientSocket.Receive(msgFromServer);
                BinaryFormatter bf = new BinaryFormatter();
                MemoryStream fs = new MemoryStream();
                fs.Write(msgFromServer, 0, msgFromServer.Length);
                fs.Position = 0;
                Message message = (Message)bf.Deserialize(fs);

                //We add it to the topicManager
                topicManager.AddTopic(message.Msg);
                Console.WriteLine("Topic created, name: " + message.Msg);

                //We close the connection
                clientSocket.Close();
            }
        }

        /// <summary>
        /// We connect to the server, when the user is connected, he is placed in a thread where
        /// he has to login or to register to go further in the application
        /// </summary>
        public void UserSocket()
        {
            //Authentication port
            int port = 13000;
            string ipAddress = "127.0.0.1";

            //We initialize the server
            Socket serverListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ipAddress), port);
            serverListener.Bind(ep);
            serverListener.Listen(100);
            Socket clientSocket = default(Socket);

            Console.WriteLine("User authentication port : Running");
            while (true)
            {
                clientSocket = serverListener.Accept();
                Console.WriteLine("A client wants to login");
                Thread UserThread = new Thread(new ThreadStart(() => User(clientSocket)));
                UserThread.Start();
            }
        }

        /// <summary>
        /// When a client wants to login, he is sent in this thread via the server, he is blocked in this thread until he has successfully connected
        /// </summary>
        /// <param name="client"></param>
        public void User(Socket client)
        {
            bool x = true;
            //As long as the client has not disconnected or provided an authentic acount, he is stuck in this loop.
            while (x)
            {
                try
                {
                    //We receive a User
                    byte[] msg = new byte[1024];
                    int size = client.Receive(msg);
                    BinaryFormatter bf = new BinaryFormatter();
                    MemoryStream fs = new MemoryStream();
                    fs.Write(msg, 0, msg.Length);
                    fs.Position = 0;
                    User o = (User)bf.Deserialize(fs);

                    BinaryFormatter bf2 = new BinaryFormatter();
                    MemoryStream fs2 = new MemoryStream();

                    //if he wants to Login
                    if (o is UserLogin)
                    {
                        string temp = userManager.Login(o.login, o.password);
                        Message message = new Message(temp);
                        bf2.Serialize(fs2, message);
                        byte[] messageToClient = fs2.ToArray();

                        if (temp == "success")
                        {
                            client.Send(messageToClient, 0, messageToClient.Length, SocketFlags.None);
                            x = false;
                            client.Close();
                        }
                        else if (temp == "error")
                        {
                            client.Send(messageToClient, 0, messageToClient.Length, SocketFlags.None);
                        }
                    }

                    //if he wants to register
                    else if (o is UserRegister)
                    {
                        string temp = userManager.Register(o.login, o.password);
                        Message message = new Message(temp);
                        bf2.Serialize(fs2, message);
                        byte[] messageToClient = fs2.ToArray();

                        if (temp == "success")
                        {
                            client.Send(messageToClient, 0, messageToClient.Length, SocketFlags.None);
                            x = false;
                            client.Close();
                        }
                        else if (temp == "error")
                        {
                            client.Send(messageToClient, 0, messageToClient.Length, SocketFlags.None);
                        }
                    }
                }
                catch (SocketException)
                {
                    Console.WriteLine("A client has disconnected");
                    x = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("A client has disconnected");
                    x = false;
                }
            }
        }
    }
}
