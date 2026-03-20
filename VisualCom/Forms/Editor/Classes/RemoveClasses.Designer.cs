namespace VisualCom.Forms.Editor.Classes
{
    partial class RemoveClasses
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoveClasses));
            label1 = new Label();
            okButton = new Button();
            returnButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // okButton
            // 
            okButton.Image = Properties.Resources.eraser;
            resources.ApplyResources(okButton, "okButton");
            okButton.Name = "okButton";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += Accept;
            // 
            // returnButton
            // 
            returnButton.Image = Properties.Resources.go_back;
            resources.ApplyResources(returnButton, "returnButton");
            returnButton.Name = "returnButton";
            returnButton.UseVisualStyleBackColor = true;
            returnButton.Click += Deny;
            // 
            // RemoveClasses
            // 
            AcceptButton = okButton;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = returnButton;
            Controls.Add(returnButton);
            Controls.Add(okButton);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RemoveClasses";
            ShowInTaskbar = false;
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button okButton;
        private Button returnButton;
    }
}