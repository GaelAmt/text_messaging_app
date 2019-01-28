using Projet_CSharp.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_CSharp
{
    class MainClass
    {
        static void Main(string[] args)
        {
            Login_Form l = new Login_Form();
            l.ShowDialog();
            AccountManager am = new AccountManager();
            //Boolean test = am.UserAuthentication("admin", "admin");
            //Console.WriteLine(am.AddAccount("paull", "lenulll"));
            //am.UserAuthentication("paull", "lenullll");
        }
    }
}
