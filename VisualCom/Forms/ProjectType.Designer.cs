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
            OIbutton.ForeColor = SystemColors.HighlightText;
            OIbutton.Location = new Point(29, 58);
            OIbutton.Margin = new Padding(3, 2, 3, 2);
            OIbutton.Name = "OIbutton";
            OIbutton.Size = new Size(163, 35);
            OIbutton.TabIndex = 0;
            OIbutton.Text = "Identificación de Objetos";
            OIbutton.UseVisualStyleBackColor = true;
            OIbutton.Click += OIbutton_Click;
            OIbutton.MouseEnter += OIbutton_MouseEnter;
            OIbutton.MouseLeave += OIbutton_MouseLeave;
            // 
            // Cbutton
            // 
            Cbutton.ForeColor = SystemColors.HighlightText;
            Cbutton.Location = new Point(242, 58);
            Cbutton.Margin = new Padding(3, 2, 3, 2);
            Cbutton.Name = "Cbutton";
            Cbutton.Size = new Size(163, 35);
            Cbutton.TabIndex = 1;
            Cbutton.Text = "Clasificación";
            Cbutton.UseVisualStyleBackColor = true;
            Cbutton.Click += Cbutton_Click;
            Cbutton.MouseEnter += Cbutton_MouseEnter;
            Cbutton.MouseLeave += Cbutton_MouseLeave;
            // 
            // Label
            // 
            Label.AutoSize = true;
            Label.ForeColor = SystemColors.HighlightText;
            Label.Location = new Point(111, 21);
            Label.Name = "Label";
            Label.Size = new Size(199, 15);
            Label.TabIndex = 2;
            Label.Text = "¿Que tipo de proyecto quieres crear?";
            // 
            // ProjectType
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(63, 62, 62);
            ClientSize = new Size(434, 115);
            Controls.Add(Label);
            Controls.Add(Cbutton);
            Controls.Add(OIbutton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MaximumSize = new Size(450, 154);
            MinimizeBox = false;
            MinimumSize = new Size(450, 154);
            Name = "ProjectType";
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Seleccione el tipo de proyecto:";
            FormClosing += ProjectType_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button OIbutton;
        private Button Cbutton;
        private Label Label;
    }
}