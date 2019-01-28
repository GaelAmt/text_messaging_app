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
using Message = Server.Message;

namespace Client
{
    public partial class AddTopic : Form
    {
        int port;
        string ipAddress;
        Socket clientSocket;
        IPEndPoint ep;

        public AddTopic()
        {
            InitializeComponent();
            nullError.Visible = false;
        }

        /// <summary>
        /// Checks if the array is empty, if not, we send a request to the server to add a new topic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addServerButton_Click(object sender, EventArgs e)
        {

            string s = serverNameBox.Text;
            if (s == null || s == "")
            {
                nullError.Visible = true;
            }
            else
            {
                nullError.Visible = false;

                //We connect to the Server's Add Port
                port = 13002;
                ipAddress = "127.0.0.1";
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ep = new IPEndPoint(IPAddress.Parse(ipAddress), port);
                clientSocket.Connect(ep);

                //We serialize our Message and send it to the server
                BinaryFormatter bf = new BinaryFormatter();
                MemoryStream fs = new MemoryStream();
                Message message = new Message(s);
                bf.Serialize(fs, message);
                byte[] messageToServer = fs.ToArray();
                clientSocket.Send(messageToServer, 0, messageToServer.Length, SocketFlags.None);
                
                //We then close the connection
                clientSocket.Close();
                this.Close();
            }
        }
    }
}
