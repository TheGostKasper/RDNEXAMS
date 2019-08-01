namespace StatesExam
{
    partial class Reaction
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLoop = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.pclr6 = new System.Windows.Forms.PictureBox();
            this.pcl5 = new System.Windows.Forms.PictureBox();
            this.pcl4 = new System.Windows.Forms.PictureBox();
            this.pclr3 = new System.Windows.Forms.PictureBox();
            this.pclr2 = new System.Windows.Forms.PictureBox();
            this.pclr1 = new System.Windows.Forms.PictureBox();
            this.btnMainColor = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pclr6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcl5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pclr3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pclr2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pclr1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblLoop);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblTime);
            this.panel1.Controls.Add(this.pclr6);
            this.panel1.Controls.Add(this.pcl5);
            this.panel1.Controls.Add(this.pcl4);
            this.panel1.Controls.Add(this.pclr3);
            this.panel1.Controls.Add(this.pclr2);
            this.panel1.Controls.Add(this.pclr1);
            this.panel1.Controls.Add(this.btnMainColor);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1293, 750);
            this.panel1.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button3.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button3.Location = new System.Drawing.Point(591, 115);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 56);
            this.button3.TabIndex = 47;
            this.button3.Text = "بدأ الاختبار";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(446, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(418, 29);
            this.label3.TabIndex = 46;
            this.label3.Text = "اضغط علي المربع الذي يطابق الشكل في المنتصف ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(198, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 29);
            this.label2.TabIndex = 45;
            this.label2.Text = "الزمن";
            // 
            // lblLoop
            // 
            this.lblLoop.AutoSize = true;
            this.lblLoop.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoop.Location = new System.Drawing.Point(1010, 29);
            this.lblLoop.Name = "lblLoop";
            this.lblLoop.Size = new System.Drawing.Size(26, 29);
            this.lblLoop.TabIndex = 44;
            this.lblLoop.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1069, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 29);
            this.label1.TabIndex = 43;
            this.label1.Text = "رقم المحاولة";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(111, 29);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(26, 29);
            this.lblTime.TabIndex = 42;
            this.lblTime.Text = "0";
            // 
            // pclr6
            // 
            this.pclr6.BackColor = System.Drawing.Color.Green;
            this.pclr6.Location = new System.Drawing.Point(957, 550);
            this.pclr6.Name = "pclr6";
            this.pclr6.Size = new System.Drawing.Size(225, 172);
            this.pclr6.TabIndex = 41;
            this.pclr6.TabStop = false;
            this.pclr6.Click += new System.EventHandler(this.pcl4_Click);
            // 
            // pcl5
            // 
            this.pcl5.BackColor = System.Drawing.Color.Orange;
            this.pcl5.Location = new System.Drawing.Point(957, 324);
            this.pcl5.Name = "pcl5";
            this.pcl5.Size = new System.Drawing.Size(225, 172);
            this.pcl5.TabIndex = 40;
            this.pcl5.TabStop = false;
            this.pcl5.Click += new System.EventHandler(this.pcl4_Click);
            // 
            // pcl4
            // 
            this.pcl4.BackColor = System.Drawing.Color.DarkCyan;
            this.pcl4.Location = new System.Drawing.Point(957, 115);
            this.pcl4.Name = "pcl4";
            this.pcl4.Size = new System.Drawing.Size(225, 172);
            this.pcl4.TabIndex = 39;
            this.pcl4.TabStop = false;
            this.pcl4.Click += new System.EventHandler(this.pcl4_Click);
            // 
            // pclr3
            // 
            this.pclr3.BackColor = System.Drawing.Color.Navy;
            this.pclr3.Location = new System.Drawing.Point(116, 550);
            this.pclr3.Name = "pclr3";
            this.pclr3.Size = new System.Drawing.Size(225, 172);
            this.pclr3.TabIndex = 38;
            this.pclr3.TabStop = false;
            this.pclr3.Click += new System.EventHandler(this.pcl4_Click);
            // 
            // pclr2
            // 
            this.pclr2.BackColor = System.Drawing.Color.Lime;
            this.pclr2.Location = new System.Drawing.Point(116, 324);
            this.pclr2.Name = "pclr2";
            this.pclr2.Size = new System.Drawing.Size(225, 172);
            this.pclr2.TabIndex = 37;
            this.pclr2.TabStop = false;
            this.pclr2.Click += new System.EventHandler(this.pcl4_Click);
            // 
            // pclr1
            // 
            this.pclr1.BackColor = System.Drawing.Color.Orchid;
            this.pclr1.Location = new System.Drawing.Point(116, 115);
            this.pclr1.Name = "pclr1";
            this.pclr1.Size = new System.Drawing.Size(225, 172);
            this.pclr1.TabIndex = 36;
            this.pclr1.TabStop = false;
            this.pclr1.Click += new System.EventHandler(this.pcl4_Click);
            // 
            // btnMainColor
            // 
            this.btnMainColor.Enabled = false;
            this.btnMainColor.Location = new System.Drawing.Point(497, 204);
            this.btnMainColor.Name = "btnMainColor";
            this.btnMainColor.Size = new System.Drawing.Size(329, 315);
            this.btnMainColor.TabIndex = 35;
            this.btnMainColor.UseVisualStyleBackColor = true;
            this.btnMainColor.Click += new System.EventHandler(this.btnMainColor_Click);
            // 
            // Reaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1293, 750);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Name = "Reaction";
            this.Text = "Reaction";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pclr6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcl5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pclr3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pclr2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pclr1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLoop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.PictureBox pclr6;
        private System.Windows.Forms.PictureBox pcl5;
        private System.Windows.Forms.PictureBox pcl4;
        private System.Windows.Forms.PictureBox pclr3;
        private System.Windows.Forms.PictureBox pclr2;
        private System.Windows.Forms.PictureBox pclr1;
        private System.Windows.Forms.Button btnMainColor;
    }
}