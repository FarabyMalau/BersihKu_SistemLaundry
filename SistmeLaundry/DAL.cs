using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;

namespace SistmeLaundry
{
    internal class DAL
    {

        private string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork) return ip.ToString();
            }
            return "127.0.0.1"; 
        }

        public static string GetConnectionString()
        {
            return $"Data Source=DzaknerZ,1433;Initial Catalog=DBBersihKu;User ID=admin_laundry;Password=Bersihku123;TrustServerCertificate=True;";
        }

        public void InsertLaundryDariExcel(string kasir, string pelanggan, string paket, decimal harga, decimal berat, decimal total, string status, DateTime tanggal)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_InsertTransaksi", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@kasir", kasir);
                    cmd.Parameters.AddWithValue("@pelanggan", pelanggan);
                    cmd.Parameters.AddWithValue("@paket", paket);
                    cmd.Parameters.AddWithValue("@harga", harga);
                    cmd.Parameters.AddWithValue("@berat", berat);
                    cmd.Parameters.AddWithValue("@total", total);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@tanggal", tanggal.Date);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void InsertLog(string message)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_LogMessage", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@psn", message);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {

            }
        }
    }
}