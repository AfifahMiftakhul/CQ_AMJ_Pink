using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace PraktikumADO
{
    public partial class Form1 : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        public Form1()
        {

            InitializeComponent();
        }
        private void Koneksi()
        {
            conn = new SqlConnection(
                "Data Source=DESKTOP-4G4UMV8\\AFIFAH ; Initial Catalog=DBAkademiADO;Integrated Security=True");
        }
        private void label1_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn == null)
                {
                    MessageBox.Show("klick tombol connect .",
                        "informasi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                  
                    string info = "APLIKASI PRAKTIKUM ADO.NET\n\n" +
                                 "Fungsi Tombol:\n" +
                                 "• Connect : Membuka koneksi database\n" +
                                 "• Hitung Mahasiswa : jumlah data mahasiswa\n" +
                                 "• Hitung Matakuliah :  jumlah data matakuliah\n" +
                                 "• Update Mahasisw jumlah dosen\n" +
                                 "• Update SKS :  SKS matakuliah\n" +
                                 "• Insert Prodi :  data program studi\n\n" +
                                 $"Status Koneksi: {(conn.State == System.Data.ConnectionState.Open ? "Terbuka" : "Tertutup")}\n" +
                                 $"Server: DESKTOP-RAM2OFI\\APRILIYA\n" +
                                 $"Database: DBAkademikADO";

                    MessageBox.Show(info,
                                  "Informasi Aplikasi",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saat menampilkan informasi: " + ex.Message);
            }
        

    
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {

                Koneksi();
                conn.Open();

                MessageBox.Show("Koneksi Berhasil");
                conn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Koneksi Gagal: " +
                    ex.Message);
            }
        }

        private void btnHitungMhs_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();

                string query = "SELECT CIUNT (*) FROM Mahasiswa";
                cmd = new
                    SqlCommand(query, conn);
                int jumlah = (int)cmd.ExecuteScalar();
                textHasil.Text = "Jumlah Mahasiswa: " + jumlah.ToString();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnHitungMK_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();

                string query = "SELECT COUNT(*) FROM MataKuliah";
                cmd = new SqlCommand(query, conn);

                int jumlah = (int)cmd.ExecuteScalar();
                textHasil.Text = "Jumlah Mata Kuliah: " + jumlah.ToString();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();

                string query = "UPDATE Mahasiswa SET Alamat='Yogyakarta' WHERE NIM='23110100001'";
                cmd = new SqlCommand(query, conn);
                int hasil = cmd.ExecuteNonQuery();
                MessageBox.Show("Jumlah baris terpengaruh: " + hasil);
                textHasil.Text = "Update berhasil, " + hasil + " baris diupdate";

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void btnHitungDosen_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();

                string query = "SELECT COUNT(*) FROM Dosen";
                cmd = new SqlCommand(query, conn);
                int jumlah = (int)cmd.ExecuteScalar();
                textHasil.Text = "Jumlah Dosen: " + jumlah.ToString();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void btnUpdateSKS_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();

                string query = "UPDATE MataKuliah SET SKS = 4 WHERE KodeMK = 'IF210101'";
                cmd = new SqlCommand(query, conn);
                int hasil = cmd.ExecuteNonQuery();
                MessageBox.Show("Jumlah baris terpengaruh: " + hasil);
                textHasil.Text = "Update SKS berhasil, " + hasil + " baris diupdate";

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void btnInsertProdi_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();

                string query = "INSERT INTO ProgramStudi VALUES ('MI01','Manajemen Informatika')";
                cmd = new SqlCommand(query, conn);
                int hasil = cmd.ExecuteNonQuery();
                MessageBox.Show("Jumlah baris terpengaruh: " + hasil);
                textHasil.Text = "Insert Prodi berhasil, " + hasil + " baris ditambahkan";

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}

