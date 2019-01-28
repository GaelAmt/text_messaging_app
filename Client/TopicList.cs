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
using System.Threading.Tasks;
using System.Windows.Forms;
using Server;

namespace Client
{
    public partial class TopicList : Form
    {
        List<TopicToClient> topicToClients;
        User user;

        int port;
        string ipAddress;
        Socket clientSocket;
        IPEndPoint ep;

        public TopicList(User u)
        {
            //We initialize our variables and forms, and get the topic from the server
            InitializeComponent();
            topicToClients = new List<TopicToClient>();
            user = u;
            WelcomeGroupBox.Text = "Welcome " + user.login;
            getTopic();
        }

        /// <summary>
        /// Reload button, when clicked, he asks the server what are the topic available, the server responds with a serialized list of Topic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e) //Reload button
        {
            getTopic();
        }

        /// <summary>
        /// When we double click on a topic, it opens a Topic chat with the user logged in in it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void topicListBox_DoubleClick(object sender, EventArgs e)
        {
            if (topicListBox.SelectedItem != null)
            {
                TopicChat topicChat = new TopicChat(topicListBox.SelectedItem as TopicToClient, user);
                topicChat.Show();
            }
        }

        /// <summary>
        /// We connect to the server to the port 13001.
        /// This port is used to send a List<TopicToClient> to everyone that connects to him and close the
        /// connection after.
        /// </summary>
        private void getTopic()
        {
            port = 13001;
            ipAddress = "127.0.0.1";
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ep = new IPEndPoint(IPAddress.Parse(ipAddress), port);
            clientSocket.Connect(ep);

            byte[] topicListFromServer = new byte[8192];
            int size = clientSocket.Receive(topicListFromServer);
            clientSocket.Close();
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream fs = new MemoryStream();
            fs.Write(topicListFromServer, 0, topicListFromServer.Length);
            fs.Position = 0;
            topicToClients = (List<TopicToClient>)bf.Deserialize(fs);
            topicListBox.DataSource = topicToClients;
        }

        /// <summary>
        /// When the disconnect button is clicked, it send a UserDisconnect object to the server, and is then removed from
        /// the list of the connected user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void disconnectButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Add topic button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e) //Add topic button
        {
            AddTopic at = new AddTopic();
            at.Show();
        }
    }
}
