using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet_CSharp
{
    class AccountManager
    {
        MySqlConnection conn;

        public AccountManager()
        {
            InitConnection();
        }

        public void InitConnection()
        {
            string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=csharp";
            conn = new MySqlConnection(connection);
        }
        /// <summary>
        /// Checks if the login matches the password.
        /// </summary>
        /// <param name="login">login of the user</param>
        /// <param name="password">password of the user</param>
        /// <returns>returns true if  login the login matches the password, false if not</returns>
        public bool UserAuthentication(string login, string password)
        {
            conn.Open();
            MySqlCommand sqlCommand = new MySqlCommand("SELECT password FROM account WHERE login='" + login + "'", conn);
            sqlCommand.ExecuteNonQuery();
            MySqlDataReader r = sqlCommand.ExecuteReader();
            while (r.Read())
            {
                if (r["password"].ToString() == password)
                {
                    conn.Close();
                    return true;
                }
                else
                {
                    conn.Close();
                    return false;
                }
            }
            conn.Close();
            return false;
        }
        
        /// <summary>
        /// add an account to the database
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns>true if the account was added, false if the account already exists</returns>
        public Boolean AddAccount(string login, string password)
        {
            if (!LoginExists(login))
            {
                conn.Open();
                string query = "INSERT INTO account VALUES ('" + login + "', '" + password + "')";
                MySqlCommand sqlCommand = new MySqlCommand(query, conn);
                sqlCommand.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if a login is already in the database
        /// </summary>
        /// <param name="login"></param>
        /// <returns>returns true if he is in the database, false if not</returns>
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
    }
}