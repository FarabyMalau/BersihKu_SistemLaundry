using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistmeLaundry
{
    public partial class FormAdmin : Form
    {
        // Menyiapkan koneksi database untuk Form Admin
        private SqlConnection conn = new SqlConnection("Data Source=DZAKNERZ\\DATABASEABY;Initial Catalog=DBBersihKu;Integrated Security=True");

        // Variabel untuk menyimpan ID baris yang diklik user di tabel
        int idTerpilih;

        public FormAdmin()
        {
            InitializeComponent();
        }