CREATE DATABASE DBBersihKu;
GO 

USE DBBersihKu;
GO

CREATE TABLE Kasir (
	ID_Kasir INT IDENTITY(1,1) PRIMARY KEY,
	NamaKasir VARCHAR(100) NOT NULL,
	Username VARCHAR(25) NOT NULL,
	Passwordhash Varchar(255) NOT NULL
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
  Tanggal DATETIME DEFAULT GETDATE(),
  Berat DECIMAL(5,2),
  Total_Harga DECIMAL(10,2),
  Status_Laundry VARCHAR(50) DEFAULT 'diterima',
  CONSTRAINT FK_Paket
    FOREIGN KEY (Kode_Paket) REFERENCES Paket(Kode_Paket)
);

ALTER TABLE Transaksi
ALTER COLUMN Jenis_Paket VARCHAR(50);

CREATE TABLE USERLOGIN (
	ID_LOGIN INT IDENTITY(1,1) PRIMARY KEY,
	ID_Kasir INT,
	ID_Admin INT,
	Username VARCHAR(50) UNIQUE NOT NULL,
	Passwordhash VARCHAR(255) NOT NULL,
	RoleUser VARCHAR(20) CHECK (RoleUser IN ('Admin', 'Kasir'))
	CONSTRAINT FK_User_Kasir
		FOREIGN KEY (ID_kasir) REFERENCES Kasir(ID_Kasir),
	CONSTRAINT FK_User_Admin
		FOREIGN KEY (ID_Admin) REFERENCES Pengelola(ID_Admin)
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
('Reza Arap', '083456789012', 'Yogyakarta'),
('Sumanto', '084567890123', 'Bantul'),
('', '085678901234', 'Kulon Progo');


	INSERT INTO Paket (Kode_Paket,Nama_Paket, Harga_Perkilo) VALUES
	('CK01','Cuci Kering', 5000),
	('CS01','Cuci Setrika', 7000),
	('SS01','Setrika Saja', 4000),
	('EX01','Express (1 Hari)', 10000);

INSERT INTO Transaksi (Nama_Kasir, Nama_Pelanggan, Kode_Paket, Berat, Total_Harga, Status_Laundry) VALUES
('Nela Andriani', 'Mulyono','CS01', 2.5, 12500, 'diterima'),
('Seyla Avina', 'Tenxii', 'EX01', 3.0, 21000, 'proses');



select * from Transaksi;
select * from Pelanggan;
select * from Kasir;
select * from paket;


DELETE FROM Transaksi
WHERE ID_Transaksi IN (2,3,4,5,6);