using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistmeLaundry
{
    public partial class p1 : Form
    {
        private SqlConnection conn =
        new SqlConnection("Data Source=DZAKNERZ\\DATABASEABY;Initial Catalog=DBBersihKu;Integrated Security=True");

        public p1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtth.ReadOnly = true;
        }
    }


    // ================= HITUNG TOTAL =================
void HitungTotalHarga()
        {
            try
            {
                decimal harga, berat;

                if (decimal.TryParse(txtth.Text, out harga) &&
                    decimal.TryParse(txtb.Text, out berat))
                {
                    decimal total = harga * berat;
                    txtth.Text = total.ToString();
                }
                else
                {
                    txtth.Text = "";
                }
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


        // ================= VALIDASI KOSONG =================
if (txtP.Text == "" || txtk.Text == "" || txtkp.Text == "" || txtb.Text == "" || txtth.Text == "")
{
    MessageBox.Show("Data belum lengkap");
    return;
}

// ================= VALIDASI NAMA =================
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

// ================= VALIDASI ANGKA =================
decimal harga, berat;

if (!decimal.TryParse(txtth.Text, out harga) ||
    !decimal.TryParse(txtb.Text, out berat))
{
    MessageBox.Show("Harga dan berat harus berupa angka!");
    return;
}

// ================= VALIDASI TIDAK BOLEH MINUS =================
if (harga <= 0 || berat <= 0)
{
    MessageBox.Show("Harga dan berat tidak boleh nol atau minus!");
    return;
}

// ================= VALIDASI TANGGAL =================
if (dtpT.Value.Year > DateTime.Now.Year)
{
    MessageBox.Show("Tahun tidak boleh lebih dari sekarang!");
    return;
}
    }

// ================= INSERT DATABASE =================
if (conn.State == ConnectionState.Closed)
    conn.Open();

SqlCommand cmd = new SqlCommand("sp_InsertTransaksi", conn);
cmd.CommandType = CommandType.StoredProcedure;

cmd.Parameters.AddWithValue("@kasir", txtk.Text);
cmd.Parameters.AddWithValue("@pelanggan", txtP.Text);
cmd.Parameters.AddWithValue("@paket", txtkp.Text);
cmd.Parameters.AddWithValue("@harga", harga);
cmd.Parameters.AddWithValue("@berat", berat);
cmd.Parameters.AddWithValue("@total", total);
cmd.Parameters.AddWithValue("@status", txts.Text);
cmd.Parameters.AddWithValue("@tanggal", dtpT.Value);

int result = cmd.ExecuteNonQuery();

if (result > 0)
{
    MessageBox.Show("Berhasil disimpan");
}
else
{
    MessageBox.Show("Gagal simpan");
}

conn.Close();