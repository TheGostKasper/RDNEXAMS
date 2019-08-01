namespace StatesExam
{
    partial class LoadingPage
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
            this.mnuAuth = new System.Windows.Forms.MenuStrip();
            this.exeMR = new System.Windows.Forms.ToolStripMenuItem();
            this.observableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assignerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exmsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.intvr = new System.Windows.Forms.ToolStripMenuItem();
            this.newINtv = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mnuAuth.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuAuth
            // 
            this.mnuAuth.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exeMR,
            this.intvr});
            this.mnuAuth.Location = new System.Drawing.Point(0, 0);
            this.mnuAuth.Name = "mnuAuth";
            this.mnuAuth.Size = new System.Drawing.Size(656, 24);
            this.mnuAuth.TabIndex = 2;
            this.mnuAuth.Text = "menuStrip1";
            // 
            // exeMR
            // 
            this.exeMR.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.observableToolStripMenuItem,
            this.assignerToolStripMenuItem,
            this.exmsToolStripMenuItem});
            this.exeMR.Name = "exeMR";
            this.exeMR.Size = new System.Drawing.Size(65, 20);
            this.exeMR.Text = "الاختبارات";
            // 
            // observableToolStripMenuItem
            // 
            this.observableToolStripMenuItem.Name = "observableToolStripMenuItem";
            this.observableToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.observableToolStripMenuItem.Text = "المعمل";
            this.observableToolStripMenuItem.Click += new System.EventHandler(this.observableToolStripMenuItem_Click);
            // 
            // assignerToolStripMenuItem
            // 
            this.assignerToolStripMenuItem.Name = "assignerToolStripMenuItem";
            this.assignerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.assignerToolStripMenuItem.Text = "ادخال البيانات";
            this.assignerToolStripMenuItem.Click += new System.EventHandler(this.assignerToolStripMenuItem_Click);
            // 
            // exmsToolStripMenuItem
            // 
            this.exmsToolStripMenuItem.Name = "exmsToolStripMenuItem";
            this.exmsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exmsToolStripMenuItem.Text = "الاختبارات";
            this.exmsToolStripMenuItem.Click += new System.EventHandler(this.exmsToolStripMenuItem_Click);
            // 
            // intvr
            // 
            this.intvr.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newINtv});
            this.intvr.Name = "intvr";
            this.intvr.Size = new System.Drawing.Size(105, 20);
            this.intvr.Text = "المقابلة الشخصية";
            // 
            // newINtv
            // 
            this.newINtv.Name = "newINtv";
            this.newINtv.Size = new System.Drawing.Size(178, 22);
            this.newINtv.Text = "مقابلة شخصية جديدة";
            this.newINtv.Click += new System.EventHandler(this.newINtv_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(656, 693);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(47, 552);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(520, 32);
            this.label1.TabIndex = 6;
            this.label1.Text = "تحت اشراف فرع الانتقاء والتوجيه - هيئة التنظيم والادارة";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.SystemColors.Control;
            this.btnStart.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.btnStart.ForeColor = System.Drawing.Color.Maroon;
            this.btnStart.Location = new System.Drawing.Point(225, 611);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(141, 60);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "ادخل البيانات";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::StatesExam.Properties.Resources.logo2;
            this.pictureBox1.Location = new System.Drawing.Point(15, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(603, 518);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // LoadingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(656, 718);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mnuAuth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.mnuAuth;
            this.Name = "LoadingPage";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "LoadingPage";
            this.Load += new System.EventHandler(this.LoadingPage_Load);
            this.mnuAuth.ResumeLayout(false);
            this.mnuAuth.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuAuth;
        private System.Windows.Forms.ToolStripMenuItem exeMR;
        private System.Windows.Forms.ToolStripMenuItem observableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assignerToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem intvr;
        private System.Windows.Forms.ToolStripMenuItem newINtv;
        private System.Windows.Forms.ToolStripMenuItem exmsToolStripMenuItem;
    }
}