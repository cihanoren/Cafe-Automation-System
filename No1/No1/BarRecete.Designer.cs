namespace No1
{
    partial class BarRecete
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.kaydetbtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Menu = new System.Windows.Forms.GroupBox();
            this.arabtn = new System.Windows.Forms.Button();
            this.recetegramitb = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.menuaditb = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gramtb = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.silbtn = new System.Windows.Forms.Button();
            this.cikisbtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // kaydetbtn
            // 
            this.kaydetbtn.BackColor = System.Drawing.Color.Navy;
            this.kaydetbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kaydetbtn.ForeColor = System.Drawing.Color.White;
            this.kaydetbtn.Location = new System.Drawing.Point(122, 824);
            this.kaydetbtn.Name = "kaydetbtn";
            this.kaydetbtn.Size = new System.Drawing.Size(185, 61);
            this.kaydetbtn.TabIndex = 1;
            this.kaydetbtn.Text = "KAYDET";
            this.kaydetbtn.UseVisualStyleBackColor = false;
            this.kaydetbtn.Click += new System.EventHandler(this.kaydetbtn_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(16, 1005);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 45);
            this.label5.TabIndex = 4;
            this.label5.Text = "1000G  İÇİN KULLANMLIK :";
            this.label5.Visible = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(76, 271);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "ÜRÜN ADI :";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(76, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "MENÜ ADI :";
            // 
            // Menu
            // 
            this.Menu.Controls.Add(this.arabtn);
            this.Menu.Controls.Add(this.recetegramitb);
            this.Menu.Controls.Add(this.textBox2);
            this.Menu.Controls.Add(this.menuaditb);
            this.Menu.Controls.Add(this.comboBox1);
            this.Menu.Controls.Add(this.label6);
            this.Menu.Controls.Add(this.label2);
            this.Menu.Controls.Add(this.label1);
            this.Menu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Menu.ForeColor = System.Drawing.Color.Navy;
            this.Menu.Location = new System.Drawing.Point(61, 328);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(543, 429);
            this.Menu.TabIndex = 0;
            this.Menu.TabStop = false;
            this.Menu.Text = "BAR REÇETE";
            this.Menu.Enter += new System.EventHandler(this.Menu_Enter);
            // 
            // arabtn
            // 
            this.arabtn.BackgroundImage = global::No1.Properties.Resources.Background__1_1;
            this.arabtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.arabtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.arabtn.Location = new System.Drawing.Point(448, 84);
            this.arabtn.Name = "arabtn";
            this.arabtn.Size = new System.Drawing.Size(44, 28);
            this.arabtn.TabIndex = 23;
            this.arabtn.UseVisualStyleBackColor = true;
            this.arabtn.Click += new System.EventHandler(this.arabtn_Click);
            // 
            // recetegramitb
            // 
            this.recetegramitb.Location = new System.Drawing.Point(213, 348);
            this.recetegramitb.Name = "recetegramitb";
            this.recetegramitb.Size = new System.Drawing.Size(281, 28);
            this.recetegramitb.TabIndex = 19;
            this.recetegramitb.TextChanged += new System.EventHandler(this.recetegramitb_TextChanged);
            this.recetegramitb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.recetegramitb_KeyPress);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox2.Location = new System.Drawing.Point(61, 84);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(431, 28);
            this.textBox2.TabIndex = 24;
            // 
            // menuaditb
            // 
            this.menuaditb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.menuaditb.Location = new System.Drawing.Point(213, 184);
            this.menuaditb.Name = "menuaditb";
            this.menuaditb.Size = new System.Drawing.Size(281, 28);
            this.menuaditb.TabIndex = 18;
            this.menuaditb.TextChanged += new System.EventHandler(this.menuaditb_TextChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(213, 271);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(281, 30);
            this.comboBox1.Sorted = true;
            this.comboBox1.TabIndex = 14;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(24, 349);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(182, 31);
            this.label6.TabIndex = 3;
            this.label6.Text = "REÇETE GRAMI :";
            // 
            // gramtb
            // 
            this.gramtb.Location = new System.Drawing.Point(204, 1007);
            this.gramtb.Name = "gramtb";
            this.gramtb.ReadOnly = true;
            this.gramtb.Size = new System.Drawing.Size(281, 22);
            this.gramtb.TabIndex = 20;
            this.gramtb.Visible = false;
            this.gramtb.TextChanged += new System.EventHandler(this.gramtb_TextChanged);
            this.gramtb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.recetegramitb_KeyPress);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(667, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(498, 1102);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.gramtb);
            this.panel1.Controls.Add(this.silbtn);
            this.panel1.Controls.Add(this.cikisbtn);
            this.panel1.Controls.Add(this.kaydetbtn);
            this.panel1.Controls.Add(this.Menu);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(667, 1102);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // silbtn
            // 
            this.silbtn.BackColor = System.Drawing.Color.Navy;
            this.silbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.silbtn.ForeColor = System.Drawing.Color.White;
            this.silbtn.Location = new System.Drawing.Point(362, 824);
            this.silbtn.Name = "silbtn";
            this.silbtn.Size = new System.Drawing.Size(185, 61);
            this.silbtn.TabIndex = 6;
            this.silbtn.Text = "SİL";
            this.silbtn.UseVisualStyleBackColor = false;
            this.silbtn.Click += new System.EventHandler(this.silbtn_Click);
            // 
            // cikisbtn
            // 
            this.cikisbtn.BackgroundImage = global::No1.Properties.Resources.exit_icon_sign_vector_illustration;
            this.cikisbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cikisbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cikisbtn.ForeColor = System.Drawing.Color.White;
            this.cikisbtn.Location = new System.Drawing.Point(558, 1015);
            this.cikisbtn.Name = "cikisbtn";
            this.cikisbtn.Size = new System.Drawing.Size(99, 58);
            this.cikisbtn.TabIndex = 5;
            this.cikisbtn.UseVisualStyleBackColor = false;
            this.cikisbtn.Click += new System.EventHandler(this.cikisbtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::No1.Properties.Resources.YAZILIM_ŞİRKETİ;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(667, 155);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // BarRecete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 1102);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BarRecete";
            this.Text = "BarRecete";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BarRecete_Load);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button kaydetbtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox Menu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button silbtn;
        private System.Windows.Forms.Button cikisbtn;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox gramtb;
        private System.Windows.Forms.TextBox recetegramitb;
        private System.Windows.Forms.TextBox menuaditb;
        private System.Windows.Forms.Button arabtn;
        private System.Windows.Forms.TextBox textBox2;
    }
}