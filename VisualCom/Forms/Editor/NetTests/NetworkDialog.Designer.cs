namespace VisualCom.Forms.Editor.NetTests
{
    partial class NetworkDialog
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
            PingButton = new Button();
            ServerURL = new TextBox();
            PortNumber = new NumericUpDown();
            CreateButton = new Button();
            ProjectName = new TextBox();
            ((System.ComponentModel.ISupportInitialize)PortNumber).BeginInit();
            SuspendLayout();
            // 
            // PingButton
            // 
            PingButton.Location = new Point(64, 50);
            PingButton.Name = "PingButton";
            PingButton.Size = new Size(75, 23);
            PingButton.TabIndex = 0;
            PingButton.Text = "Ping";
            PingButton.UseVisualStyleBackColor = true;
            PingButton.Click += PingServer;
            // 
            // ServerURL
            // 
            ServerURL.Location = new Point(363, 50);
            ServerURL.Name = "ServerURL";
            ServerURL.Size = new Size(224, 23);
            ServerURL.TabIndex = 1;
            // 
            // PortNumber
            // 
            PortNumber.Location = new Point(593, 52);
            PortNumber.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            PortNumber.Name = "PortNumber";
            PortNumber.Size = new Size(120, 23);
            PortNumber.TabIndex = 2;
            // 
            // CreateButton
            // 
            CreateButton.Location = new Point(64, 102);
            CreateButton.Name = "CreateButton";
            CreateButton.Size = new Size(164, 23);
            CreateButton.TabIndex = 3;
            CreateButton.Text = "Crear Proyecto";
            CreateButton.UseVisualStyleBackColor = true;
            CreateButton.Click += NewProject;
            // 
            // ProjectName
            // 
            ProjectName.Location = new Point(234, 103);
            ProjectName.Name = "ProjectName";
            ProjectName.Size = new Size(163, 23);
            ProjectName.TabIndex = 4;
            // 
            // NetworkDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ProjectName);
            Controls.Add(CreateButton);
            Controls.Add(PortNumber);
            Controls.Add(ServerURL);
            Controls.Add(PingButton);
            Name = "NetworkDialog";
            Text = "NetworkDialog";
            ((System.ComponentModel.ISupportInitialize)PortNumber).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button PingButton;
        private TextBox ServerURL;
        private NumericUpDown PortNumber;
        private Button CreateButton;
        private TextBox ProjectName;
    }
}