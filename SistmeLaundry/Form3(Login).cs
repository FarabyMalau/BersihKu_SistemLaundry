using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistmeLaundry
{
    public partial class Form3_Login_ : Form
    {
        private SqlConnection conn =
       new SqlConnection("Data Source=DZAKNERZ\\DATABASEABY;Initial Catalog=DBBersihKu;Integrated Security=True");

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