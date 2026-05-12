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