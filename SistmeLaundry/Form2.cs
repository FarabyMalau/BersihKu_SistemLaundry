using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistmeLaundry
{
    public partial class FormAdmin : Form
    {
        // Menyiapkan koneksi database untuk Form Admin
        private SqlConnection conn = new SqlConnection("Data Source=DZAKNERZ\\DATABASEABY;Initial Catalog=DBBersihKu;Integrated Security=True");

        // Variabel untuk menyimpan ID baris yang diklik user di tabel
        int idTerpilih;

        public FormAdmin()
        {
            InitializeComponent();
        }

        private void btnme_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                // Membersihkan tabel sebelum diisi data baru
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                // Membuat header kolom tabel secara manual
                dataGridView1.Columns.Add("ID", "ID");
                dataGridView1.Columns.Add("Kasir", "Kasir");
                dataGridView1.Columns.Add("Pelanggan", "Pelanggan");
                dataGridView1.Columns.Add("Paket", "Paket");
                dataGridView1.Columns.Add("Berat", "Berat");
                dataGridView1.Columns.Add("Total", "Total");
                dataGridView1.Columns.Add("Status", "Status");
                dataGridView1.Columns.Add("Tanggal", "Tanggal");

                // Mengambil seluruh data dari tabel Transaksi
                string query = "SELECT * FROM Transaksi";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    // Memasukkan data dari database baris demi baris ke GridView
                    dataGridView1.Rows.Add(
                        r["ID_Transaksi"],
                        r["Nama_Kasir"],
                        r["Nama_Pelanggan"],
                        r["Kode_Paket"],
                        r["Berat"],
                        r["Total_Harga"],
                        r["Status_Laundry"],
                        Convert.ToDateTime(r["Tanggal"]).ToShortDateString()
                    );
                }
                r.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error load: " + ex.Message);
            }
        }