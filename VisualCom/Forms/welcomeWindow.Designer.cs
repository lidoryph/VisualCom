namespace VisualCom
{
    partial class WelcomeWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomeWindow));
            groupBox1 = new GroupBox();
            btnLoadProject = new Button();
            btnNewProject = new Button();
            SaveFileDlg = new SaveFileDialog();
            OpenFileDlg = new OpenFileDialog();
            ConnectToServer_Button = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnLoadProject);
            groupBox1.Controls.Add(btnNewProject);
            groupBox1.ForeColor = SystemColors.ControlText;
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            // 
            // btnLoadProject
            // 
            btnLoadProject.ForeColor = SystemColors.ControlText;
            resources.ApplyResources(btnLoadProject, "btnLoadProject");
            btnLoadProject.Name = "btnLoadProject";
            btnLoadProject.UseVisualStyleBackColor = true;
            btnLoadProject.Click += LoadProject;
            // 
            // btnNewProject
            // 
            btnNewProject.ForeColor = SystemColors.ControlText;
            resources.ApplyResources(btnNewProject, "btnNewProject");
            btnNewProject.Name = "btnNewProject";
            btnNewProject.UseVisualStyleBackColor = true;
            btnNewProject.Click += NewProject;
            // 
            // ConnectToServer_Button
            // 
            resources.ApplyResources(ConnectToServer_Button, "ConnectToServer_Button");
            ConnectToServer_Button.Name = "ConnectToServer_Button";
            ConnectToServer_Button.UseVisualStyleBackColor = true;
            ConnectToServer_Button.Click += ConnectServer;
            // 
            // WelcomeWindow
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(ConnectToServer_Button);
            Controls.Add(groupBox1);
            MaximizeBox = false;
            Name = "WelcomeWindow";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnLoadProject;
        private Button btnNewProject;
        private SaveFileDialog SaveFileDlg;
        private OpenFileDialog OpenFileDlg;
        private Button ConnectToServer_Button;
    }
}