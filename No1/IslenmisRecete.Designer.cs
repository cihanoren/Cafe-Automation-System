namespace No1
{
    partial class IslenmisRecete
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
            this.gramtb = new System.Windows.Forms.RichTextBox();
            this.menuaditb = new System.Windows.Forms.RichTextBox();
            this.recetegramitb = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Menu = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.silbtn = new System.Windows.Forms.Button();
            this.cikisbtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gramtb
            // 
            this.gramtb.Location = new System.Drawing.Point(169, 274);
            this.gramtb.Name = "gramtb";
            this.gramtb.Size = new System.Drawing.Size(303, 31);
            this.gramtb.TabIndex = 13;
            this.gramtb.Text = "";
            this.gramtb.TextChanged += new System.EventHandler(this.gramtb_TextChanged);
            this.gramtb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gramtb_KeyPress);
            // 
            // menuaditb
            // 
            this.menuaditb.Location = new System.Drawing.Point(169, 48);
            this.menuaditb.Name = "menuaditb";
            this.menuaditb.Size = new System.Drawing.Size(303, 31);
            this.menuaditb.TabIndex = 10;
            this.menuaditb.Text = "";
            this.menuaditb.TextChanged += new System.EventHandler(this.menuaditb_TextChanged);
            // 
            // recetegramitb
            // 
            this.recetegramitb.Location = new System.Drawing.Point(169, 197);
            this.recetegramitb.Name = "recetegramitb";
            this.recetegramitb.Size = new System.Drawing.Size(303, 31);
            this.recetegramitb.TabIndex = 7;
            this.recetegramitb.Text = "";
            this.recetegramitb.TextChanged += new System.EventHandler(this.recetegramitb_TextChanged);
            this.recetegramitb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.recetegramitb_KeyPress);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(72)))), ((int)(((byte)(19)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(63, 701);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 61);
            this.button1.TabIndex = 1;
            this.button1.Text = "KAYDET";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.kaydet_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(33, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 45);
            this.label5.TabIndex = 4;
            this.label5.Text = "1000G  İÇİN KULLANMLIK :";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(56, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "ÜRÜN ADI :";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(56, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "MENÜ ADI :";
            // 
            // Menu
            // 
            this.Menu.Controls.Add(this.comboBox1);
            this.Menu.Controls.Add(this.gramtb);
            this.Menu.Controls.Add(this.menuaditb);
            this.Menu.Controls.Add(this.recetegramitb);
            this.Menu.Controls.Add(this.label5);
            this.Menu.Controls.Add(this.label6);
            this.Menu.Controls.Add(this.label2);
            this.Menu.Controls.Add(this.label1);
            this.Menu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Menu.Location = new System.Drawing.Point(26, 288);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(493, 354);
            this.Menu.TabIndex = 0;
            this.Menu.TabStop = false;
            this.Menu.Text = "MENÜ";
            this.Menu.Enter += new System.EventHandler(this.Menu_Enter);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(169, 123);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(303, 28);
            this.comboBox1.TabIndex = 14;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(1, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 31);
            this.label6.TabIndex = 3;
            this.label6.Text = "REÇETE GRAMI :";
            // 
            // dataGridView
            // 
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(558, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(585, 1102);
            this.dataGridView.TabIndex = 3;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.silbtn);
            this.panel1.Controls.Add(this.cikisbtn);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.Menu);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(558, 1102);
            this.panel1.TabIndex = 2;
            // 
            // silbtn
            // 
            this.silbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(72)))), ((int)(((byte)(19)))));
            this.silbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.silbtn.ForeColor = System.Drawing.Color.White;
            this.silbtn.Location = new System.Drawing.Point(296, 701);
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
            this.cikisbtn.Location = new System.Drawing.Point(442, 992);
            this.cikisbtn.Name = "cikisbtn";
            this.cikisbtn.Size = new System.Drawing.Size(99, 58);
            this.cikisbtn.TabIndex = 5;
            this.cikisbtn.UseVisualStyleBackColor = true;
            this.cikisbtn.Click += new System.EventHandler(this.cikisbtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::No1.Properties.Resources.no1logo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(558, 158);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // IslenmisRecete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 1102);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "IslenmisRecete";
            this.Text = "IslenmisRecete";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.IslenmisRecete_Load);
            this.Menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox gramtb;
        private System.Windows.Forms.RichTextBox menuaditb;
        private System.Windows.Forms.RichTextBox recetegramitb;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox Menu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button silbtn;
        private System.Windows.Forms.Button cikisbtn;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}