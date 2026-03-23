namespace VisualCom.Forms.Editor.Versions.Dialogs
{
    partial class RemoveVersionOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoveVersionOptions));
            label1 = new Label();
            AddToCurrentVersion = new RadioButton();
            VersionSelector = new ComboBox();
            AcceptButton = new Button();
            CancelButton = new Button();
            AddToSelectedVersion = new RadioButton();
            EraseData = new RadioButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(59, 15);
            label1.Name = "label1";
            label1.Size = new Size(389, 30);
            label1.TabIndex = 0;
            label1.Text = "¿Que desea hacer con las Imagenes y Anotaciones de la versión a borrar?\r\n\r\n";
            // 
            // AddToCurrentVersion
            // 
            AddToCurrentVersion.AutoSize = true;
            AddToCurrentVersion.Location = new Point(104, 48);
            AddToCurrentVersion.Name = "AddToCurrentVersion";
            AddToCurrentVersion.Size = new Size(192, 19);
            AddToCurrentVersion.TabIndex = 1;
            AddToCurrentVersion.TabStop = true;
            AddToCurrentVersion.Text = "Añadir datos a la versión actual.\r\n";
            AddToCurrentVersion.UseVisualStyleBackColor = true;
            AddToCurrentVersion.Click += AddToCurrentVersion_Click;
            // 
            // VersionSelector
            // 
            VersionSelector.Enabled = false;
            VersionSelector.FormattingEnabled = true;
            VersionSelector.Location = new Point(124, 75);
            VersionSelector.Name = "VersionSelector";
            VersionSelector.Size = new Size(272, 23);
            VersionSelector.TabIndex = 2;
            VersionSelector.Text = "Añadir datos a la versión seleccionada.";
            // 
            // AcceptButton
            // 
            AcceptButton.Location = new Point(59, 138);
            AcceptButton.Name = "AcceptButton";
            AcceptButton.Size = new Size(128, 48);
            AcceptButton.TabIndex = 3;
            AcceptButton.Text = "Aceptar";
            AcceptButton.UseVisualStyleBackColor = true;
            AcceptButton.Click += Accept;
            // 
            // CancelButton
            // 
            CancelButton.Image = Properties.Resources.go_back;
            CancelButton.ImageAlign = ContentAlignment.MiddleLeft;
            CancelButton.Location = new Point(320, 138);
            CancelButton.Name = "CancelButton";
            CancelButton.Padding = new Padding(10, 0, 0, 0);
            CancelButton.Size = new Size(128, 48);
            CancelButton.TabIndex = 4;
            CancelButton.Text = "Cancelar";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += Cancel;
            // 
            // AddToSelectedVersion
            // 
            AddToSelectedVersion.AutoSize = true;
            AddToSelectedVersion.Location = new Point(104, 79);
            AddToSelectedVersion.Name = "AddToSelectedVersion";
            AddToSelectedVersion.Size = new Size(14, 13);
            AddToSelectedVersion.TabIndex = 7;
            AddToSelectedVersion.TabStop = true;
            AddToSelectedVersion.UseVisualStyleBackColor = true;
            AddToSelectedVersion.Click += AddToSelectedVersion_Click;
            // 
            // EraseData
            // 
            EraseData.AutoSize = true;
            EraseData.Location = new Point(104, 104);
            EraseData.Name = "EraseData";
            EraseData.Size = new Size(168, 19);
            EraseData.TabIndex = 8;
            EraseData.TabStop = true;
            EraseData.Text = "Borrar datos con la versión.";
            EraseData.UseVisualStyleBackColor = true;
            EraseData.Click += EraseData_Click;
            // 
            // RemoveVersionOptions
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(496, 217);
            Controls.Add(EraseData);
            Controls.Add(AddToSelectedVersion);
            Controls.Add(CancelButton);
            Controls.Add(AcceptButton);
            Controls.Add(VersionSelector);
            Controls.Add(AddToCurrentVersion);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RemoveVersionOptions";
            ShowInTaskbar = false;
            Text = "¿Que desea hacer con los archivos de la versión?";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private RadioButton AddToCurrentVersion;
        private ComboBox VersionSelector;
        private Button AcceptButton;
        private Button CancelButton;
        private RadioButton AddToSelectedVersion;
        private RadioButton EraseData;
    }
}