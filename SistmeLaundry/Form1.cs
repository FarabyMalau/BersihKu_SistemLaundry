using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistmeLaundry
{
    public partial class p1 : Form
    {
        
        private SqlConnection conn = new SqlConnection("Data Source=DZAKNERZ\\DATABASEABY;Initial Catalog=DBBersihKu;Integrated Security=True");

        public p1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            txtth.ReadOnly = true;
        }

        void HitungTotalHarga()
        {
            try
            {
                if (txtth.Text == "" || txtb.Text == "")
                {
                    txtth.Text = "";
                    return;
                }

                int harga;
                int berat;

                if (!int.TryParse(txtth.Text, out harga) || !int.TryParse(txtb.Text, out berat))
                {
                    txtth.Text = ""; 
                    return;
                }

                int total = harga * berat;

                txtth.Text = total.ToString();
            }
            catch
            {
                txtth.Text = "";
            }
        }

        private void txtHarga_TextChanged(object sender, EventArgs e)
        {
            HitungTotalHarga();
        }

        private void txtb_TextChanged(object sender, EventArgs e)
        {
            HitungTotalHarga();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                if (txtP.Text == "" || txtk.Text == "" || txtkp.Text == "" || txtb.Text == "")
                {
                    MessageBox.Show("Data belum lengkap");
                    return;
                }

                string query = @"
                INSERT INTO Transaksi
                (Nama_Kasir, Nama_Pelanggan, Kode_Paket, Berat, Total_Harga, Status_Laundry)
                VALUES
                (@kasir, @pelanggan, @paket, @berat, @total, @status)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@kasir", txtk.Text);
                cmd.Parameters.AddWithValue("@pelanggan", txtP.Text);
                cmd.Parameters.AddWithValue("@paket", txtkp.Text);
                cmd.Parameters.AddWithValue("@berat", Convert.ToDecimal(txtb.Text));
                cmd.Parameters.AddWithValue("@total", Convert.ToDecimal(txtth.Text));
                cmd.Parameters.AddWithValue("@status", txts.Text);