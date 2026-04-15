using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistmeLaundry
{
    public partial class p1 : Form
    {
        
        private SqlConnection conn = new SqlConnection("Data Source=DZAKNERZ\\DATABASEABY;Initial Catalog=DBBersihKu;Integrated Security=True");

        public p1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            txtth.ReadOnly = true;
        }

        void HitungTotalHarga()
        {
            try
            {
                if (txtth.Text == "" || txtb.Text == "")
                {
                    txtth.Text = "";
                    return;
                }