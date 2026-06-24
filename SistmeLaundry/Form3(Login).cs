using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistmeLaundry
{
    public partial class Form3_Login_ : Form
    {
        DAL dbLogic = new DAL();
        private SqlConnection conn = new SqlConnection(DAL.GetConnectionString());

        public Form3_Login_()
        {
            InitializeComponent();
        }

        private void Form3_Login__Load(object sender, EventArgs e)
        {
            cmbRole.Items.Clear();
            cmbRole.Items.Add("Admin");
            cmbRole.Items.Add("Kasir");

            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd;
                if (cmbRole.Text == "Admin")
                {
                    cmd = new SqlCommand("sp_LoginAdmin", conn);
                }
                else
                {
                    cmd = new SqlCommand("sp_LoginKasir", conn);
                }

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.HasRows)

                {
                    MessageBox.Show("Login Berhasil");

                    if (cmbRole.Text == "Admin")
                    {
                        FormAdmin frm = new FormAdmin();
                        frm.Show();
                    }
                    else
                    {
                        p1 frm = new p1(txtUsername.Text); 
                        frm.Show();
                    }
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login Gagal, pastikan username, password, dan role benar!");
                }
                conn.Close();

            }
            catch (Exception ex)
            {
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}