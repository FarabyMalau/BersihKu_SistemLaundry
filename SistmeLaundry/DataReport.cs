using System;

namespace SistmeLaundry
{
    public class DataReport
    {
        public string ID_Transaksi { get; set; }
        public string Nama_Kasir { get; set; }
        public string Nama_Pelanggan { get; set; }
        public string Kode_Paket { get; set; }
        public DateTime Tanggal { get; set; }
        public double Berat { get; set; }
        public decimal Harga { get; set; }
        public decimal Total_Harga { get; set; }
        public string Status_Laundry { get; set; }
    }
}