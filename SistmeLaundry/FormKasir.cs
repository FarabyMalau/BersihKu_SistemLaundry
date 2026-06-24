using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistmeLaundry
{
    public partial class p1 : Form
    {
        DAL dbLogic = new DAL();
        private SqlConnection conn = new SqlConnection(DAL.GetConnectionString());

        public p1(string nm)
        {
            InitializeComponent();
            txtk.Text = nm;
            txtk.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        void HitungTotalHarga()
        {
            try
            {
                decimal harga, berat;

                if (decimal.TryParse(txtth.Text, out harga) &&
                    decimal.TryParse(txtb.Text, out berat))
                {
                    decimal total = harga * berat;
                }
            }
            catch
            {
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
                if (txtP.Text == "" || txtk.Text == "" || txtkp.Text == "" || txtb.Text == "" || txtth.Text == "")
                {
                    MessageBox.Show("Data belum lengkap");
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(txtP.Text, @"^[a-zA-Z\s]+$"))
                {
                    MessageBox.Show("Nama pelanggan tidak boleh mengandung simbol!");
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(txtk.Text, @"^[a-zA-Z\s]+$"))
                {
                    MessageBox.Show("Nama kasir tidak boleh mengandung simbol!");
                    return;
                }

                decimal harga, berat;

                if (!decimal.TryParse(txtth.Text, out harga) ||
                    !decimal.TryParse(txtb.Text, out berat))
                {
                    MessageBox.Show("Harga dan berat harus berupa angka!");
                    return;
                }

                if (harga <= 0 || berat <= 0)
                {
                    MessageBox.Show("Harga dan berat tidak boleh nol atau minus!");
                    return;
                }

                if (dtpT.Value.Year > DateTime.Now.Year)
                {
                    MessageBox.Show("Tahun tidak boleh lebih dari sekarang!");
                    return;
                }

                decimal total = harga * berat;

                if (conn.State == ConnectionState.Closed)
                    conn.Open();


                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    int result = 0;

                    using (SqlCommand cmd = new SqlCommand("sp_InsertTransaksi", conn, trans))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@kasir", txtk.Text);
                        cmd.Parameters.AddWithValue("@pelanggan", txtP.Text);
                        cmd.Parameters.AddWithValue("@paket", txtkp.Text);
                        cmd.Parameters.AddWithValue("@harga", harga);
                        cmd.Parameters.AddWithValue("@berat", berat);
                        cmd.Parameters.AddWithValue("@total", total);
                        cmd.Parameters.AddWithValue("@status", txts.Text);
                        cmd.Parameters.AddWithValue("@tanggal", dtpT.Value);

                        result = cmd.ExecuteNonQuery();
                    }


                    string queryLogBackup = "INSERT INTO LogAktivitas (Aktivitas, Waktu) VALUES (@txt, GETDATE())";
                    using (SqlCommand cmdLog = new SqlCommand(queryLogBackup, conn, trans))
                    {
                        cmdLog.Parameters.AddWithValue("@txt", "LOG BACKEND C#: Sukses memproses transaksi laundry untuk " + txtP.Text);
                        cmdLog.ExecuteNonQuery();
                    }

                    trans.Commit();

                    if (result > 0)
                    {
                        MessageBox.Show("Data transaksi dan log audit berhasil disimpan ke sistem!", "Sukses UCP 3", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtNota.Text =
                            "=============================== NOTA LAUNDRY =====================================\r\n\r\n" +
                            "Kasir        : " + txtk.Text + "\r\n" +
                            "Pelanggan    : " + txtP.Text + "\r\n" +
                            "Tanggal      : " + dtpT.Value.ToString("dd/MM/yyyy") + "\r\n" +
                            "Paket        : " + txtkp.Text + "\r\n" +
                            "Berat        : " + berat + " Kg\r\n" +
                            "-----------------------------\r\n" +
                            "TOTAL        : Rp " + total + "\r\n" +
                            "-----------------------------\r\n" +
                            "Status       : " + txts.Text + "\r\n\r\n" +
                            "Terima kasih 😊";
                    }
                    else
                    {
                        MessageBox.Show("Gagal simpan data transaksi.");
                    }
                }
                catch (SqlException sqlEx)
                {
                    trans.Rollback();
                    MessageBox.Show("Gagal menyimpan ke database (Mekanisme ROLLBACK diaktifkan): \nError: " + sqlEx.Message, "SqlException " + sqlEx.Number, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Terjadi kesalahan runtime aplikasi (ROLLBACK diaktifkan): \nError: " + ex.Message, "Error Aplikasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error luar sistem: " + ex.Message);
            }
        }

        void TampilkanNota()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM v_Transaksi ORDER BY ID_Transaksi DESC", conn);
                cmd.CommandType = CommandType.Text;

                SqlDataReader r = cmd.ExecuteReader();

                if (r.Read())
                {
                    txtNota.Text =
                        "===== NOTA LAUNDRY =====\r\n\r\n" +
                        "ID Transaksi : " + r["ID_Transaksi"] + "\r\n" +
                        "Kasir        : " + r["Nama_Kasir"] + "\r\n" +
                        "Pelanggan    : " + r["Nama_Pelanggan"] + "\r\n" +
                        "Tanggal      : " + Convert.ToDateTime(r["Tanggal"]).ToString("dd/MM/yyyy") + "\r\n" +
                        "Paket        : " + r["Kode_Paket"] + "\r\n" +
                        "Berat        : " + r["Berat"] + " Kg\r\n" +
                        "-----------------------------\r\n" +
                        "TOTAL        : Rp " + r["Total_Harga"] + "\r\n" +
                        "-----------------------------\r\n" +
                        "Status       : " + r["Status_Laundry"] + "\r\n\r\n" +
                        "Terima kasih 😊";
                }

                r.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error nota: " + ex.Message);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            TampilkanNota();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAdmin adminForm = new FormAdmin();
            adminForm.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form3_Login_ login = new Form3_Login_();
            login.Show();
            this.Hide();
        }

        private void p1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void txtk_TextChanged(object sender, EventArgs e)
        {

        }
    }
}