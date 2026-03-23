namespace VisualCom.Forms
{
    partial class ProjectType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectType));
            OIbutton = new Button();
            Cbutton = new Button();
            Label = new Label();
            SuspendLayout();
            // 
            // OIbutton
            // 
            OIbutton.ForeColor = SystemColors.ControlText;
            OIbutton.Image = Properties.Resources.magnifier;
            resources.ApplyResources(OIbutton, "OIbutton");
            OIbutton.Name = "OIbutton";
            OIbutton.UseVisualStyleBackColor = true;
            OIbutton.Click += ObjectIdentification;
            // 
            // Cbutton
            // 
            Cbutton.ForeColor = SystemColors.ControlText;
            Cbutton.Image = Properties.Resources.tag;
            resources.ApplyResources(Cbutton, "Cbutton");
            Cbutton.Name = "Cbutton";
            Cbutton.UseVisualStyleBackColor = true;
            Cbutton.Click += Classification;
            // 
            // Label
            // 
            resources.ApplyResources(Label, "Label");
            Label.ForeColor = SystemColors.ControlText;
            Label.Name = "Label";
            // 
            // ProjectType
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(Label);
            Controls.Add(Cbutton);
            Controls.Add(OIbutton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ProjectType";
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button OIbutton;
        private Button Cbutton;
        private Label Label;
    }
}