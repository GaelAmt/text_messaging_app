using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class UserManager
    {
        private List<User> userList;
        MySqlConnection conn;
        private Mutex m;

        public UserManager()
        {
            m = new Mutex();
            userList = new List<User>();
            InitConnection();
        }

        public void InitConnection()
        {
            string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=csharp";
            conn = new MySqlConnection(connection);
        }

        public void userRetrieve()
        {
            conn.Open();
            MySqlCommand sqlcommand = new MySqlCommand("SELECT login, password FROM account", conn);
            sqlcommand.ExecuteNonQuery();
            MySqlDataReader r = sqlcommand.ExecuteReader();
            while (r.Read())
            {
                User u = new User(r["login"].ToString(), r["password"].ToString());
                userList.Add(u);
            }
            conn.Close();
        }

        public void UserSave()
        {
            foreach(User u in userList)
            {
                AddAccount(u.login, u.password);
            }
        }

        public int Count()
        {
            return userList.Count;
        }

        public Boolean AddAccount(string login, string password)
        {
            m.WaitOne();
            if (!LoginExists(login))
            {
                conn.Open();
                string query = "INSERT INTO account VALUES ('" + login + "', '" + password + "')";
                MySqlCommand sqlCommand = new MySqlCommand(query, conn);
                sqlCommand.ExecuteNonQuery();
                conn.Close();
                m.ReleaseMutex();
                return true;
            }
            else
            {
                m.ReleaseMutex();
                return false;
            }
        }

        /// <summary>
        /// Used when we want to save our list in the database
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public Boolean LoginExists(string login)
        {
            conn.Open();
            string query = "SELECT * FROM account WHERE login='" + login + "'";
            MySqlCommand sqlCommand = new MySqlCommand(query, conn);
            sqlCommand.ExecuteNonQuery();
            MySqlDataReader r = sqlCommand.ExecuteReader();
            while (r.Read())
            {
                conn.Close();
                return true;
            }
            conn.Close();
            return false;
        }

        public string Login(string login, string password)
        {
            m.WaitOne();
            foreach(User u in userList)
            {
                if (u.login == login && u.password == password)
                {
                    m.ReleaseMutex();
                    return "success";
                }
            }
            m.ReleaseMutex();
            return "error";
        }

        public string Register(string login, string password)
        {
            m.WaitOne();
            foreach(User us in userList)
            {
                if (us.login == login)
                {
                    m.ReleaseMutex();
                    return "error";
                }
            }
            User u = new User(login, password);
            userList.Add(u);
            m.ReleaseMutex();
            return "success";
        }
        
        public string getString()
        {
            string s = "";
            m.WaitOne();
            s += "Login and password List :\n";
            foreach(User us in userList)
            {
                s += "     ";
                s += us.login + "|" + us.password;
                s += "\n";
            }
            m.ReleaseMutex();
            return s;
        }
    }
}
