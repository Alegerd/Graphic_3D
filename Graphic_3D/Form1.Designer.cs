namespace Graphic_3D
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.GUIpanelBtn = new System.Windows.Forms.Button();
            this.GUIpanel = new System.Windows.Forms.Panel();
            this.ElipsoidRB = new System.Windows.Forms.RadioButton();
            this.BuildBtn = new System.Windows.Forms.Button();
            this.CilinderRB = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.GUIpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pictureBox1.Location = new System.Drawing.Point(-1, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(888, 465);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // GUIpanelBtn
            // 
            this.GUIpanelBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.GUIpanelBtn.Location = new System.Drawing.Point(849, 195);
            this.GUIpanelBtn.Name = "GUIpanelBtn";
            this.GUIpanelBtn.Size = new System.Drawing.Size(38, 60);
            this.GUIpanelBtn.TabIndex = 1;
            this.GUIpanelBtn.Text = "<";
            this.GUIpanelBtn.UseVisualStyleBackColor = false;
            this.GUIpanelBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // GUIpanel
            // 
            this.GUIpanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.GUIpanel.Controls.Add(this.ElipsoidRB);
            this.GUIpanel.Controls.Add(this.BuildBtn);
            this.GUIpanel.Controls.Add(this.CilinderRB);
            this.GUIpanel.Location = new System.Drawing.Point(687, -2);
            this.GUIpanel.Name = "GUIpanel";
            this.GUIpanel.Size = new System.Drawing.Size(200, 465);
            this.GUIpanel.TabIndex = 2;
            // 
            // ElipsoidRB
            // 
            this.ElipsoidRB.AutoSize = true;
            this.ElipsoidRB.Location = new System.Drawing.Point(18, 38);
            this.ElipsoidRB.Name = "ElipsoidRB";
            this.ElipsoidRB.Size = new System.Drawing.Size(74, 17);
            this.ElipsoidRB.TabIndex = 2;
            this.ElipsoidRB.TabStop = true;
            this.ElipsoidRB.Text = "Элипсоид";
            this.ElipsoidRB.UseVisualStyleBackColor = true;
            // 
            // BuildBtn
            // 
            this.BuildBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BuildBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.BuildBtn.Location = new System.Drawing.Point(12, 399);
            this.BuildBtn.Name = "BuildBtn";
            this.BuildBtn.Size = new System.Drawing.Size(171, 54);
            this.BuildBtn.TabIndex = 1;
            this.BuildBtn.Text = "Построить";
            this.BuildBtn.UseVisualStyleBackColor = false;
            this.BuildBtn.Click += new System.EventHandler(this.BuildBtn_Click);
            // 
            // CilinderRB
            // 
            this.CilinderRB.AutoSize = true;
            this.CilinderRB.Location = new System.Drawing.Point(18, 14);
            this.CilinderRB.Name = "CilinderRB";
            this.CilinderRB.Size = new System.Drawing.Size(69, 17);
            this.CilinderRB.TabIndex = 0;
            this.CilinderRB.TabStop = true;
            this.CilinderRB.Text = "Цилиндр";
            this.CilinderRB.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 463);
            this.Controls.Add(this.GUIpanel);
            this.Controls.Add(this.GUIpanelBtn);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Graphic_3D";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.GUIpanel.ResumeLayout(false);
            this.GUIpanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button GUIpanelBtn;
        private System.Windows.Forms.Panel GUIpanel;
        private System.Windows.Forms.RadioButton CilinderRB;
        private System.Windows.Forms.Button BuildBtn;
        private System.Windows.Forms.RadioButton ElipsoidRB;
    }
}

