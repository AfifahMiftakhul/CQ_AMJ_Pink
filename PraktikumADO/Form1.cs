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
        }
    }
}
