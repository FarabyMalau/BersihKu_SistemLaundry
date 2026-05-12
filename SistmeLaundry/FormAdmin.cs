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

// ================= PILIH DATA =================
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