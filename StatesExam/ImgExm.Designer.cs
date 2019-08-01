namespace StatesExam
{
    partial class ImgExm
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.eyeRem = new System.Windows.Forms.PictureBox();
            this.ansPanel = new System.Windows.Forms.Panel();
            this.btnMute = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblExmTxt = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblShortCut = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblexam = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eyeRem)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.eyeRem);
            this.panel1.Controls.Add(this.ansPanel);
            this.panel1.Controls.Add(this.btnMute);
            this.panel1.Controls.Add(this.btnPlay);
            this.panel1.Controls.Add(this.btnPause);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.lblShortCut);
            this.panel1.Controls.Add(this.lblDuration);
            this.panel1.Controls.Add(this.lblexam);
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Controls.Add(this.btnPre);
            this.panel1.Location = new System.Drawing.Point(27, -25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1376, 834);
            this.panel1.TabIndex = 1;
            // 
            // eyeRem
            // 
            this.eyeRem.Image = global::StatesExam.Properties.Resources.Capture;
            this.eyeRem.Location = new System.Drawing.Point(3, 26);
            this.eyeRem.Name = "eyeRem";
            this.eyeRem.Size = new System.Drawing.Size(1370, 808);
            this.eyeRem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.eyeRem.TabIndex = 2;
            this.eyeRem.TabStop = false;
            this.eyeRem.Visible = false;
            // 
            // ansPanel
            // 
            this.ansPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ansPanel.Location = new System.Drawing.Point(115, 379);
            this.ansPanel.Name = "ansPanel";
            this.ansPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ansPanel.Size = new System.Drawing.Size(1178, 340);
            this.ansPanel.TabIndex = 18;
            // 
            // btnMute
            // 
            this.btnMute.BackColor = System.Drawing.Color.Brown;
            this.btnMute.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.btnMute.ForeColor = System.Drawing.SystemColors.Control;
            this.btnMute.Location = new System.Drawing.Point(763, 746);
            this.btnMute.Name = "btnMute";
            this.btnMute.Size = new System.Drawing.Size(152, 70);
            this.btnMute.TabIndex = 50;
            this.btnMute.Text = "كتم الصوت";
            this.btnMute.UseVisualStyleBackColor = false;
            this.btnMute.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.FloralWhite;
            this.btnPlay.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.btnPlay.Location = new System.Drawing.Point(524, 746);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(98, 70);
            this.btnPlay.TabIndex = 21;
            this.btnPlay.Text = "تشغيل";
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnPause
            // 
            this.btnPause.BackColor = System.Drawing.Color.FloralWhite;
            this.btnPause.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.btnPause.Location = new System.Drawing.Point(637, 746);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(98, 70);
            this.btnPause.TabIndex = 20;
            this.btnPause.Text = "ايقاف";
            this.btnPause.UseVisualStyleBackColor = false;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblExmTxt);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(115, 79);
            this.panel2.Name = "panel2";
            this.panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel2.Size = new System.Drawing.Size(1178, 309);
            this.panel2.TabIndex = 17;
            // 
            // lblExmTxt
            // 
            this.lblExmTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExmTxt.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExmTxt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblExmTxt.Location = new System.Drawing.Point(27, 42);
            this.lblExmTxt.MinimumSize = new System.Drawing.Size(1100, 60);
            this.lblExmTxt.Name = "lblExmTxt";
            this.lblExmTxt.Size = new System.Drawing.Size(1100, 206);
            this.lblExmTxt.TabIndex = 6;
            this.lblExmTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblExmTxt.UseCompatibleTextRendering = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(27, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1119, 280);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lblShortCut
            // 
            this.lblShortCut.AutoSize = true;
            this.lblShortCut.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lblShortCut.Location = new System.Drawing.Point(1142, 38);
            this.lblShortCut.Name = "lblShortCut";
            this.lblShortCut.Size = new System.Drawing.Size(112, 29);
            this.lblShortCut.TabIndex = 16;
            this.lblShortCut.Text = "Shortcut";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lblDuration.Location = new System.Drawing.Point(150, 38);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(112, 29);
            this.lblDuration.TabIndex = 15;
            this.lblDuration.Text = "Duration";
            // 
            // lblexam
            // 
            this.lblexam.AutoSize = true;
            this.lblexam.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lblexam.Location = new System.Drawing.Point(610, 38);
            this.lblexam.Name = "lblexam";
            this.lblexam.Size = new System.Drawing.Size(147, 29);
            this.lblexam.TabIndex = 14;
            this.lblexam.Text = "Exam Name";
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FloralWhite;
            this.btnNext.Enabled = false;
            this.btnNext.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.btnNext.ForeColor = System.Drawing.Color.Maroon;
            this.btnNext.Location = new System.Drawing.Point(113, 742);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(290, 78);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "التالي";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPre
            // 
            this.btnPre.BackColor = System.Drawing.Color.FloralWhite;
            this.btnPre.Enabled = false;
            this.btnPre.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.btnPre.ForeColor = System.Drawing.Color.Maroon;
            this.btnPre.Location = new System.Drawing.Point(1001, 740);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(290, 78);
            this.btnPre.TabIndex = 12;
            this.btnPre.Text = "السابق";
            this.btnPre.UseVisualStyleBackColor = false;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // ImgExm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1427, 812);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImgExm";
            this.Text = "ImgExm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ImgExm_KeyUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eyeRem)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMute;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblShortCut;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblexam;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel ansPanel;
        private System.Windows.Forms.Label lblExmTxt;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.PictureBox eyeRem;


    }
}