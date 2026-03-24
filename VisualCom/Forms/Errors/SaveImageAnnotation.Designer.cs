namespace VisualCom.Forms.Errors
{
    partial class SaveImageAnnotation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveImageAnnotation));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SaveNoteButton = new Button();
            CancelButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F);
            label1.Location = new Point(202, 9);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 0;
            label1.Text = "¡Cuidado!";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(131, 44);
            label2.Name = "label2";
            label2.Size = new Size(251, 15);
            label2.TabIndex = 1;
            label2.Text = "No ha guardado las anotaciones de la imagen.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(174, 69);
            label3.Name = "label3";
            label3.Size = new Size(139, 15);
            label3.TabIndex = 2;
            label3.Text = "¿Desea guardarlas ahora?";
            // 
            // SaveNoteButton
            // 
            SaveNoteButton.Location = new Point(174, 103);
            SaveNoteButton.Name = "SaveNoteButton";
            SaveNoteButton.Size = new Size(128, 48);
            SaveNoteButton.TabIndex = 3;
            SaveNoteButton.Text = "Guardar";
            SaveNoteButton.UseVisualStyleBackColor = true;
            SaveNoteButton.Click += SaveAnnotation;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(202, 170);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(64, 24);
            CancelButton.TabIndex = 4;
            CancelButton.Text = "Descartar";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += DiscardAnnotation;
            // 
            // SaveImageAnnotation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(496, 217);
            Controls.Add(CancelButton);
            Controls.Add(SaveNoteButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SaveImageAnnotation";
            ShowInTaskbar = false;
            Text = "¿Quieres guardar las anotaciones de la imagen?";
            FormClosed += CloseForm;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button SaveNoteButton;
        private Button CancelButton;
    }
}