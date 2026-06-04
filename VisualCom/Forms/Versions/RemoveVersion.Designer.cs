namespace VisualCom.Forms.Editor.Versions
{
    partial class RemoveVersion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoveVersion));
            VersionSelector = new ComboBox();
            label1 = new Label();
            EraseVersionButton = new Button();
            CancelButton = new Button();
            SuspendLayout();
            // 
            // VersionSelector
            // 
            VersionSelector.FormattingEnabled = true;
            VersionSelector.Location = new Point(61, 47);
            VersionSelector.Name = "VersionSelector";
            VersionSelector.Size = new Size(384, 23);
            VersionSelector.TabIndex = 0;
            VersionSelector.Text = "Selecciona una versión...";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(156, 9);
            label1.Name = "label1";
            label1.Size = new Size(191, 15);
            label1.TabIndex = 1;
            label1.Text = "Seleccione una versión para borrar:";
            // 
            // EraseVersionButton
            // 
            EraseVersionButton.Image = Properties.Resources.remove_version;
            EraseVersionButton.ImageAlign = ContentAlignment.MiddleLeft;
            EraseVersionButton.Location = new Point(61, 93);
            EraseVersionButton.Name = "EraseVersionButton";
            EraseVersionButton.Padding = new Padding(10, 0, 0, 0);
            EraseVersionButton.Size = new Size(128, 48);
            EraseVersionButton.TabIndex = 2;
            EraseVersionButton.Text = "Borrar versión";
            EraseVersionButton.UseVisualStyleBackColor = true;
            EraseVersionButton.Click += LocalRemoveVersion;
            // 
            // CancelButton
            // 
            CancelButton.Image = Properties.Resources.go_back;
            CancelButton.ImageAlign = ContentAlignment.MiddleLeft;
            CancelButton.Location = new Point(317, 93);
            CancelButton.Name = "CancelButton";
            CancelButton.Padding = new Padding(10, 0, 0, 0);
            CancelButton.Size = new Size(128, 48);
            CancelButton.TabIndex = 3;
            CancelButton.Text = "Cancelar";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += Cancel;
            // 
            // RemoveVersion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(496, 153);
            Controls.Add(CancelButton);
            Controls.Add(EraseVersionButton);
            Controls.Add(label1);
            Controls.Add(VersionSelector);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RemoveVersion";
            ShowInTaskbar = false;
            Text = "Eliminar Versión";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox VersionSelector;
        private Label label1;
        private Button EraseVersionButton;
        private Button CancelButton;
    }
}