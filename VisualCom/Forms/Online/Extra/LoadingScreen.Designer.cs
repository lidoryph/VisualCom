namespace VisualCom.Forms.Online.Extra
{
    partial class LoadingScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadingScreen));
            MessageLabel = new Label();
            progressBar1 = new ProgressBar();
            SuspendLayout();
            // 
            // MessageLabel
            // 
            MessageLabel.Font = new Font("Neo Sans Std", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MessageLabel.ForeColor = Color.White;
            MessageLabel.Location = new Point(12, 9);
            MessageLabel.Name = "MessageLabel";
            MessageLabel.Size = new Size(364, 72);
            MessageLabel.TabIndex = 0;
            MessageLabel.Text = "label1";
            MessageLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 84);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(364, 23);
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.TabIndex = 1;
            // 
            // LoadingScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(63, 62, 62);
            ClientSize = new Size(388, 119);
            Controls.Add(progressBar1);
            Controls.Add(MessageLabel);
            Cursor = Cursors.WaitCursor;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoadingScreen";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "LoadingScreen";
            TopMost = true;
            ResumeLayout(false);
        }

        #endregion

        private Label MessageLabel;
        private ProgressBar progressBar1;
    }
}