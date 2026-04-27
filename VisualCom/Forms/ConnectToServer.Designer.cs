namespace VisualCom.Forms
{
    partial class ConnectToServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectToServer));
            Connect_Button = new Button();
            Close_Button = new Button();
            ServerIP_TextBox = new TextBox();
            ServerPort_TextBox = new TextBox();
            label1 = new Label();
            User_TextBox = new TextBox();
            SuspendLayout();
            // 
            // Connect_Button
            // 
            Connect_Button.BackColor = Color.FromArgb(214, 10, 81);
            Connect_Button.FlatAppearance.BorderSize = 0;
            Connect_Button.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 192);
            Connect_Button.FlatAppearance.MouseOverBackColor = Color.FromArgb(48, 39, 131);
            Connect_Button.FlatStyle = FlatStyle.Flat;
            Connect_Button.ForeColor = Color.White;
            Connect_Button.Location = new Point(223, 132);
            Connect_Button.Name = "Connect_Button";
            Connect_Button.Size = new Size(75, 23);
            Connect_Button.TabIndex = 0;
            Connect_Button.Text = "Conectar";
            Connect_Button.UseVisualStyleBackColor = false;
            Connect_Button.Click += ConnectServer;
            // 
            // Close_Button
            // 
            Close_Button.BackColor = Color.FromArgb(214, 10, 81);
            Close_Button.FlatAppearance.BorderSize = 0;
            Close_Button.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 192);
            Close_Button.FlatAppearance.MouseOverBackColor = Color.FromArgb(48, 39, 131);
            Close_Button.FlatStyle = FlatStyle.Flat;
            Close_Button.ForeColor = Color.White;
            Close_Button.Location = new Point(198, 161);
            Close_Button.Name = "Close_Button";
            Close_Button.Size = new Size(128, 48);
            Close_Button.TabIndex = 1;
            Close_Button.Text = "Cerrar";
            Close_Button.UseVisualStyleBackColor = false;
            Close_Button.Click += CloaseDialog;
            // 
            // ServerIP_TextBox
            // 
            ServerIP_TextBox.BackColor = Color.FromArgb(33, 32, 32);
            ServerIP_TextBox.BorderStyle = BorderStyle.None;
            ServerIP_TextBox.ForeColor = Color.White;
            ServerIP_TextBox.Location = new Point(89, 34);
            ServerIP_TextBox.Name = "ServerIP_TextBox";
            ServerIP_TextBox.PlaceholderText = "Introduce la dirección del servidor";
            ServerIP_TextBox.Size = new Size(258, 16);
            ServerIP_TextBox.TabIndex = 2;
            // 
            // ServerPort_TextBox
            // 
            ServerPort_TextBox.BackColor = Color.FromArgb(33, 32, 32);
            ServerPort_TextBox.BorderStyle = BorderStyle.None;
            ServerPort_TextBox.ForeColor = Color.White;
            ServerPort_TextBox.Location = new Point(357, 34);
            ServerPort_TextBox.Name = "ServerPort_TextBox";
            ServerPort_TextBox.PlaceholderText = "Puerto";
            ServerPort_TextBox.Size = new Size(100, 16);
            ServerPort_TextBox.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(347, 33);
            label1.Name = "label1";
            label1.Size = new Size(10, 15);
            label1.TabIndex = 4;
            label1.Text = ":";
            // 
            // User_TextBox
            // 
            User_TextBox.BackColor = Color.FromArgb(33, 32, 32);
            User_TextBox.BorderStyle = BorderStyle.None;
            User_TextBox.ForeColor = Color.White;
            User_TextBox.Location = new Point(207, 78);
            User_TextBox.Name = "User_TextBox";
            User_TextBox.PlaceholderText = "Usuario";
            User_TextBox.Size = new Size(100, 16);
            User_TextBox.TabIndex = 5;
            // 
            // ConnectToServer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(63, 62, 62);
            ClientSize = new Size(562, 221);
            Controls.Add(User_TextBox);
            Controls.Add(label1);
            Controls.Add(ServerPort_TextBox);
            Controls.Add(ServerIP_TextBox);
            Controls.Add(Close_Button);
            Controls.Add(Connect_Button);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ConnectToServer";
            Text = "ConnectToServer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Connect_Button;
        private Button Close_Button;
        private TextBox ServerIP_TextBox;
        private TextBox ServerPort_TextBox;
        private Label label1;
        private TextBox User_TextBox;
    }
}