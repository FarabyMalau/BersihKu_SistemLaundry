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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdmin));
            this.txtk = new System.Windows.Forms.TextBox();
            this.transaksiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dBBersihKuDataSet = new SistmeLaundry.DBBersihKuDataSet();
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
            this.btnLogout = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.transaksiTableAdapter = new SistmeLaundry.DBBersihKuDataSetTableAdapters.TransaksiTableAdapter();
            this.transaksiBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.transaksiBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.texSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnTestInjection = new System.Windows.Forms.Button();
            this.btnKeHalamanReport = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnImpDb = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.transaksiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBBersihKuDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transaksiBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transaksiBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtk
            // 
            this.txtk.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.transaksiBindingSource, "Nama_Kasir", true));
            this.txtk.Location = new System.Drawing.Point(278, 122);
            this.txtk.Name = "txtk";
            this.txtk.Size = new System.Drawing.Size(170, 22);
            this.txtk.TabIndex = 0;
            // 
            // transaksiBindingSource
            // 
            this.transaksiBindingSource.DataMember = "Transaksi";
            this.transaksiBindingSource.DataSource = this.dBBersihKuDataSet;
            // 
            // dBBersihKuDataSet
            // 
            this.dBBersihKuDataSet.DataSetName = "DBBersihKuDataSet";
            this.dBBersihKuDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nama Pelanggan";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nama Kasir";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(47, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Berat";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(47, 261);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Harga";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(47, 331);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 19);
            this.label5.TabIndex = 5;
            this.label5.Text = "Status Laundry";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(47, 476);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 19);
            this.label6.TabIndex = 6;
            this.label6.Text = "Tanggal";
            // 
            // txtb
            // 
            this.txtb.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.transaksiBindingSource, "Berat", true));
            this.txtb.Location = new System.Drawing.Point(278, 191);
            this.txtb.Name = "txtb";
            this.txtb.Size = new System.Drawing.Size(170, 22);
            this.txtb.TabIndex = 7;
            // 
            // txth
            // 
            this.txth.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.transaksiBindingSource, "Harga", true));
            this.txth.Location = new System.Drawing.Point(278, 261);
            this.txth.Name = "txth";
            this.txth.Size = new System.Drawing.Size(170, 22);
            this.txth.TabIndex = 8;
            // 
            // txts
            // 
            this.txts.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.transaksiBindingSource, "Status_Laundry", true));
            this.txts.Location = new System.Drawing.Point(278, 331);
            this.txts.Name = "txts";
            this.txts.Size = new System.Drawing.Size(170, 22);
            this.txts.TabIndex = 9;
            // 
            // txtkp
            // 
            this.txtkp.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.transaksiBindingSource, "Kode_Paket", true));
            this.txtkp.Location = new System.Drawing.Point(278, 404);
            this.txtkp.Name = "txtkp";
            this.txtkp.Size = new System.Drawing.Size(170, 22);
            this.txtkp.TabIndex = 10;
            // 
            // dtmt
            // 
            this.dtmt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.transaksiBindingSource, "Tanggal", true));
            this.dtmt.Location = new System.Drawing.Point(278, 476);
            this.dtmt.Name = "dtmt";
            this.dtmt.Size = new System.Drawing.Size(170, 22);
            this.dtmt.TabIndex = 11;
            // 
            // btnme
            // 
            this.btnme.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnme.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnme.Location = new System.Drawing.Point(30, 534);
            this.btnme.Name = "btnme";
            this.btnme.Size = new System.Drawing.Size(125, 58);
            this.btnme.TabIndex = 12;
            this.btnme.Text = "Melihat Riwayat Transaksi";
            this.btnme.UseVisualStyleBackColor = false;
            this.btnme.Click += new System.EventHandler(this.btnme_Click);
            // 
            // btned
            // 
            this.btned.BackColor = System.Drawing.SystemColors.Highlight;
            this.btned.Location = new System.Drawing.Point(206, 534);
            this.btned.Name = "btned";
            this.btned.Size = new System.Drawing.Size(110, 58);
            this.btned.TabIndex = 13;
            this.btned.Text = "Edit Riwayat Transaksi";
            this.btned.UseVisualStyleBackColor = false;
            this.btned.Click += new System.EventHandler(this.btned_Click);
            // 
            // btnha
            // 
            this.btnha.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnha.Location = new System.Drawing.Point(364, 534);
            this.btnha.Name = "btnha";
            this.btnha.Size = new System.Drawing.Size(122, 58);
            this.btnha.TabIndex = 14;
            this.btnha.Text = "Hapus Riwayat Transaski";
            this.btnha.UseVisualStyleBackColor = false;
            this.btnha.Click += new System.EventHandler(this.btnha_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(563, 122);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(800, 403);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // txtp
            // 
            this.txtp.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.transaksiBindingSource, "Nama_Pelanggan", true));
            this.txtp.Location = new System.Drawing.Point(278, 45);
            this.txtp.Name = "txtp";
            this.txtp.Size = new System.Drawing.Size(170, 22);
            this.txtp.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(47, 404);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 19);
            this.label7.TabIndex = 17;
            this.label7.Text = "KodePaket";
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnLogout.Location = new System.Drawing.Point(914, 544);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(132, 48);
            this.btnLogout.TabIndex = 18;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnha);
            this.panel1.Controls.Add(this.txtp);
            this.panel1.Controls.Add(this.btned);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnme);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtkp);
            this.panel1.Controls.Add(this.dtmt);
            this.panel1.Controls.Add(this.txts);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txth);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtb);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtk);
            this.panel1.Location = new System.Drawing.Point(2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(535, 661);
            this.panel1.TabIndex = 19;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator1.BindingSource = this.transaksiBindingSource;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigator1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(1399, 27);
            this.bindingNavigator1.TabIndex = 20;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(45, 24);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // transaksiTableAdapter
            // 
            this.transaksiTableAdapter.ClearBeforeFill = true;
            // 
            // transaksiBindingSource1
            // 
            this.transaksiBindingSource1.DataMember = "Transaksi";
            this.transaksiBindingSource1.DataSource = this.dBBersihKuDataSet;
            // 
            // transaksiBindingSource2
            // 
            this.transaksiBindingSource2.DataMember = "Transaksi";
            this.transaksiBindingSource2.DataSource = this.dBBersihKuDataSet;
            // 
            // texSearch
            // 
            this.texSearch.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.texSearch.Location = new System.Drawing.Point(563, 30);
            this.texSearch.Multiline = true;
            this.texSearch.Name = "texSearch";
            this.texSearch.Size = new System.Drawing.Size(185, 31);
            this.texSearch.TabIndex = 21;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSearch.Location = new System.Drawing.Point(765, 28);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(94, 33);
            this.btnSearch.TabIndex = 22;
            this.btnSearch.Text = "SEARCH";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnReset.Location = new System.Drawing.Point(874, 28);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 33);
            this.btnReset.TabIndex = 23;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnTestInjection
            // 
            this.btnTestInjection.Location = new System.Drawing.Point(1035, 30);
            this.btnTestInjection.Name = "btnTestInjection";
            this.btnTestInjection.Size = new System.Drawing.Size(133, 33);
            this.btnTestInjection.TabIndex = 24;
            this.btnTestInjection.Text = "Test Injection";
            this.btnTestInjection.UseVisualStyleBackColor = true;
            this.btnTestInjection.Click += new System.EventHandler(this.btnTestInjection_Click);
            // 
            // btnKeHalamanReport
            // 
            this.btnKeHalamanReport.Location = new System.Drawing.Point(1035, 65);
            this.btnKeHalamanReport.Name = "btnKeHalamanReport";
            this.btnKeHalamanReport.Size = new System.Drawing.Size(133, 33);
            this.btnKeHalamanReport.TabIndex = 25;
            this.btnKeHalamanReport.Text = "Rekap Transaksi";
            this.btnKeHalamanReport.UseVisualStyleBackColor = true;
            this.btnKeHalamanReport.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1186, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 33);
            this.button1.TabIndex = 26;
            this.button1.Text = "Import form Excel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnImpDb
            // 
            this.btnImpDb.Location = new System.Drawing.Point(1186, 65);
            this.btnImpDb.Name = "btnImpDb";
            this.btnImpDb.Size = new System.Drawing.Size(125, 50);
            this.btnImpDb.TabIndex = 27;
            this.btnImpDb.Text = "Import to Database";
            this.btnImpDb.UseVisualStyleBackColor = true;
            this.btnImpDb.Click += new System.EventHandler(this.button2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1399, 609);
            this.Controls.Add(this.btnImpDb);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnKeHalamanReport);
            this.Controls.Add(this.btnTestInjection);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.texSearch);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "FormAdmin";
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormAdmin_FormClosed);
            this.Load += new System.EventHandler(this.FormAdmin_Load);
            this.Click += new System.EventHandler(this.btnSearch_Click);
            ((System.ComponentModel.ISupportInitialize)(this.transaksiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBBersihKuDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transaksiBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transaksiBindingSource2)).EndInit();
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
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private DBBersihKuDataSet dBBersihKuDataSet;
        private System.Windows.Forms.BindingSource transaksiBindingSource;
        private DBBersihKuDataSetTableAdapters.TransaksiTableAdapter transaksiTableAdapter;
        private System.Windows.Forms.BindingSource transaksiBindingSource1;
        private System.Windows.Forms.BindingSource transaksiBindingSource2;
        private System.Windows.Forms.TextBox texSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnTestInjection;
        private System.Windows.Forms.Button btnKeHalamanReport;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnImpDb;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}