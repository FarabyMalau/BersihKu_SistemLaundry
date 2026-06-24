using ExcelDataReader;
using SistmeLaundryy;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace SistmeLaundry
{
    public partial class FormAdmin : Form
    {
        DAL dbLogic = new DAL();
        private SqlConnection conn = new SqlConnection(DAL.GetConnectionString());

        int idTerpilih = 0;

        public FormAdmin()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            try
            {
                dataGridView1.DataSource = null;

                if (dataGridView1.Columns.Count == 0)
                {
                    dataGridView1.Columns.Add("ID", "ID");
                    dataGridView1.Columns.Add("Kasir", "Kasir");
                    dataGridView1.Columns.Add("Pelanggan", "Pelanggan");
                    dataGridView1.Columns.Add("Paket", "Paket");
                    dataGridView1.Columns.Add("Harga", "Harga");
                    dataGridView1.Columns.Add("Berat", "Berat");
                    dataGridView1.Columns.Add("Total", "Total");
                    dataGridView1.Columns.Add("Status", "Status");
                    dataGridView1.Columns.Add("Tanggal", "Tanggal");
                }

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                dataGridView1.Rows.Clear();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM v_Transaksi", conn))
                {
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            dataGridView1.Rows.Add(
                                r["ID_Transaksi"].ToString(),
                                r["Nama_Kasir"].ToString(),
                                r["Nama_Pelanggan"].ToString(), 
                                r["Kode_Paket"].ToString(),
                                r["Harga"].ToString(),
                                r["Berat"].ToString(),
                                r["Total_Harga"].ToString(),
                                r["Status_Laundry"].ToString(),
                                Convert.ToDateTime(r["Tanggal"]).ToShortDateString()
                            );
                        }
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open) conn.Close();

                MessageBox.Show("Error load data: " + ex.Message);
            }
        }

        private void btnme_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                idTerpilih = Convert.ToInt32(row.Cells[0].Value);

                txtk.Text = row.Cells[1].Value.ToString();
                txtp.Text = row.Cells[2].Value.ToString();
                txtkp.Text = row.Cells[3].Value.ToString();
                txth.Text = row.Cells[4].Value.ToString();
                txtb.Text = row.Cells[5].Value.ToString();
                txts.Text = row.Cells[7].Value.ToString();
                dtmt.Value = Convert.ToDateTime(row.Cells[8].Value);
            }
        }

        private void btned_Click(object sender, EventArgs e)
        {
            try
            {
                if (idTerpilih == 0)
                {
                    MessageBox.Show("Pilih data dulu!");
                    return;
                }

                if (txtk.Text == "" || txtp.Text == "" || txtkp.Text == "" || txtb.Text == "" || txth.Text == "")
                {
                    MessageBox.Show("Data belum lengkap!");
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(txtp.Text, @"^[a-zA-Z\s]+$"))
                {
                    MessageBox.Show("Nama pelanggan tidak boleh simbol!");
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(txtk.Text, @"^[a-zA-Z\s]+$"))
                {
                    MessageBox.Show("Nama kasir tidak boleh simbol!");
                    return;
                }

                decimal harga, berat;

                if (!decimal.TryParse(txth.Text, out harga) ||
                    !decimal.TryParse(txtb.Text, out berat))
                {
                    MessageBox.Show("Harga & berat harus angka!");
                    return;
                }

                if (harga <= 0 || berat <= 0)
                {
                    MessageBox.Show("Tidak boleh minus atau nol!");
                    return;
                }

                if (dtmt.Value.Year > DateTime.Now.Year)
                {
                    MessageBox.Show("Tahun tidak boleh lebih dari sekarang!");
                    return;
                }

                decimal total = harga * berat;

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand cmd = new SqlCommand("sp_UpdateTransaksi", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", idTerpilih);
                cmd.Parameters.AddWithValue("@kasir", txtk.Text);
                cmd.Parameters.AddWithValue("@pelanggan", txtp.Text);
                cmd.Parameters.AddWithValue("@paket", txtkp.Text);
                cmd.Parameters.AddWithValue("@harga", harga);
                cmd.Parameters.AddWithValue("@berat", berat);
                cmd.Parameters.AddWithValue("@total", total);
                cmd.Parameters.AddWithValue("@status", txts.Text);
                cmd.Parameters.AddWithValue("@tanggal", dtmt.Value);

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Data berhasil diupdate");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Gagal update");
                }

                conn.Close();
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
                if (idTerpilih == 0)
                {
                    MessageBox.Show("Pilih data dulu!");
                    return;
                }

                DialogResult confirm = MessageBox.Show(
                    "Yakin hapus ID " + idTerpilih + "?",
                    "Konfirmasi",
                    MessageBoxButtons.YesNo);

                if (confirm == DialogResult.No) return;

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand cmd = new SqlCommand("sp_DeleteTransaksi", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", idTerpilih);

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Data berhasil dihapus");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Gagal hapus");
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error delete: " + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtb.Clear();
            txtk.Clear();
            txtp.Clear();
            txth.Clear();
            txts.Clear();
            txtkp.Clear();

            dtmt.Value = DateTime.Now;
            idTerpilih = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (texSearch.Text.Trim() == "")
                {
                    MessageBox.Show("Masukkan kata kunci pencarian!");
                    return;
                }

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                dataGridView1.Rows.Clear();

                SqlCommand cmd = new SqlCommand("sp_SearchTransaksi", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@keyword", texSearch.Text);

                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    dataGridView1.Rows.Add(
                        r["ID_Transaksi"],
                        r["Nama_Kasir"],
                        r["Nama_Pelanggan"],
                        r["Kode_Paket"],
                        r["Berat"],
                        r["Harga"],
                        r["Total_Harga"],
                        r["Status_Laundry"],
                        Convert.ToDateTime(r["Tanggal"]).ToShortDateString()
                    );
                }

                r.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error search: " + ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string queryReset = @"
            IF OBJECT_ID('dbo.Transaksi_Backup') IS NOT NULL
            BEGIN
                DELETE FROM dbo.Transaksi;
                SET IDENTITY_INSERT dbo.Transaksi ON;
                INSERT INTO dbo.Transaksi 
                (ID_Transaksi, Nama_Kasir, Nama_Pelanggan, Kode_Paket, Harga, Berat, Total_Harga, Status_Laundry, Tanggal)
                SELECT 
                ID_Transaksi, Nama_Kasir, Nama_Pelanggan, Kode_Paket, Harga, Berat, Total_Harga, Status_Laundry, Tanggal 
                FROM dbo.Transaksi_Backup;
                SET IDENTITY_INSERT dbo.Transaksi OFF;
            END";

                using (SqlCommand cmd = new SqlCommand(queryReset, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Data berhasil direset ke kondisi semula!");

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Reset gagal: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form3_Login_ login = new Form3_Login_();
            login.Show();
            this.Hide();
        }

        private void FormAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            this.transaksiTableAdapter.Fill(this.dBBersihKuDataSet.Transaksi);
        }

        private void btnTestInjection_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string inputNama = txtp.Text;

                if (string.IsNullOrEmpty(inputNama))
                {
                    MessageBox.Show("Masukkan teks atau payload pada TextBox Nama Pelanggan terlebih dahulu!");
                    return;
                }

                string querySengajaRentan = "UPDATE Transaksi SET Nama_Pelanggan = 'HACKED' WHERE Nama_Pelanggan = '" + inputNama + "'";

                using (SqlCommand cmd = new SqlCommand(querySengajaRentan, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    int result = cmd.ExecuteNonQuery();
                    MessageBox.Show(result + " baris berhasil terupdate!");
                }

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error simulasi: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormReports halamanLaporan = new FormReports();
            halamanLaporan.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
                openFileDialog.Title = "Pilih Berkas Excel Transaksi Laundry";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string filePath = openFileDialog.FileName;

                        using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                        {
                            using (var reader = ExcelReaderFactory.CreateReader(stream))
                            {
                                var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                                {
                                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                                    {
                                        UseHeaderRow = true
                                    }
                                });

                                DataTable dt = result.Tables[0];
                                dataGridView1.DataSource = dt;

                                btnme.Enabled = false;
                                btned.Enabled = false;
                                btnha.Enabled = false;
                                btnSearch.Enabled = false;
                                btnReset.Enabled = false;
                                btnTestInjection.Enabled = false;

                                MessageBox.Show("File Excel berhasil dimuat. Silakan periksa tabel, lalu klik 'Import to Database' untuk menyimpan.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        dbLogic.InsertLog("Error Read Excel: " + ex.Message);
                        MessageBox.Show("Gagal membaca file Excel: " + ex.Message);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)dataGridView1.DataSource;

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Tidak ada data di tabel untuk diimport! Silakan klik 'Import form Excel' terlebih dahulu.");
                    return;
                }

                int sukses = 0;

                foreach (DataRow row in dt.Rows)
                {
                    string namaPelanggan = row["Nama_Pelanggan"] != DBNull.Value ? row["Nama_Pelanggan"].ToString().Trim() : string.Empty;
                    string namaKasir = row["Nama_Kasir"] != DBNull.Value ? row["Nama_Kasir"].ToString().Trim() : string.Empty;
                    string kodePaket = row["Kode_Paket"] != DBNull.Value ? row["Kode_Paket"].ToString().Trim() : string.Empty;
                    string statusLaundry = row["Status_Laundry"] != DBNull.Value ? row["Status_Laundry"].ToString().Trim() : string.Empty;

                    string sHarga = row["Harga"] != DBNull.Value ? row["Harga"].ToString().Trim() : "0";
                    string sBerat = row["Berat"] != DBNull.Value ? row["Berat"].ToString().Trim() : "0";
                    string sTotal = row["Total"] != DBNull.Value ? row["Total"].ToString().Trim() : "0";
                    string sTanggal = row["Tanggal"] != DBNull.Value ? row["Tanggal"].ToString().Trim() : DateTime.Now.ToString();

                    if (string.IsNullOrEmpty(namaPelanggan) || string.IsNullOrEmpty(namaKasir))
                        continue;

                    decimal harga = Convert.ToDecimal(sHarga);
                    decimal berat = Convert.ToDecimal(sBerat);
                    decimal total = Convert.ToDecimal(sTotal);
                    DateTime tanggal = Convert.ToDateTime(sTanggal);

                    dbLogic.InsertLaundryDariExcel(namaKasir, namaPelanggan, kodePaket, harga, berat, total, statusLaundry, tanggal);

                    sukses++;
                }

                MessageBox.Show(sukses + " data transaksi laundry berhasil diimport ke database.");

                btnme.Enabled = true;
                btned.Enabled = true;
                btnha.Enabled = true;
                btnSearch.Enabled = true;
                btnReset.Enabled = true;
                btnTestInjection.Enabled = true;

                LoadData();
            }
            catch (SqlException ex)
            {
                dbLogic.InsertLog("Rollback Import DB: " + ex.Message);
                MessageBox.Show("SQL Error : " + ex.Message);
            }
            catch (Exception ex)
            {
                dbLogic.InsertLog("General Error Import DB: " + ex.Message);
                MessageBox.Show("General Error : " + ex.Message);
            }
        }
    }
}