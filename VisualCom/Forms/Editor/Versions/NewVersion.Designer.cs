namespace VisualCom.Forms.Editor.Versions
{
    partial class NewVersion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewVersion));
            FirstOctave = new TextBox();
            SecondOctave = new TextBox();
            ThirdOctave = new TextBox();
            VersionSuffix = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            DateTimePicker = new DateTimePicker();
            label4 = new Label();
            CreateVersionButton = new Button();
            CancelButton = new Button();
            label5 = new Label();
            SuspendLayout();
            // 
            // FirstOctave
            // 
            FirstOctave.Location = new Point(53, 48);
            FirstOctave.MaxLength = 3;
            FirstOctave.Name = "FirstOctave";
            FirstOctave.Size = new Size(64, 23);
            FirstOctave.TabIndex = 0;
            FirstOctave.TextAlign = HorizontalAlignment.Right;
            // 
            // SecondOctave
            // 
            SecondOctave.Location = new Point(139, 48);
            SecondOctave.MaxLength = 3;
            SecondOctave.Name = "SecondOctave";
            SecondOctave.Size = new Size(64, 23);
            SecondOctave.TabIndex = 2;
            SecondOctave.TextAlign = HorizontalAlignment.Right;
            // 
            // ThirdOctave
            // 
            ThirdOctave.Location = new Point(225, 48);
            ThirdOctave.MaxLength = 3;
            ThirdOctave.Name = "ThirdOctave";
            ThirdOctave.Size = new Size(64, 23);
            ThirdOctave.TabIndex = 4;
            ThirdOctave.TextAlign = HorizontalAlignment.Right;
            // 
            // VersionSuffix
            // 
            VersionSuffix.Enabled = false;
            VersionSuffix.Location = new Point(313, 48);
            VersionSuffix.Name = "VersionSuffix";
            VersionSuffix.ReadOnly = true;
            VersionSuffix.Size = new Size(128, 23);
            VersionSuffix.TabIndex = 6;
            VersionSuffix.TextAlign = HorizontalAlignment.Right;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(123, 56);
            label1.Name = "label1";
            label1.Size = new Size(10, 15);
            label1.TabIndex = 1;
            label1.Text = ".";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(209, 56);
            label2.Name = "label2";
            label2.Size = new Size(10, 15);
            label2.TabIndex = 3;
            label2.Text = ".";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(295, 53);
            label3.Name = "label3";
            label3.Size = new Size(12, 15);
            label3.TabIndex = 5;
            label3.Text = "-";
            // 
            // DateTimePicker
            // 
            DateTimePicker.Enabled = false;
            DateTimePicker.Location = new Point(209, 77);
            DateTimePicker.Name = "DateTimePicker";
            DateTimePicker.Size = new Size(232, 23);
            DateTimePicker.TabIndex = 8;
            DateTimePicker.Value = new DateTime(2026, 3, 20, 15, 37, 2, 0);
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(96, 81);
            label4.Name = "label4";
            label4.Size = new Size(107, 15);
            label4.TabIndex = 7;
            label4.Text = "Fecha de Creación:";
            // 
            // CreateVersionButton
            // 
            CreateVersionButton.Image = Properties.Resources.new_version;
            CreateVersionButton.ImageAlign = ContentAlignment.MiddleLeft;
            CreateVersionButton.Location = new Point(53, 114);
            CreateVersionButton.Name = "CreateVersionButton";
            CreateVersionButton.Padding = new Padding(10, 0, 0, 0);
            CreateVersionButton.Size = new Size(160, 32);
            CreateVersionButton.TabIndex = 9;
            CreateVersionButton.Text = "Crear Versión";
            CreateVersionButton.UseVisualStyleBackColor = true;
            CreateVersionButton.Click += CreateVersion;
            // 
            // CancelButton
            // 
            CancelButton.Image = Properties.Resources.go_back;
            CancelButton.ImageAlign = ContentAlignment.MiddleLeft;
            CancelButton.Location = new Point(281, 114);
            CancelButton.Name = "CancelButton";
            CancelButton.Padding = new Padding(10, 0, 0, 0);
            CancelButton.Size = new Size(160, 32);
            CancelButton.TabIndex = 10;
            CancelButton.Text = "Cancelar";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += Cancel;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(191, 9);
            label5.Name = "label5";
            label5.Size = new Size(98, 15);
            label5.TabIndex = 11;
            label5.Text = "Crea una versión:";
            // 
            // NewVersion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(496, 153);
            Controls.Add(label5);
            Controls.Add(CancelButton);
            Controls.Add(CreateVersionButton);
            Controls.Add(label4);
            Controls.Add(DateTimePicker);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(VersionSuffix);
            Controls.Add(ThirdOctave);
            Controls.Add(SecondOctave);
            Controls.Add(FirstOctave);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NewVersion";
            ShowInTaskbar = false;
            Text = "Nueva versión";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox FirstOctave;
        private TextBox SecondOctave;
        private TextBox ThirdOctave;
        private TextBox VersionSuffix;
        private Label label1;
        private Label label2;
        private Label label3;
        private DateTimePicker DateTimePicker;
        private Label label4;
        private Button CreateVersionButton;
        private Button CancelButton;
        private Label label5;
    }
}