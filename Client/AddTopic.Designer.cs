namespace Client
{
    partial class AddTopic
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.addServerButton = new System.Windows.Forms.Button();
            this.serverNameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nullError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(219, 20);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            // 
            // addServerButton
            // 
            this.addServerButton.Location = new System.Drawing.Point(143, 51);
            this.addServerButton.Name = "addServerButton";
            this.addServerButton.Size = new System.Drawing.Size(129, 40);
            this.addServerButton.TabIndex = 0;
            this.addServerButton.Text = "Add a server";
            this.addServerButton.UseVisualStyleBackColor = true;
            this.addServerButton.Click += new System.EventHandler(this.addServerButton_Click);
            // 
            // serverNameBox
            // 
            this.serverNameBox.Location = new System.Drawing.Point(12, 25);
            this.serverNameBox.Name = "serverNameBox";
            this.serverNameBox.Size = new System.Drawing.Size(259, 20);
            this.serverNameBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Server\'s name";
            // 
            // nullError
            // 
            this.nullError.AutoSize = true;
            this.nullError.ForeColor = System.Drawing.Color.Red;
            this.nullError.Location = new System.Drawing.Point(12, 51);
            this.nullError.Name = "nullError";
            this.nullError.Size = new System.Drawing.Size(75, 13);
            this.nullError.TabIndex = 3;
            this.nullError.Text = "Cannot be null";
            // 
            // AddTopic
            // 
            this.ClientSize = new System.Drawing.Size(284, 103);
            this.Controls.Add(this.nullError);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.serverNameBox);
            this.Controls.Add(this.addServerButton);
            this.Name = "AddTopic";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button addServerButton;
        private System.Windows.Forms.TextBox serverNameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label nullError;
    }
}