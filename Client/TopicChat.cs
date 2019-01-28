using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Server;
using Message = Server.Message;

namespace Client
{
    public partial class TopicChat : Form
    {
        string topicName;
        int port;
        User user;
        string ipAddress;
        Socket clientSocket;
        IPEndPoint ep;

        public TopicChat(TopicToClient topic, User u)
        {
            //We initialize our variables and form
            InitializeComponent();
            user = u;
            topicName = topic.Name;
            topicNameLabel.Text += topic.Name;
            infoLabel.Text += u.login;

            //We connect to the Topic port
            port = topic.Port;
            ipAddress = "127.0.0.1";
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ep = new IPEndPoint(IPAddress.Parse(ipAddress), port);
            clientSocket.Connect(ep);
            
            //We send our username to the server
            Message m = new Message(u.login);
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream fs = new MemoryStream();
            bf.Serialize(fs, m);
            byte[] messageToClient = fs.ToArray();
            clientSocket.Send(messageToClient, 0, messageToClient.Length, SocketFlags.None);

            //We then create a ReceiveMessage thread
            Thread receiveThread = new Thread(new ThreadStart(() => ReceiveMessage()));
            receiveThread.Start();
        }

        /// <summary>
        /// When we press the Send Button, we send a Serialized Message to the server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendButton_Click(object sender, EventArgs e)
        {
            if (!(messageTextBox.Text == "" || messageTextBox.Text == null))
            {

                BinaryFormatter bf = new BinaryFormatter();
                MemoryStream fs = new MemoryStream();
                Message message = new Message(messageTextBox.Text);
                messageTextBox.Text = "";
                bf.Serialize(fs, message);
                byte[] messageToClient = fs.ToArray();
                clientSocket.Send(messageToClient, 0, messageToClient.Length, SocketFlags.None);
            }
        }

        /// <summary>
        /// We close the connection with the server and close the TopicChat Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            CloseConnection();
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        private void ReceiveMessage()
        {
            bool x = true;
            while (x)
            {
                try
                { 
                    byte[] messageFromServer = new byte[1024];
                    int size = clientSocket.Receive(messageFromServer);
                    BinaryFormatter bf = new BinaryFormatter();
                    MemoryStream fs = new MemoryStream();
                    fs.Write(messageFromServer, 0, messageFromServer.Length);
                    fs.Position = 0;
                    Message o = (Message)bf.Deserialize(fs);
                    this.Invoke(new MethodInvoker(delegate
                    {
                        chatTextBox.Text += o.Msg;
                    }));
                }
                catch (SocketException e)
                {
                    Console.WriteLine(e.ToString());
                    x = false;
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    x = false;
                }
                
            }
        }

        /// <summary>
        /// Close the connection when we click the Red Cross
        /// </summary>
        /// <param name="e"></param>
        private void onFormClosing(FormClosingEventArgs e)
        {
            CloseConnection();
        }

        /// <summary>
        /// Sends the server a UserDisconnect object, and close the connection with the server
        /// </summary>
        private void CloseConnection()
        {
            UserDisconnect userDisconnect = new UserDisconnect(user.login, "");
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream fs = new MemoryStream();
            bf.Serialize(fs, userDisconnect);
            byte[] messageToClient = fs.ToArray();
            clientSocket.Send(messageToClient, 0, messageToClient.Length, SocketFlags.None);
            clientSocket.Close();
        }
    }
}
