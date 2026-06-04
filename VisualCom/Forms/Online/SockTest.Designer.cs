namespace VisualCom.Forms.Online
{
    partial class SockTest
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
            ann_bu = new Button();
            lock_but = new Button();
            unlock_but = new Button();
            cclass_but = new Button();
            eclass_but = new Button();
            SuspendLayout();
            // 
            // ann_bu
            // 
            ann_bu.Location = new Point(69, 47);
            ann_bu.Name = "ann_bu";
            ann_bu.Size = new Size(75, 23);
            ann_bu.TabIndex = 0;
            ann_bu.Text = "ann";
            ann_bu.UseVisualStyleBackColor = true;
            ann_bu.Click += ann_bu_Click;
            // 
            // lock_but
            // 
            lock_but.Location = new Point(69, 76);
            lock_but.Name = "lock_but";
            lock_but.Size = new Size(75, 23);
            lock_but.TabIndex = 1;
            lock_but.Text = "lock";
            lock_but.UseVisualStyleBackColor = true;
            lock_but.Click += lock_but_Click;
            // 
            // unlock_but
            // 
            unlock_but.Location = new Point(150, 76);
            unlock_but.Name = "unlock_but";
            unlock_but.Size = new Size(75, 23);
            unlock_but.TabIndex = 2;
            unlock_but.Text = "unlock";
            unlock_but.UseVisualStyleBackColor = true;
            unlock_but.Click += unlock_but_Click;
            // 
            // cclass_but
            // 
            cclass_but.Location = new Point(69, 105);
            cclass_but.Name = "cclass_but";
            cclass_but.Size = new Size(75, 23);
            cclass_but.TabIndex = 3;
            cclass_but.Text = "c. class";
            cclass_but.UseVisualStyleBackColor = true;
            cclass_but.Click += cclass_but_Click;
            // 
            // eclass_but
            // 
            eclass_but.Location = new Point(150, 105);
            eclass_but.Name = "eclass_but";
            eclass_but.Size = new Size(75, 23);
            eclass_but.TabIndex = 4;
            eclass_but.Text = "e. class";
            eclass_but.UseVisualStyleBackColor = true;
            // 
            // SockTest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(657, 403);
            Controls.Add(eclass_but);
            Controls.Add(cclass_but);
            Controls.Add(unlock_but);
            Controls.Add(lock_but);
            Controls.Add(ann_bu);
            Name = "SockTest";
            Text = "SockTest";
            ResumeLayout(false);
        }

        #endregion

        private Button ann_bu;
        private Button lock_but;
        private Button unlock_but;
        private Button cclass_but;
        private Button eclass_but;
    }
}