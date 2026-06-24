using SistmeLaundry;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistmeLaundryy
{
    public partial class FormCetak : Form
    {
        DAL dbLogic = new DAL();
        private SqlConnection conn = new SqlConnection(DAL.GetConnectionString());

        private readonly List<DataReport> listDataLaundry = new List<DataReport>();

        private readonly string kodePaket;
        private readonly DateTime tanggalInput;

        public FormCetak(string paket, DateTime tanggal)
        {
            InitializeComponent();

            this.Load += new System.EventHandler(this.FormCetak_Load);

            this.kodePaket = paket;
            this.tanggalInput = tanggal;
        }

        private void FormCetak_Load(object sender, EventArgs e)
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

                    cmd.Parameters.AddWithValue("@KodePaket", kodePaket.Trim());
                    cmd.Parameters.AddWithValue("@Tahun", tanggalInput.Year);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        listDataLaundry.Clear();

                        while (dr.Read())
                        {
                            DataReport report = new DataReport
                            {
                                ID_Transaksi = dr["ID_Transaksi"].ToString(),
                                Nama_Kasir = dr["Nama_Kasir"].ToString(),
                                Nama_Pelanggan = dr["Nama_Pelanggan"].ToString(),
                                Kode_Paket = dr["Kode_Paket"].ToString(),
                                Tanggal = Convert.ToDateTime(dr["Tanggal"]),

                                Berat = Convert.ToDouble(dr["Berat"], System.Globalization.CultureInfo.InvariantCulture),
                                Harga = Convert.ToDecimal(dr["Harga"], System.Globalization.CultureInfo.InvariantCulture),
                                Total_Harga = Convert.ToDecimal(dr["Total_Harga"], System.Globalization.CultureInfo.InvariantCulture),

                                Status_Laundry = dr["Status_Laundry"].ToString()
                            };

                            listDataLaundry.Add(report);
                        }
                    }
                }

                MessageBox.Show("Sistem berhasil menarik " + listDataLaundry.Count + " baris data dari database untuk Paket: [" + kodePaket + "] Tahun: [" + tanggalInput.Year + "]", "Info Debug");

                if (listDataLaundry.Count > 0)
                {
                    RptTransaksi rpt = new RptTransaksi();
                    rpt.SetDataSource(listDataLaundry);

                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat laporan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}