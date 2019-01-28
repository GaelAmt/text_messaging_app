using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Server;

namespace Client
{
    class Program
    {
        private static LoginForm lf;
                                       
        static void Main(string[] args)
        {
            //We create a LoginForm
            Thread.Sleep(100);
            lf = new LoginForm();
            lf.ShowDialog();
        }
    }
}
