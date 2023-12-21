using OkulApp.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gazi.OkulAppSube2BLG
{
    public partial class frmOgrKayit : Form
    {
        public frmOgrKayit()
        {
            InitializeComponent();
        }

        bool OgrenciEkle(Ogrenci ogr)
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=OkulDbSube2BLG;Integrated Security=true");
                SqlCommand cmd = new SqlCommand($"Insert into tblOgrenciler (Ad,Soyad,Numara) values ('{ogr.Ad}','{ogr.Soyad}','{ogr.Numara}')", cn);
                cn.Open();
                int sonuc = cmd.ExecuteNonQuery();
                return sonuc > 0;
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (cn != null && cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                var ogrenci = new Ogrenci();
                ogrenci.Ad = txtAd.Text.Trim();
                ogrenci.Soyad = txtSoyad.Text.Trim();
                ogrenci.Numara = txtNumara.Text.Trim();

                bool sonuc = OgrenciEkle(ogrenci);
                MessageBox.Show(sonuc ? "Ekleme başarılı!" : "Ekleme başarısız!!");
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2627:
                        MessageBox.Show("Bu numara daha önce kayıtlı");
                        break;
                    default:
                        MessageBox.Show("Veritabanı Hatası!");
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bir hata oluştu!!");
            }
        }
    }
}
