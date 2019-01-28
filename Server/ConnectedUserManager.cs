using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    /// <summary>
    /// This class will be used to track every person logged in.
    /// This list will be used to make connection between 2 user and connect them
    /// so they can send private message.
    /// </summary>
    class ConnectedUserManager
    {
        //TODO
        private List<string> connectedUser;

        public ConnectedUserManager()
        {
            connectedUser = new List<string>();
        }

        public bool AddUser()
        {
            return true;
        }
    }
}
