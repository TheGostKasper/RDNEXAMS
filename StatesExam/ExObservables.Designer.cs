namespace StatesExam
{
    partial class ExObservables
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFinishedExms = new System.Windows.Forms.Button();
            this.btnInterview = new System.Windows.Forms.Button();
            this.pcf = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.btnFinishedExms);
            this.panel1.Controls.Add(this.btnInterview);
            this.panel1.Controls.Add(this.pcf);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1224, 805);
            this.panel1.TabIndex = 0;
            // 
            // btnFinishedExms
            // 
            this.btnFinishedExms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnFinishedExms.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinishedExms.Location = new System.Drawing.Point(750, 489);
            this.btnFinishedExms.Name = "btnFinishedExms";
            this.btnFinishedExms.Size = new System.Drawing.Size(437, 55);
            this.btnFinishedExms.TabIndex = 70;
            this.btnFinishedExms.Text = "عرض من لم ينهوا الاختبارات النظرية";
            this.btnFinishedExms.UseVisualStyleBackColor = false;
            this.btnFinishedExms.Click += new System.EventHandler(this.btnFinishedExms_Click);
            // 
            // btnInterview
            // 
            this.btnInterview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnInterview.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInterview.Location = new System.Drawing.Point(750, 402);
            this.btnInterview.Name = "btnInterview";
            this.btnInterview.Size = new System.Drawing.Size(437, 55);
            this.btnInterview.TabIndex = 69;
            this.btnInterview.Text = "عرض من لم يتم عمل المقابلة الشخصية معهم";
            this.btnInterview.UseVisualStyleBackColor = false;
            this.btnInterview.Click += new System.EventHandler(this.btnInterview_Click);
            // 
            // pcf
            // 
            this.pcf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.pcf.Image = global::StatesExam.Properties.Resources.logo2;
            this.pcf.InitialImage = null;
            this.pcf.Location = new System.Drawing.Point(750, 9);
            this.pcf.Name = "pcf";
            this.pcf.Size = new System.Drawing.Size(442, 355);
            this.pcf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcf.TabIndex = 68;
            this.pcf.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 9);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(688, 793);
            this.dataGridView1.TabIndex = 60;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // ExObservables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1231, 807);
            this.Controls.Add(this.panel1);
            this.Name = "ExObservables";
            this.Text = "ExObservables";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pcf;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnFinishedExms;
        private System.Windows.Forms.Button btnInterview;

    }
}