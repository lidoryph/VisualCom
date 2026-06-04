namespace VisualCom.Forms.Editor
{
    partial class ExitWithoutSave
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExitWithoutSave));
            label1 = new Label();
            DiscardButton = new Button();
            SaveButton = new Button();
            CancelButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(153, 36);
            label1.Name = "label1";
            label1.Size = new Size(206, 15);
            label1.TabIndex = 0;
            label1.Text = "No has guardado, ¿Que deseas hacer?";
            // 
            // DiscardButton
            // 
            DiscardButton.Image = Properties.Resources.exit;
            DiscardButton.ImageAlign = ContentAlignment.MiddleLeft;
            DiscardButton.Location = new Point(153, 129);
            DiscardButton.Name = "DiscardButton";
            DiscardButton.Padding = new Padding(10, 0, 0, 0);
            DiscardButton.Size = new Size(206, 23);
            DiscardButton.TabIndex = 1;
            DiscardButton.Text = "Descartar Cambios";
            DiscardButton.UseVisualStyleBackColor = true;
            DiscardButton.Click += DiscardChanges;
            // 
            // SaveButton
            // 
            SaveButton.Image = Properties.Resources.save_document;
            SaveButton.ImageAlign = ContentAlignment.MiddleLeft;
            SaveButton.Location = new Point(153, 80);
            SaveButton.Name = "SaveButton";
            SaveButton.Padding = new Padding(10, 0, 0, 0);
            SaveButton.Size = new Size(206, 43);
            SaveButton.TabIndex = 2;
            SaveButton.Text = "Guardar Cambios";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += WriteChanges;
            // 
            // CancelButton
            // 
            CancelButton.Image = Properties.Resources.go_back;
            CancelButton.ImageAlign = ContentAlignment.MiddleLeft;
            CancelButton.Location = new Point(153, 158);
            CancelButton.Name = "CancelButton";
            CancelButton.Padding = new Padding(10, 0, 0, 0);
            CancelButton.Size = new Size(206, 23);
            CancelButton.TabIndex = 3;
            CancelButton.Text = "Cancelar y Volver";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += Returnback;
            // 
            // ExitWithoutSave
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(496, 217);
            ControlBox = false;
            Controls.Add(CancelButton);
            Controls.Add(SaveButton);
            Controls.Add(DiscardButton);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ExitWithoutSave";
            ShowInTaskbar = false;
            Text = "¿Te vas sin guardar tu proyecto?";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button DiscardButton;
        private Button SaveButton;
        private Button CancelButton;
    }
}