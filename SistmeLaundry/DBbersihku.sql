IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'DBBersihKu')
BEGIN
    CREATE DATABASE DBBersihKu;
END
GO

USE DBBersihKu;
GO

DROP TABLE IF EXISTS LogAktivitas;
DROP TABLE IF EXISTS Transaksi_Backup;
DROP TABLE IF EXISTS Transaksi;
DROP TABLE IF EXISTS USERLOGIN;
DROP TABLE IF EXISTS Paket;
DROP TABLE IF EXISTS Pelanggan;
DROP TABLE IF EXISTS Kasir;
DROP TABLE IF EXISTS Pengelola;

CREATE TABLE Kasir (
    ID_Kasir INT IDENTITY(1,1) PRIMARY KEY,
    NamaKasir VARCHAR(100) NOT NULL,
    Username VARCHAR(25) NOT NULL,
    Passwordhash VARCHAR(255) NOT NULL
);

CREATE TABLE Pengelola (
   ID_Pengelola INT IDENTITY(1,1) PRIMARY KEY, 
   Nama_Pengelola VARCHAR(50) NOT NULL, 
   Username VARCHAR(25) NOT NULL,
   Passwordhash VARCHAR(255)
);

CREATE TABLE Pelanggan (
   ID_Pelanggan INT IDENTITY(1,1) PRIMARY KEY, 
   Nama_Pelanggan VARCHAR(100),
   No_Hp VARCHAR(15),
   Alamat VARCHAR(50)
);

CREATE TABLE Paket (
    Kode_Paket CHAR(5) PRIMARY KEY,
    Nama_Paket VARCHAR(100) NOT NULL,
    Harga_Perkilo DECIMAL (10,2)
);

CREATE TABLE Transaksi (
  ID_Transaksi INT IDENTITY(1,1) PRIMARY KEY,
  Nama_Kasir VARCHAR(100),
  Nama_Pelanggan VARCHAR(100),
  Kode_Paket CHAR(5),
  Harga DECIMAL(18,2),
  Tanggal DATE,
  Berat DECIMAL(18,2),
  Total_Harga DECIMAL(18,2),
  Status_Laundry VARCHAR(50) DEFAULT 'diterima',
  CONSTRAINT FK_Paket FOREIGN KEY (Kode_Paket) REFERENCES Paket(Kode_Paket)
);

CREATE TABLE LogAktivitas (
    ID_Log INT IDENTITY(1,1) PRIMARY KEY,
    Aktivitas VARCHAR(255),
    Waktu DATETIME DEFAULT GETDATE()
);

INSERT INTO Kasir (NamaKasir, Username, Passwordhash) VALUES
('Topan Simalakama', 'opan', '1qaz'),
('Nela Andrina', 'nela', 'hgfdsa'),
('Seyla Avina', 'vina', 'abcdefg');

INSERT INTO Pengelola (Nama_Pengelola, Username, Passwordhash) VALUES
('Admin', 'admin', 'admin123');

INSERT INTO Pelanggan (Nama_Pelanggan, No_Hp, Alamat) VALUES
('Tenxii', '081234567890', 'Tamantirto'),
('Mulyono', '082345678901', 'Sleman'),
('Reza Arap', '083456789012', 'Yogyakarta');

INSERT INTO Paket (Kode_Paket, Nama_Paket, Harga_Perkilo) VALUES
('CK01','Cuci Kering', 5000),
('CS01','Cuci Setrika', 7000),
('SS01','Setrika Saja', 4000),
('EX01','Express (1 Hari)', 10000);

GO
CREATE VIEW v_Transaksi AS
SELECT * FROM Transaksi;
GO

CREATE PROCEDURE sp_LoginAdmin
@username varchar(50), @password varchar(50)
AS BEGIN 
    SELECT * FROM Pengelola WHERE Username=@username AND Passwordhash=@password
END;
GO

CREATE PROCEDURE sp_LoginKasir
@username varchar(50), @password varchar(50)
AS BEGIN 
    SELECT * FROM Kasir WHERE Username=@username AND Passwordhash=@password
END;
GO

CREATE PROCEDURE sp_GetTransaksi AS
BEGIN
    SELECT * FROM v_Transaksi
END;
GO

CREATE PROCEDURE sp_InsertTransaksi
    @kasir VARCHAR(50), @pelanggan VARCHAR(50), @paket VARCHAR(50),
    @harga DECIMAL(18,2), @berat DECIMAL(18,2), @total DECIMAL(18,2),
    @status VARCHAR(50), @tanggal DATE
AS
BEGIN
    INSERT INTO Transaksi (Nama_Kasir, Nama_Pelanggan, Kode_Paket, Harga, Berat, Total_Harga, Status_Laundry, Tanggal)
    VALUES (@kasir, @pelanggan, @paket, @harga, @berat, @total, @status, @tanggal)
END;
GO

CREATE PROCEDURE sp_UpdateTransaksi
    @id INT, @kasir VARCHAR(50), @pelanggan VARCHAR(50), @paket VARCHAR(50),
    @harga DECIMAL(18,2), @berat DECIMAL(18,2), @total DECIMAL(18,2),
    @status VARCHAR(50), @tanggal DATE
AS
BEGIN
    UPDATE Transaksi SET Nama_Kasir=@kasir, Nama_Pelanggan=@pelanggan, Kode_Paket=@paket, 
    Harga=@harga, Berat=@berat, Total_Harga=@total, Status_Laundry=@status, Tanggal=@tanggal
    WHERE ID_Transaksi = @id
END;
GO

CREATE PROCEDURE sp_DeleteTransaksi
    @id INT AS
BEGIN
    DELETE FROM Transaksi WHERE ID_Transaksi = @id
END;
GO

CREATE PROCEDURE sp_SearchTransaksi
    @keyword VARCHAR(100) AS
BEGIN
    SELECT * FROM v_Transaksi
    WHERE Nama_Pelanggan LIKE '%' + @keyword + '%'
       OR Nama_Kasir LIKE '%' + @keyword + '%'
       OR Kode_Paket LIKE '%' + @keyword + '%'
END;
GO

CREATE PROCEDURE sp_ReportLaundry
    @KodePaket VARCHAR(50), @Tahun INT
AS
BEGIN
    SELECT * FROM Transaksi T
    LEFT JOIN Paket P ON T.Kode_Paket = P.Kode_Paket 
    WHERE (T.Kode_Paket = @KodePaket OR P.Nama_Paket = @KodePaket) 
      AND YEAR(T.Tanggal) = @Tahun
END;
GO

CREATE TRIGGER trg_AfterInsertTransaksi
ON Transaksi
AFTER INSERT AS
BEGIN
    DECLARE @pelanggan VARCHAR(50);
    SELECT @pelanggan = Nama_Pelanggan FROM inserted;
    INSERT INTO LogAktivitas (Aktivitas) VALUES ('Sukses mencatat transaksi untuk ' + @pelanggan);
END;
GO