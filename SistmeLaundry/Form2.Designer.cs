namespace SistmeLaundry
{
    partial class FormAdmin
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
            this.txtk = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtb = new System.Windows.Forms.TextBox();
            this.txth = new System.Windows.Forms.TextBox();
            this.txts = new System.Windows.Forms.TextBox();
            this.txtkp = new System.Windows.Forms.TextBox();
            this.dtmt = new System.Windows.Forms.DateTimePicker();
            this.btnme = new System.Windows.Forms.Button();
            this.btned = new System.Windows.Forms.Button();
            this.btnha = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtp = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtk
            // 
            this.txtk.Location = new System.Drawing.Point(337, 94);
            this.txtk.Name = "txtk";
            this.txtk.Size = new System.Drawing.Size(100, 22);
            this.txtk.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nama Pelanggan";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(125, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nama Kasir";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(125, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Berat";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(128, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Harga";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(125, 263);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Status Laundry";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(125, 303);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Tanggal";
            // 
            // txtb
            // 
            this.txtb.Location = new System.Drawing.Point(337, 151);
            this.txtb.Name = "txtb";
            this.txtb.Size = new System.Drawing.Size(100, 22);
            this.txtb.TabIndex = 7;
            // 
            // txth
            // 
            this.txth.Location = new System.Drawing.Point(337, 200);
            this.txth.Name = "txth";
            this.txth.Size = new System.Drawing.Size(100, 22);
            this.txth.TabIndex = 8;
            // 
            // txts
            // 
            this.txts.Location = new System.Drawing.Point(337, 247);
            this.txts.Name = "txts";
            this.txts.Size = new System.Drawing.Size(100, 22);
            this.txts.TabIndex = 9;
            // 
            // txtkp
            // 
            this.txtkp.Location = new System.Drawing.Point(337, 358);
            this.txtkp.Name = "txtkp";
            this.txtkp.Size = new System.Drawing.Size(100, 22);
            this.txtkp.TabIndex = 10;
            // 
            // dtmt
            // 
            this.dtmt.Location = new System.Drawing.Point(337, 303);
            this.dtmt.Name = "dtmt";
            this.dtmt.Size = new System.Drawing.Size(200, 22);
            this.dtmt.TabIndex = 11;
            // 
            // btnme
            // 
            this.btnme.Location = new System.Drawing.Point(561, 114);
            this.btnme.Name = "btnme";
            this.btnme.Size = new System.Drawing.Size(190, 23);
            this.btnme.TabIndex = 12;
            this.btnme.Text = "Melihat Riwayat Transaksi";
            this.btnme.UseVisualStyleBackColor = true;
            this.btnme.Click += new System.EventHandler(this.btnme_Click);
            // 
            // btned
            // 
            this.btned.Location = new System.Drawing.Point(576, 200);
            this.btned.Name = "btned";
            this.btned.Size = new System.Drawing.Size(175, 23);
            this.btned.TabIndex = 13;
            this.btned.Text = "Edit Riwayat Transaksi";
            this.btned.UseVisualStyleBackColor = true;
            this.btned.Click += new System.EventHandler(this.btned_Click);
            // 
            // btnha
            // 
            this.btnha.Location = new System.Drawing.Point(576, 300);
            this.btnha.Name = "btnha";
            this.btnha.Size = new System.Drawing.Size(175, 23);
            this.btnha.TabIndex = 14;
            this.btnha.Text = "Hapus Riwayat Transaski";
            this.btnha.UseVisualStyleBackColor = true;
            this.btnha.Click += new System.EventHandler(this.btnha_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(60, 420);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(800, 195);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // txtp
            // 
            this.txtp.Location = new System.Drawing.Point(337, 45);
            this.txtp.Name = "txtp";
            this.txtp.Size = new System.Drawing.Size(100, 22);
            this.txtp.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(128, 364);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "KodePaket";
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 673);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtp);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnha);
            this.Controls.Add(this.btned);
            this.Controls.Add(this.btnme);
            this.Controls.Add(this.dtmt);
            this.Controls.Add(this.txtkp);
            this.Controls.Add(this.txts);
            this.Controls.Add(this.txth);
            this.Controls.Add(this.txtb);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtk);
            this.Name = "FormAdmin";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtb;
        private System.Windows.Forms.TextBox txth;
        private System.Windows.Forms.TextBox txts;
        private System.Windows.Forms.TextBox txtkp;
        private System.Windows.Forms.DateTimePicker dtmt;
        private System.Windows.Forms.Button btnme;
        private System.Windows.Forms.Button btned;
        private System.Windows.Forms.Button btnha;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtp;
        private System.Windows.Forms.Label label7;
    }
}