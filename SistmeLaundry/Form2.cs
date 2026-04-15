using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistmeLaundry
{
    public partial class FormAdmin : Form
    {

        private SqlConnection conn = new SqlConnection("Data Source=DZAKNERZ\\DATABASEABY;Initial Catalog=DBBersihKu;Integrated Security=True");

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

                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();



                dataGridView1.Columns.Add("ID", "ID");           
                dataGridView1.Columns.Add("Kasir", "Kasir");     
                dataGridView1.Columns.Add("Pelanggan", "Pelanggan"); 
                dataGridView1.Columns.Add("Paket", "Paket");     
                dataGridView1.Columns.Add("Berat", "Berat");     
                dataGridView1.Columns.Add("Total", "Total");     
                dataGridView1.Columns.Add("Status", "Status");  
                dataGridView1.Columns.Add("Tanggal", "Tanggal"); 

                string query = "SELECT * FROM Transaksi";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
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


                    idTerpilih = Convert.ToInt32(row.Cells[0].Value);


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
                if (idTerpilih == 0) { MessageBox.Show("Pilih data di tabel dulu!"); return; }

                if (conn.State == ConnectionState.Closed) conn.Open();

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
                    btnme.PerformClick(); 
                }
                else { MessageBox.Show("Gagal update: Data tidak ditemukan"); }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error update: " + ex.Message);
            }
        }

        
        private void btnha_Click(object sender, EventArgs e)
        {
            try
            {
                if (idTerpilih == 0) { MessageBox.Show("Pilih data di tabel dulu!"); return; }

                DialogResult confirm = MessageBox.Show("Yakin ingin menghapus data ID " + idTerpilih + "?", "Konfirmasi", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.No) return;

                if (conn.State == ConnectionState.Closed) conn.Open();

                string query = "DELETE FROM Transaksi WHERE ID_Transaksi = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idTerpilih);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Data berhasil dihapus");
                    btnme.PerformClick(); 
                }
                else { MessageBox.Show("Gagal hapus"); }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error delete: " + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtb.Clear(); txtk.Clear(); txtp.Clear();
            txth.Clear(); txts.Clear(); txtkp.Clear();
            dtmt.Value = DateTime.Now;
            idTerpilih = 0;
        }
    }
}