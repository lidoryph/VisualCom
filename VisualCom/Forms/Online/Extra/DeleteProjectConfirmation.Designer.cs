namespace VisualCom.Forms
{
    partial class DeleteProjectConfirmation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeleteProjectConfirmation));
            CancelButton = new Button();
            AcceptButton = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // CancelButton
            // 
            CancelButton.BackColor = Color.FromArgb(214, 10, 81);
            CancelButton.Cursor = Cursors.Hand;
            CancelButton.FlatAppearance.BorderSize = 0;
            CancelButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 192);
            CancelButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(48, 39, 131);
            CancelButton.FlatStyle = FlatStyle.Flat;
            CancelButton.Font = new Font("Neo Sans Std", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CancelButton.ForeColor = Color.White;
            CancelButton.Location = new Point(260, 75);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(128, 48);
            CancelButton.TabIndex = 5;
            CancelButton.Text = "Cancelar";
            CancelButton.UseVisualStyleBackColor = false;
            CancelButton.Click += DeleteCancelled;
            // 
            // AcceptButton
            // 
            AcceptButton.Anchor = AnchorStyles.None;
            AcceptButton.BackColor = Color.FromArgb(214, 10, 81);
            AcceptButton.Cursor = Cursors.Hand;
            AcceptButton.FlatAppearance.BorderSize = 0;
            AcceptButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 192);
            AcceptButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(48, 39, 131);
            AcceptButton.FlatStyle = FlatStyle.Flat;
            AcceptButton.Font = new Font("Neo Sans Std", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AcceptButton.ForeColor = Color.White;
            AcceptButton.Location = new Point(56, 75);
            AcceptButton.Name = "AcceptButton";
            AcceptButton.Size = new Size(128, 48);
            AcceptButton.TabIndex = 4;
            AcceptButton.Text = "Aceptar";
            AcceptButton.UseVisualStyleBackColor = false;
            AcceptButton.Click += DeleteConfirmed;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Neo Sans Std", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(76, 22);
            label1.Name = "label1";
            label1.Size = new Size(293, 19);
            label1.TabIndex = 3;
            label1.Text = "¿Seguro que quieres borrar el proyecto? ";
            // 
            // DeleteProjectConfirmation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(63, 62, 62);
            ClientSize = new Size(444, 147);
            ControlBox = false;
            Controls.Add(CancelButton);
            Controls.Add(AcceptButton);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DeleteProjectConfirmation";
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Confirme el borrado";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button CancelButton;
        private Button AcceptButton;
        private Label label1;
    }
}