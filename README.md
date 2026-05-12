# Sistem Laundry BersihKu

### Screenshot Aplikasi
#### 1. Form Login
<img width="1061" height="548" alt="image" src="https://github.com/user-attachments/assets/6000fa70-29ca-4038-b26b-387c629ceaa7" />

#### 2. Form Input Data & Koneksi (kasir)
<img width="1132" height="745" alt="image" src="https://github.com/user-attachments/assets/221e0bff-3d2a-4904-aa05-85d0dc0fba1d" />

#### 3. Form Riwayat Transaksi (Admin)
<img width="1316" height="722" alt="image" src="https://github.com/user-attachments/assets/f0a0558c-b39c-497d-bdf9-6d9cc76e9ee9" />

#### 4. Bukti Operasi (CRUD)
* **Tambah Data:** <img width="1136" height="758" alt="image" src="https://github.com/user-attachments/assets/8f32b821-f7fb-4e75-8233-5fff9432d32c" />

* **Update Data:** <img width="1342" height="747" alt="image" src="https://github.com/user-attachments/assets/4e2e5049-7b32-46b6-b613-d807eae77d59" />

* **Hapus Data:** <img width="1327" height="727" alt="image" src="https://github.com/user-attachments/assets/7fb75340-74fe-4ed7-9934-18a73a7e133f" />

### 5. Alur SQL Injection:
Sistem login ini aman dari SQL Injection karena menggunakan Stored Procedure dan Parameterized Query, di mana input pengguna dipisahkan dari logika perintah SQL dan diperlakukan murni sebagai data biasa (string). Dengan metode ini, karakter berbahaya seperti ' OR 1=1 -- tidak akan dieksekusi oleh database, sehingga struktur query tetap terjaga dan upaya manipulasi autentikasi dapat dicegah secara efektif.
