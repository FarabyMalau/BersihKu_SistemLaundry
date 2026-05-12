// ================= LOAD DATA =================
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

private void LoadData()
{
    try
    {
        if (conn.State == ConnectionState.Closed)
            conn.Open();

        dataGridView1.Rows.Clear();
        dataGridView1.Columns.Clear();

        dataGridView1.Columns.Add("ID", "ID");
        dataGridView1.Columns.Add("Kasir", "Kasir");
        dataGridView1.Columns.Add("Pelanggan", "Pelanggan");
        dataGridView1.Columns.Add("Paket", "Paket");
        dataGridView1.Columns.Add("Harga", "Harga");
        dataGridView1.Columns.Add("Berat", "Berat");
        dataGridView1.Columns.Add("Total", "Total");
        dataGridView1.Columns.Add("Status", "Status");
        dataGridView1.Columns.Add("Tanggal", "Tanggal");

        using (SqlCommand cmd = new SqlCommand("SELECT * FROM v_Transaksi", conn))
        {
            cmd.CommandType = CommandType.Text;

            using (SqlDataReader r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    dataGridView1.Rows.Add(
                        r["ID_Transaksi"],
                        r["Nama_Kasir"],
                        r["Nama_Pelanggan"],
                        r["Kode_Paket"],
                        r["Harga"],
                        r["Berat"],
                        r["Total_Harga"],
                        r["Status_Laundry"],
                        Convert.ToDateTime(r["Tanggal"]).ToShortDateString()
                    );
                }
            }
        }

        conn.Close();
    }
    catch (Exception ex)
    {
        MessageBox.Show("Error load: " + ex.Message);
    }
}

// tombol tampil data
private void btnme_Click(object sender, EventArgs e)
{
    LoadData();
}