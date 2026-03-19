namespace VisualCom.Forms.Editor.TrainWindows
{
    partial class HelpTrain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpTrain));
            label1 = new Label();
            comboBox1 = new ComboBox();
            trackBar1 = new TrackBar();
            numericUpDown1 = new NumericUpDown();
            label2 = new Label();
            numericUpDown2 = new NumericUpDown();
            trackBar2 = new TrackBar();
            label3 = new Label();
            numericUpDown3 = new NumericUpDown();
            trackBar3 = new TrackBar();
            label4 = new Label();
            comboBox2 = new ComboBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 40);
            label1.Name = "label1";
            label1.Size = new Size(329, 30);
            label1.TabIndex = 0;
            label1.Text = "Versiones: Escoge la version que deseas usar para tu modelo, \r\nse almacenan en 'versions' y las generas en el menú Proyecto";
            // 
            // comboBox1
            // 
            comboBox1.Enabled = false;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Versiones" });
            comboBox1.Location = new Point(12, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(344, 23);
            comboBox1.TabIndex = 1;
            comboBox1.Text = "Versiones";
            // 
            // trackBar1
            // 
            trackBar1.Enabled = false;
            trackBar1.Location = new Point(12, 89);
            trackBar1.Maximum = 100;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(284, 45);
            trackBar1.TabIndex = 3;
            trackBar1.TickFrequency = 10;
            trackBar1.Value = 10;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Enabled = false;
            numericUpDown1.Location = new Point(302, 89);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.ReadOnly = true;
            numericUpDown1.Size = new Size(39, 23);
            numericUpDown1.TabIndex = 4;
            numericUpDown1.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 124);
            label2.Name = "label2";
            label2.Size = new Size(331, 45);
            label2.TabIndex = 5;
            label2.Text = "Ciclos: La cantidad de veces que el modelo ve las imagenes,\r\nno es bueno que esté muy alto ya que entonces memoriza las\r\nimagenes en lugar de los patrones\r\n";
            // 
            // numericUpDown2
            // 
            numericUpDown2.Enabled = false;
            numericUpDown2.Location = new Point(302, 182);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.ReadOnly = true;
            numericUpDown2.Size = new Size(39, 23);
            numericUpDown2.TabIndex = 7;
            numericUpDown2.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // trackBar2
            // 
            trackBar2.Enabled = false;
            trackBar2.Location = new Point(12, 182);
            trackBar2.Maximum = 100;
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(284, 45);
            trackBar2.TabIndex = 6;
            trackBar2.TickFrequency = 10;
            trackBar2.Value = 50;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 217);
            label3.Name = "label3";
            label3.Size = new Size(345, 45);
            label3.TabIndex = 8;
            label3.Text = "Corrección: Son las veces que se corrije el modelo a si mismo,\r\nmuy alto y todo lo que aprende esta mal, muy bajo y piensa que\r\ntodo esta bien.";
            // 
            // numericUpDown3
            // 
            numericUpDown3.Enabled = false;
            numericUpDown3.Location = new Point(302, 274);
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.ReadOnly = true;
            numericUpDown3.Size = new Size(39, 23);
            numericUpDown3.TabIndex = 10;
            numericUpDown3.Value = new decimal(new int[] { 16, 0, 0, 0 });
            // 
            // trackBar3
            // 
            trackBar3.Enabled = false;
            trackBar3.Location = new Point(12, 274);
            trackBar3.Maximum = 100;
            trackBar3.Name = "trackBar3";
            trackBar3.Size = new Size(284, 45);
            trackBar3.TabIndex = 9;
            trackBar3.TickFrequency = 10;
            trackBar3.Value = 16;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 309);
            label4.Name = "label4";
            label4.Size = new Size(341, 30);
            label4.TabIndex = 11;
            label4.Text = "Imagenes a Mostrar: Son las imagenes que puede ver a la vez \r\nel modelo, requiere de mucha memoria RAM y en casos VRAM.";
            // 
            // comboBox2
            // 
            comboBox2.Enabled = false;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Versiones" });
            comboBox2.Location = new Point(12, 357);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(344, 23);
            comboBox2.TabIndex = 12;
            comboBox2.Text = "Dispositivo a Usar";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 392);
            label5.Name = "label5";
            label5.Size = new Size(316, 30);
            label5.TabIndex = 13;
            label5.Text = "Dispositivo a Usar: Es la tarjeta grafica que se va a usar para\r\nentrenar al modelo.";
            // 
            // HelpTrain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(368, 473);
            Controls.Add(label5);
            Controls.Add(comboBox2);
            Controls.Add(label4);
            Controls.Add(numericUpDown3);
            Controls.Add(trackBar3);
            Controls.Add(label3);
            Controls.Add(numericUpDown2);
            Controls.Add(trackBar2);
            Controls.Add(label2);
            Controls.Add(numericUpDown1);
            Controls.Add(trackBar1);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "HelpTrain";
            ShowInTaskbar = false;
            Text = "Ayuda en el entrenamiento de modelos";
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboBox1;
        private TrackBar trackBar1;
        private NumericUpDown numericUpDown1;
        private Label label2;
        private NumericUpDown numericUpDown2;
        private TrackBar trackBar2;
        private Label label3;
        private NumericUpDown numericUpDown3;
        private TrackBar trackBar3;
        private Label label4;
        private ComboBox comboBox2;
        private Label label5;
    }
}