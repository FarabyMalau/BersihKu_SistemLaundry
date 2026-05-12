// ================= LOAD DATA =================
using SistmeLaundry;
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

// ================= UPDATE =================
private void btned_Click(object sender, EventArgs e)
{
    try
    {
        if (idTerpilih == 0)
        {
            MessageBox.Show("Pilih data dulu!");
            return;
        }

        decimal harga, berat;

        if (!decimal.TryParse(txth.Text, out harga) ||
            !decimal.TryParse(txtb.Text, out berat))
        {
            MessageBox.Show("Harga & berat harus angka!");
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

// ================= DELETE =================
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

// ================= CLEAR =================
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
    texSearch.Clear();
    LoadData();
}

// ================= LOGOUT =================
private void btnLogout_Click(object sender, EventArgs e)
{
    Form3_Login_ login = new Form3_Login_();
    login.Show();
    this.Hide();
}

// ================= CLOSE =================
private void FormAdmin_FormClosed(object sender, FormClosedEventArgs e)
{
    Application.Exit();
}