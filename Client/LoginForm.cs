using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class LoginForm : Form
    {
        UserConnection uc;
        public LoginForm()
        {
            InitializeComponent();
            uc = new UserConnection();
        }

        private void button1_Click(object sender, EventArgs e) //login button click
        {
            //we retrieve the user's login and password
            string u = usernameLoginForm.Text;
            string p = passwordLoginForm.Text;

            //we reset the form
            formError.Visible = false;
            passwordError.Visible = false;
            usernameError.Visible = false;
            usernameRegisterForm.Text = "";
            passwordRegisterForm1.Text = "";
            passwordRegisterForm2.Text = "";

            //We send our login and password to the server, and get the response
            string temp = uc.Login(u, p);
            Console.WriteLine("DEBUG>>Login attempt, server response: " + temp);

            //We update our form according to the server's response
            if (temp == "error")
            {
                formError.Visible = true;
            }
            else if (temp == "success")
            {
                try
                {
                    //We close the connection and open a TopicList form
                    TopicList tl = new TopicList(new Server.User(u, p));
                    this.Hide();
                    tl.ShowDialog();
                    uc.CloseConnection();
                }
                catch (Exception)
                {
                    Console.WriteLine("Disconnection error caught");
                }
            }
        }

        private void register_Click(object sender, EventArgs e) //Register Button click
        {
            //We retrieve the form
            string u = usernameRegisterForm.Text;
            string p1 = passwordRegisterForm1.Text;
            string p2 = passwordRegisterForm2.Text;

            //We reset the form
            passwordError.Visible = false;
            usernameError.Visible = false;
            formError.Visible = false;
            usernameLoginForm.Text = "";
            passwordLoginForm.Text = "";

            //We update the form according to the server's response
            if (p1 != p2)
            {
                passwordError.Visible = true;
            }
            else
            {
                string temp = uc.Register(u, p1);
                Console.WriteLine("Register attempt, server response: " + temp);
                if (temp == "error")
                {
                    usernameError.Visible = true;
                }
                else if (temp == "success")
                {
                    //we close the connection and create a topic list
                    uc.CloseConnection();
                    TopicList tl = new TopicList(new Server.User(u, p1));
                    this.Hide();
                    tl.ShowDialog();
                }
            }
        }
        
        private void onFormClosing(FormClosingEventArgs e) //Closing form event
        {
            uc.CloseConnection();
        }
    }
}
