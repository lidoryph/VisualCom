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
            dlgOpenFile = new OpenFileDialog();
            dlgSaveFile = new SaveFileDialog();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnLoadProject);
            groupBox1.Controls.Add(btnNewProject);
            groupBox1.ForeColor = SystemColors.HighlightText;
            groupBox1.Location = new Point(124, 85);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(148, 102);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Acciones";
            // 
            // btnLoadProject
            // 
            btnLoadProject.ForeColor = SystemColors.HighlightText;
            btnLoadProject.Location = new Point(6, 59);
            btnLoadProject.Margin = new Padding(3, 2, 3, 2);
            btnLoadProject.Name = "btnLoadProject";
            btnLoadProject.Size = new Size(137, 35);
            btnLoadProject.TabIndex = 1;
            btnLoadProject.Text = "Cargar Proyecto...";
            btnLoadProject.UseVisualStyleBackColor = true;
            btnLoadProject.Click += btnLoadProject_Click;
            btnLoadProject.MouseEnter += btnLoadProject_MouseEnter;
            btnLoadProject.MouseLeave += btnLoadProject_MouseLeave;
            // 
            // btnNewProject
            // 
            btnNewProject.ForeColor = SystemColors.HighlightText;
            btnNewProject.Location = new Point(6, 20);
            btnNewProject.Margin = new Padding(3, 2, 3, 2);
            btnNewProject.Name = "btnNewProject";
            btnNewProject.Size = new Size(137, 35);
            btnNewProject.TabIndex = 0;
            btnNewProject.Text = "Proyecto Nuevo...";
            btnNewProject.UseVisualStyleBackColor = true;
            btnNewProject.Click += btnNewProject_Click;
            btnNewProject.MouseEnter += btnNewProject_MouseEnter;
            btnNewProject.MouseLeave += btnNewProject_MouseLeave;
            // 
            // WelcomeWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(63, 62, 62);
            ClientSize = new Size(656, 349);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "WelcomeWindow";
            Text = "VisualCom - Bienvenido";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnLoadProject;
        private Button btnNewProject;
        private OpenFileDialog dlgOpenFile;
        private SaveFileDialog dlgSaveFile;
    }
}