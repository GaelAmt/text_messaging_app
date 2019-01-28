using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Client
    {
        public string Username { set; get; }
        public Socket Socket { set; get; }

        public Client(string u, Socket s)
        {
            Username = u;
            Socket = s;
        }
    }
}
