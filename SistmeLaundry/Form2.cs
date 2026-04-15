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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                    // Menyimpan ID Transaksi untuk proses Update/Delete
                    idTerpilih = Convert.ToInt32(row.Cells[0].Value);

                    // Menampilkan kembali data dari tabel ke TextBox agar bisa diedit
                    txtk.Text = row.Cells[1].Value.ToString();
                    txtp.Text = row.Cells[2].Value.ToString();
                    txtkp.Text = row.Cells[3].Value.ToString();
                    txtb.Text = row.Cells[4].Value.ToString();
                    txth.Text = row.Cells[5].Value.ToString();
                    txts.Text = row.Cells[6].Value.ToString();
                    dtmt.Value = Convert.ToDateTime(row.Cells[7].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengambil data: " + ex.Message);
            }
        }

        private void btned_Click(object sender, EventArgs e)
        {
            try
            {
                // Validasi: Harus pilih data di tabel dulu sebelum klik edit
                if (idTerpilih == 0) { MessageBox.Show("Pilih data di tabel dulu!"); return; }

                if (conn.State == ConnectionState.Closed) conn.Open();

                // Query UPDATE berdasarkan ID yang sedang terpilih
                string query = @"UPDATE Transaksi SET 
                                Nama_Kasir = @kasir, 
                                Nama_Pelanggan = @pelanggan, 
                                Kode_Paket = @paket, 
                                Berat = @berat, 
                                Total_Harga = @total, 
                                Status_Laundry = @status, 
                                Tanggal = @tanggal 
                                WHERE ID_Transaksi = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idTerpilih);
                cmd.Parameters.AddWithValue("@kasir", txtk.Text);
                cmd.Parameters.AddWithValue("@pelanggan", txtp.Text);
                cmd.Parameters.AddWithValue("@paket", txtkp.Text);
                cmd.Parameters.AddWithValue("@berat", decimal.Parse(txtb.Text));
                cmd.Parameters.AddWithValue("@total", decimal.Parse(txth.Text));
                cmd.Parameters.AddWithValue("@status", txts.Text);
                cmd.Parameters.AddWithValue("@tanggal", dtmt.Value);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Data berhasil diupdate");
                    btnme.PerformClick(); // [COMMIT 5] Otomatis refresh tabel setelah update
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error update: " + ex.Message);
            }
        }