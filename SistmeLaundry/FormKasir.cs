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
    }