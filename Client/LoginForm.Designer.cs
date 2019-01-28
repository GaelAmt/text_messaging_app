namespace Client
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.usernameLoginForm = new System.Windows.Forms.TextBox();
            this.passwordLoginForm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.formError = new System.Windows.Forms.Label();
            this.login = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.passwordError = new System.Windows.Forms.Label();
            this.passwordRegisterForm2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.usernameError = new System.Windows.Forms.Label();
            this.register = new System.Windows.Forms.Button();
            this.usernameRegisterForm = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.passwordRegisterForm1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // usernameLoginForm
            // 
            this.usernameLoginForm.Location = new System.Drawing.Point(104, 76);
            this.usernameLoginForm.MaxLength = 100;
            this.usernameLoginForm.Name = "usernameLoginForm";
            this.usernameLoginForm.Size = new System.Drawing.Size(217, 26);
            this.usernameLoginForm.TabIndex = 0;
            // 
            // passwordLoginForm
            // 
            this.passwordLoginForm.Location = new System.Drawing.Point(104, 123);
            this.passwordLoginForm.MaxLength = 100;
            this.passwordLoginForm.Name = "passwordLoginForm";
            this.passwordLoginForm.Size = new System.Drawing.Size(217, 26);
            this.passwordLoginForm.TabIndex = 1;
            this.passwordLoginForm.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Username";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.formError);
            this.groupBox1.Controls.Add(this.login);
            this.groupBox1.Controls.Add(this.usernameLoginForm);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.passwordLoginForm);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 284);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login";
            // 
            // formError
            // 
            this.formError.AutoSize = true;
            this.formError.BackColor = System.Drawing.Color.Transparent;
            this.formError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formError.ForeColor = System.Drawing.Color.Red;
            this.formError.Location = new System.Drawing.Point(101, 60);
            this.formError.Name = "formError";
            this.formError.Size = new System.Drawing.Size(194, 13);
            this.formError.TabIndex = 8;
            this.formError.Text = "Username and Password doesn\'t match";
            this.formError.Visible = false;
            // 
            // login
            // 
            this.login.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login.Location = new System.Drawing.Point(86, 208);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(161, 70);
            this.login.TabIndex = 2;
            this.login.Text = "LOGIN";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.passwordError);
            this.groupBox2.Controls.Add(this.passwordRegisterForm2);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.usernameError);
            this.groupBox2.Controls.Add(this.register);
            this.groupBox2.Controls.Add(this.usernameRegisterForm);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.passwordRegisterForm1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(356, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(327, 284);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Register";
            // 
            // passwordError
            // 
            this.passwordError.AutoSize = true;
            this.passwordError.BackColor = System.Drawing.Color.Transparent;
            this.passwordError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordError.ForeColor = System.Drawing.Color.Red;
            this.passwordError.Location = new System.Drawing.Point(101, 136);
            this.passwordError.Name = "passwordError";
            this.passwordError.Size = new System.Drawing.Size(122, 13);
            this.passwordError.TabIndex = 11;
            this.passwordError.Text = "Password doesn\'t match";
            this.passwordError.Visible = false;
            // 
            // passwordRegisterForm2
            // 
            this.passwordRegisterForm2.Location = new System.Drawing.Point(104, 149);
            this.passwordRegisterForm2.MaxLength = 100;
            this.passwordRegisterForm2.Name = "passwordRegisterForm2";
            this.passwordRegisterForm2.Size = new System.Drawing.Size(217, 26);
            this.passwordRegisterForm2.TabIndex = 4;
            this.passwordRegisterForm2.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Password";
            // 
            // usernameError
            // 
            this.usernameError.AutoSize = true;
            this.usernameError.BackColor = System.Drawing.Color.Transparent;
            this.usernameError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameError.ForeColor = System.Drawing.Color.Red;
            this.usernameError.Location = new System.Drawing.Point(101, 34);
            this.usernameError.Name = "usernameError";
            this.usernameError.Size = new System.Drawing.Size(122, 13);
            this.usernameError.TabIndex = 8;
            this.usernameError.Text = "Username already taken";
            this.usernameError.Visible = false;
            // 
            // register
            // 
            this.register.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.register.Location = new System.Drawing.Point(75, 208);
            this.register.Name = "register";
            this.register.Size = new System.Drawing.Size(169, 70);
            this.register.TabIndex = 2;
            this.register.Text = "REGISTER";
            this.register.UseVisualStyleBackColor = true;
            this.register.Click += new System.EventHandler(this.register_Click);
            // 
            // usernameRegisterForm
            // 
            this.usernameRegisterForm.Location = new System.Drawing.Point(104, 50);
            this.usernameRegisterForm.MaxLength = 100;
            this.usernameRegisterForm.Name = "usernameRegisterForm";
            this.usernameRegisterForm.Size = new System.Drawing.Size(217, 26);
            this.usernameRegisterForm.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Username";
            // 
            // passwordRegisterForm1
            // 
            this.passwordRegisterForm1.Location = new System.Drawing.Point(104, 101);
            this.passwordRegisterForm1.MaxLength = 100;
            this.passwordRegisterForm1.Name = "passwordRegisterForm1";
            this.passwordRegisterForm1.Size = new System.Drawing.Size(217, 26);
            this.passwordRegisterForm1.TabIndex = 3;
            this.passwordRegisterForm1.UseSystemPasswordChar = true;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 319);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox usernameLoginForm;
        private System.Windows.Forms.TextBox passwordLoginForm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Label formError;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label passwordError;
        private System.Windows.Forms.TextBox passwordRegisterForm2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label usernameError;
        private System.Windows.Forms.Button register;
        private System.Windows.Forms.TextBox usernameRegisterForm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox passwordRegisterForm1;
    }
}