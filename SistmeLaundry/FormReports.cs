using SistmeLaundry;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistmeLaundryy
{
    public partial class FormReports : Form
    {
        DAL dbLogic = new DAL();
        private SqlConnection conn = new SqlConnection(DAL.GetConnectionString());

        private SqlDataAdapter da;
        private DataTable dtTransaksi;

        public FormReports()
        {
            InitializeComponent();
        }

        private void FormReports_Load(object sender, EventArgs e)
        {
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = "yyyy";
            dtp.ShowUpDown = true;

            cmbkp.Items.Clear();
            cmbkp.Items.Add("CK01");
            cmbkp.Items.Add("CS01");
            cmbkp.Items.Add("SS01");
            cmbkp.Items.Add("EX01");

            if (cmbkp.Items.Count > 0)
                cmbkp.SelectedIndex = 0;

            btnCetak.Enabled = false; 
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                using (SqlCommand cmd = new SqlCommand("sp_ReportLaundry", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@KodePaket", cmbkp.Text);
                    cmd.Parameters.AddWithValue("@Tahun", dtp.Value.Year);

                    da = new SqlDataAdapter(cmd);
                    dtTransaksi = new DataTable();
                    da.Fill(dtTransaksi);
                }

                dataGridView1.DataSource = dtTransaksi;

                if (dtTransaksi.Rows.Count > 0)
                {
                    btnCetak.Enabled = true; 
                }
                else
                {
                    btnCetak.Enabled = false;
                    MessageBox.Show("Data tidak ditemukan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load data: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnCetak_Click(object sender, EventArgs e)
        {
            FormCetak frm2 = new FormCetak(cmbkp.Text, dtp.Value);
            frm2.Show();

            this.Hide();
        }
    }
}