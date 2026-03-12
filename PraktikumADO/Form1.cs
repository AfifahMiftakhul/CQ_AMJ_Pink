using System;
using System.Windows.Forms;
using System.Data.SqlClient;

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
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {

                Koneksi();
                conn.Open();

                MessageBox.Show("Koneksi Berhasil");
                conn.Close();
            }
            catch (Exception ex) {

        }
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
                txtHasil.Text = "Jumlah Mahasiswa: " + jumlah.ToString();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // PRAKTIKUM 3: Menghitung Jumlah Mata Kuliah (ExecuteScalar)
        private void btnHitungMK_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();

                string query = "SELECT COUNT(*) FROM MataKuliah";
                cmd = new SqlCommand(query, conn);

                int jumlah = (int)cmd.ExecuteScalar();
                txtHasil.Text = "Jumlah Mata Kuliah: " + jumlah.ToString();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        // PRAKTIKUM 4: Update Data Mahasiswa (ExecuteNonQuery)
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
                txtHasil.Text = "Update berhasil, " + hasil + " baris diupdate";

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
                txtHasil.Text = "Jumlah Dosen: " + jumlah.ToString();

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
                txtHasil.Text = "Update SKS berhasil, " + hasil + " baris diupdate";

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
                txtHasil.Text = "Insert Prodi berhasil, " + hasil + " baris ditambahkan";

                conn.Close();
            }
        }
}
