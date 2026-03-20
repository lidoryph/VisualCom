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
            discard = new Button();
            save = new Button();
            cancel = new Button();
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
            // discard
            // 
            discard.Image = Properties.Resources.exit;
            discard.ImageAlign = ContentAlignment.MiddleLeft;
            discard.Location = new Point(153, 129);
            discard.Name = "discard";
            discard.Padding = new Padding(10, 0, 0, 0);
            discard.Size = new Size(206, 23);
            discard.TabIndex = 1;
            discard.Text = "Descartar Cambios";
            discard.UseVisualStyleBackColor = true;
            discard.Click += discardChanges;
            // 
            // save
            // 
            save.Image = Properties.Resources.save_document;
            save.ImageAlign = ContentAlignment.MiddleLeft;
            save.Location = new Point(153, 80);
            save.Name = "save";
            save.Padding = new Padding(10, 0, 0, 0);
            save.Size = new Size(206, 43);
            save.TabIndex = 2;
            save.Text = "Guardar Cambios";
            save.UseVisualStyleBackColor = true;
            save.Click += writeChanges;
            // 
            // cancel
            // 
            cancel.Image = Properties.Resources.go_back;
            cancel.ImageAlign = ContentAlignment.MiddleLeft;
            cancel.Location = new Point(153, 158);
            cancel.Name = "cancel";
            cancel.Padding = new Padding(10, 0, 0, 0);
            cancel.Size = new Size(206, 23);
            cancel.TabIndex = 3;
            cancel.Text = "Cancelar y Volver";
            cancel.UseVisualStyleBackColor = true;
            cancel.Click += returnback;
            // 
            // ExitWithoutSave
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(496, 217);
            ControlBox = false;
            Controls.Add(cancel);
            Controls.Add(save);
            Controls.Add(discard);
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
        private Button discard;
        private Button save;
        private Button cancel;
    }
}