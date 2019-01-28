namespace Client
{
    partial class TopicList
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.privateMessageButton = new System.Windows.Forms.Button();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.WelcomeGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.topicListBox = new System.Windows.Forms.ListBox();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.addTopicButton = new System.Windows.Forms.Button();
            this.WelcomeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Location = new System.Drawing.Point(6, 19);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(320, 290);
            this.listBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(392, 138);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 55);
            this.button1.TabIndex = 1;
            this.button1.Text = "Reload Topic";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(6, 19);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(356, 303);
            this.listBox2.TabIndex = 1;
            // 
            // privateMessageButton
            // 
            this.privateMessageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.privateMessageButton.Location = new System.Drawing.Point(392, 305);
            this.privateMessageButton.Name = "privateMessageButton";
            this.privateMessageButton.Size = new System.Drawing.Size(110, 59);
            this.privateMessageButton.TabIndex = 3;
            this.privateMessageButton.Text = "Send a private message";
            this.privateMessageButton.UseVisualStyleBackColor = true;
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new System.Drawing.Point(6, 19);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(356, 303);
            this.listBox3.TabIndex = 0;
            // 
            // WelcomeGroupBox
            // 
            this.WelcomeGroupBox.Controls.Add(this.label1);
            this.WelcomeGroupBox.Controls.Add(this.topicListBox);
            this.WelcomeGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WelcomeGroupBox.Location = new System.Drawing.Point(13, 12);
            this.WelcomeGroupBox.Name = "WelcomeGroupBox";
            this.WelcomeGroupBox.Size = new System.Drawing.Size(372, 352);
            this.WelcomeGroupBox.TabIndex = 4;
            this.WelcomeGroupBox.TabStop = false;
            this.WelcomeGroupBox.Text = "Welcome ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Double-click on a topic to enter";
            // 
            // topicListBox
            // 
            this.topicListBox.FormattingEnabled = true;
            this.topicListBox.ItemHeight = 20;
            this.topicListBox.Location = new System.Drawing.Point(7, 60);
            this.topicListBox.Name = "topicListBox";
            this.topicListBox.Size = new System.Drawing.Size(359, 284);
            this.topicListBox.TabIndex = 0;
            this.topicListBox.DoubleClick += new System.EventHandler(this.topicListBox_DoubleClick);
            // 
            // disconnectButton
            // 
            this.disconnectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disconnectButton.Location = new System.Drawing.Point(391, 32);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(109, 59);
            this.disconnectButton.TabIndex = 5;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // addTopicButton
            // 
            this.addTopicButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addTopicButton.Location = new System.Drawing.Point(391, 199);
            this.addTopicButton.Name = "addTopicButton";
            this.addTopicButton.Size = new System.Drawing.Size(107, 52);
            this.addTopicButton.TabIndex = 6;
            this.addTopicButton.Text = "Add a Topic";
            this.addTopicButton.UseVisualStyleBackColor = true;
            this.addTopicButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // TopicList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 377);
            this.Controls.Add(this.addTopicButton);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.WelcomeGroupBox);
            this.Controls.Add(this.privateMessageButton);
            this.Controls.Add(this.button1);
            this.Name = "TopicList";
            this.Text = "TopicList";
            this.WelcomeGroupBox.ResumeLayout(false);
            this.WelcomeGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Button privateMessageButton;
        private System.Windows.Forms.GroupBox WelcomeGroupBox;
        private System.Windows.Forms.ListBox topicListBox;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.Button addTopicButton;
        private System.Windows.Forms.Label label1;
    }
}