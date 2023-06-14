
namespace demo_ChatBox
{
    partial class Form2
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
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.listMessage = new System.Windows.Forms.ListBox();
            this.txtBoxChat = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(247, 48);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 1;
           // this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // listMessage
            // 
            this.listMessage.FormattingEnabled = true;
            this.listMessage.Location = new System.Drawing.Point(35, 102);
            this.listMessage.Name = "listMessage";
            this.listMessage.Size = new System.Drawing.Size(716, 199);
            this.listMessage.TabIndex = 2;
            // 
            // txtBoxChat
            // 
            this.txtBoxChat.Location = new System.Drawing.Point(176, 360);
            this.txtBoxChat.Name = "txtBoxChat";
            this.txtBoxChat.Size = new System.Drawing.Size(276, 20);
            this.txtBoxChat.TabIndex = 3;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(472, 360);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Gửi ";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtBoxChat);
            this.Controls.Add(this.listMessage);
            this.Controls.Add(this.comboBox2);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ListBox listMessage;
        private System.Windows.Forms.TextBox txtBoxChat;
        private System.Windows.Forms.Button btnSend;
    }
}