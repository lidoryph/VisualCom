namespace VisualCom.Forms.Editor.TrainWindows
{
    partial class ExportToYolo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportToYolo));
            label1 = new Label();
            VersionSelector = new ComboBox();
            label2 = new Label();
            YOLOName = new TextBox();
            CustomName = new CheckBox();
            ExportButton = new Button();
            CancelButton = new Button();
            label3 = new Label();
            ImagesBar = new TrackBar();
            ImagesNum = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)ImagesBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ImagesNum).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 9);
            label1.Name = "label1";
            label1.Padding = new Padding(10, 0, 10, 0);
            label1.Size = new Size(219, 15);
            label1.TabIndex = 0;
            label1.Text = "Seleccione una versión para exportar";
            // 
            // VersionSelector
            // 
            VersionSelector.FormattingEnabled = true;
            VersionSelector.Location = new Point(11, 27);
            VersionSelector.Name = "VersionSelector";
            VersionSelector.Size = new Size(219, 23);
            VersionSelector.TabIndex = 1;
            VersionSelector.Text = "Selecciona una versión...";
            VersionSelector.SelectedIndexChanged += SetName;
            // 
            // label2
            // 
            label2.Location = new Point(12, 62);
            label2.Name = "label2";
            label2.Padding = new Padding(10, 0, 10, 0);
            label2.Size = new Size(219, 15);
            label2.TabIndex = 2;
            label2.Text = "Nombre del archivo:";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // YOLOName
            // 
            YOLOName.Enabled = false;
            YOLOName.Location = new Point(12, 80);
            YOLOName.Name = "YOLOName";
            YOLOName.ReadOnly = true;
            YOLOName.Size = new Size(216, 23);
            YOLOName.TabIndex = 3;
            // 
            // CustomName
            // 
            CustomName.AutoSize = true;
            CustomName.Location = new Point(46, 109);
            CustomName.Name = "CustomName";
            CustomName.Size = new Size(146, 19);
            CustomName.TabIndex = 4;
            CustomName.Text = "Nombre personalizado";
            CustomName.UseVisualStyleBackColor = true;
            CustomName.CheckedChanged += EnableCustomName;
            // 
            // ExportButton
            // 
            ExportButton.Image = Properties.Resources.export_model;
            ExportButton.ImageAlign = ContentAlignment.MiddleLeft;
            ExportButton.Location = new Point(24, 231);
            ExportButton.Name = "ExportButton";
            ExportButton.Padding = new Padding(10, 0, 0, 0);
            ExportButton.Size = new Size(192, 48);
            ExportButton.TabIndex = 5;
            ExportButton.Text = "Exportar";
            ExportButton.UseVisualStyleBackColor = true;
            ExportButton.Click += Export;
            // 
            // CancelButton
            // 
            CancelButton.Image = Properties.Resources.go_back;
            CancelButton.ImageAlign = ContentAlignment.MiddleLeft;
            CancelButton.Location = new Point(24, 285);
            CancelButton.Name = "CancelButton";
            CancelButton.Padding = new Padding(10, 0, 0, 0);
            CancelButton.Size = new Size(192, 48);
            CancelButton.TabIndex = 6;
            CancelButton.Text = "Cancelar";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += Cancel;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(37, 145);
            label3.Name = "label3";
            label3.Size = new Size(160, 15);
            label3.TabIndex = 8;
            label3.Text = "% de Imagenes para entrenar";
            // 
            // ImagesBar
            // 
            ImagesBar.Location = new Point(11, 163);
            ImagesBar.Maximum = 100;
            ImagesBar.Name = "ImagesBar";
            ImagesBar.Size = new Size(168, 45);
            ImagesBar.TabIndex = 9;
            ImagesBar.TickFrequency = 10;
            ImagesBar.Value = 80;
            ImagesBar.ValueChanged += ChangedBar;
            // 
            // ImagesNum
            // 
            ImagesNum.Location = new Point(185, 163);
            ImagesNum.Name = "ImagesNum";
            ImagesNum.Size = new Size(43, 23);
            ImagesNum.TabIndex = 10;
            ImagesNum.Value = new decimal(new int[] { 80, 0, 0, 0 });
            ImagesNum.ValueChanged += ChangedNumeric;
            // 
            // ExportToYolo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(240, 345);
            Controls.Add(ImagesNum);
            Controls.Add(ImagesBar);
            Controls.Add(label3);
            Controls.Add(CancelButton);
            Controls.Add(ExportButton);
            Controls.Add(CustomName);
            Controls.Add(YOLOName);
            Controls.Add(label2);
            Controls.Add(VersionSelector);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ExportToYolo";
            ShowInTaskbar = false;
            Text = "Exportar a YOLO...";
            ((System.ComponentModel.ISupportInitialize)ImagesBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)ImagesNum).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox VersionSelector;
        private Label label2;
        private TextBox YOLOName;
        private CheckBox CustomName;
        private Button ExportButton;
        private Button CancelButton;
        private Label label3;
        private TrackBar ImagesBar;
        private NumericUpDown ImagesNum;
    }
}