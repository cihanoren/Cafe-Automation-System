namespace No1
{
    partial class Urunler
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.silbtn = new System.Windows.Forms.Button();
            this.alisfiyatitb = new System.Windows.Forms.RichTextBox();
            this.urunaditb = new System.Windows.Forms.RichTextBox();
            this.kaydet = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Cikis = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.Cikis);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(552, 655);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.silbtn);
            this.groupBox1.Controls.Add(this.alisfiyatitb);
            this.groupBox1.Controls.Add(this.urunaditb);
            this.groupBox1.Controls.Add(this.kaydet);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(72)))), ((int)(((byte)(19)))));
            this.groupBox1.Location = new System.Drawing.Point(60, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 339);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ÜRÜNLER";
            // 
            // silbtn
            // 
            this.silbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(72)))), ((int)(((byte)(19)))));
            this.silbtn.ForeColor = System.Drawing.Color.White;
            this.silbtn.Location = new System.Drawing.Point(208, 236);
            this.silbtn.Name = "silbtn";
            this.silbtn.Size = new System.Drawing.Size(129, 57);
            this.silbtn.TabIndex = 17;
            this.silbtn.Text = "SİL";
            this.silbtn.UseVisualStyleBackColor = false;
            this.silbtn.Click += new System.EventHandler(this.silbtn_Click_1);
            // 
            // alisfiyatitb
            // 
            this.alisfiyatitb.Location = new System.Drawing.Point(141, 145);
            this.alisfiyatitb.Name = "alisfiyatitb";
            this.alisfiyatitb.Size = new System.Drawing.Size(196, 33);
            this.alisfiyatitb.TabIndex = 16;
            this.alisfiyatitb.Text = "";
            this.alisfiyatitb.TextChanged += new System.EventHandler(this.alisfiyatitb_TextChanged);
            this.alisfiyatitb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.alisfiyatitb_KeyPress_1);
            // 
            // urunaditb
            // 
            this.urunaditb.Location = new System.Drawing.Point(141, 80);
            this.urunaditb.Name = "urunaditb";
            this.urunaditb.Size = new System.Drawing.Size(196, 33);
            this.urunaditb.TabIndex = 15;
            this.urunaditb.Text = "";
            this.urunaditb.TextChanged += new System.EventHandler(this.urunaditb_TextChanged);
            // 
            // kaydet
            // 
            this.kaydet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(72)))), ((int)(((byte)(19)))));
            this.kaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kaydet.ForeColor = System.Drawing.Color.White;
            this.kaydet.Location = new System.Drawing.Point(40, 235);
            this.kaydet.Name = "kaydet";
            this.kaydet.Size = new System.Drawing.Size(150, 61);
            this.kaydet.TabIndex = 14;
            this.kaydet.Text = "KAYDET";
            this.kaydet.UseVisualStyleBackColor = false;
            this.kaydet.Click += new System.EventHandler(this.kaydet_Click_1);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(9, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 33);
            this.label2.TabIndex = 13;
            this.label2.Text = "ALIŞ FİYATI :";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(21, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 33);
            this.label1.TabIndex = 12;
            this.label1.Text = "ÜRÜN ADI :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(552, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(614, 655);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged_1);
            // 
            // Cikis
            // 
            this.Cikis.BackgroundImage = global::No1.Properties.Resources.exit_icon_sign_vector_illustration;
            this.Cikis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Cikis.Location = new System.Drawing.Point(338, 570);
            this.Cikis.Name = "Cikis";
            this.Cikis.Size = new System.Drawing.Size(102, 59);
            this.Cikis.TabIndex = 13;
            this.Cikis.UseVisualStyleBackColor = true;
            this.Cikis.Click += new System.EventHandler(this.Cikis_Click_1);
            // 
            // Urunler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 655);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Urunler";
            this.Text = "Urunler";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Urunler_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button silbtn;
        private System.Windows.Forms.RichTextBox alisfiyatitb;
        private System.Windows.Forms.RichTextBox urunaditb;
        private System.Windows.Forms.Button kaydet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Cikis;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}