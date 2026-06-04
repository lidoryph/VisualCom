namespace VisualCom.Forms.Online.Extra
{
    partial class QuickLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuickLogin));
            loginbutton = new Button();
            username = new TextBox();
            SuspendLayout();
            // 
            // loginbutton
            // 
            loginbutton.Location = new Point(231, 91);
            loginbutton.Name = "loginbutton";
            loginbutton.Size = new Size(75, 23);
            loginbutton.TabIndex = 0;
            loginbutton.Text = "button1";
            loginbutton.UseVisualStyleBackColor = true;
            loginbutton.Click += LoginButton_Click;
            // 
            // username
            // 
            username.Location = new Point(217, 45);
            username.Name = "username";
            username.Size = new Size(100, 22);
            username.TabIndex = 1;
            // 
            // QuickLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(63, 62, 62);
            ClientSize = new Size(545, 196);
            Controls.Add(username);
            Controls.Add(loginbutton);
            Font = new Font("Neo Sans Std", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "QuickLogin";
            Text = "Inicio Rapido";
            FormClosed += QuickLogin_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button loginbutton;
        private TextBox username;
    }
}