namespace Client
{
    partial class TopicChat
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
            this.sendButton = new System.Windows.Forms.Button();
            this.chatTextBox = new System.Windows.Forms.RichTextBox();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.topicNameLabel = new System.Windows.Forms.Label();
            this.infoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // sendButton
            // 
            this.sendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendButton.Location = new System.Drawing.Point(369, 416);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 28);
            this.sendButton.TabIndex = 2;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // chatTextBox
            // 
            this.chatTextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.chatTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatTextBox.Location = new System.Drawing.Point(12, 81);
            this.chatTextBox.Name = "chatTextBox";
            this.chatTextBox.ReadOnly = true;
            this.chatTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.chatTextBox.Size = new System.Drawing.Size(432, 331);
            this.chatTextBox.TabIndex = 3;
            this.chatTextBox.Text = "";
            // 
            // messageTextBox
            // 
            this.messageTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageTextBox.Location = new System.Drawing.Point(12, 418);
            this.messageTextBox.MaxLength = 1000;
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(351, 24);
            this.messageTextBox.TabIndex = 4;
            // 
            // disconnectButton
            // 
            this.disconnectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disconnectButton.Location = new System.Drawing.Point(285, 12);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(159, 63);
            this.disconnectButton.TabIndex = 5;
            this.disconnectButton.Text = "DISCONNECT";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // topicNameLabel
            // 
            this.topicNameLabel.AutoSize = true;
            this.topicNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topicNameLabel.Location = new System.Drawing.Point(16, 34);
            this.topicNameLabel.Name = "topicNameLabel";
            this.topicNameLabel.Size = new System.Drawing.Size(138, 18);
            this.topicNameLabel.TabIndex = 6;
            this.topicNameLabel.Text = "You are in the topic \r\n";
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoLabel.Location = new System.Drawing.Point(16, 12);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(104, 18);
            this.infoLabel.TabIndex = 7;
            this.infoLabel.Text = "Connected as ";
            // 
            // TopicChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 450);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.topicNameLabel);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.chatTextBox);
            this.Controls.Add(this.sendButton);
            this.Name = "TopicChat";
            this.Text = "TopicChat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.RichTextBox chatTextBox;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.Label topicNameLabel;
        private System.Windows.Forms.Label infoLabel;
    }
}