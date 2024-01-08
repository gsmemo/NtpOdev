using OkulApp.BLL;
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
        public int Ogrenciid { get; set; }
        public frmOgrKayit()
        {
            InitializeComponent();
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
        }


        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
          

                var obl = new OgrenciBL();
                bool sonuc = obl.OgrenciEkle(new Ogrenci { Ad = txtAd.Text.Trim(), Soyad = txtSoyad.Text.Trim(), Numara = txtNumara.Text.Trim() });
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

        private void btnBul_Click(object sender, EventArgs e)
        {
            try
            {
                txtAd.Clear();
                txtSoyad.Clear();
                txtNumara.Clear();
                var frm = new frmOgrBul(this);
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception hatası:" + ex.Message);
            }



        }
        
          
        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                txtAd.Clear();
                txtSoyad.Clear();
                txtNumara.Clear();
                var obl = new OgrenciBL();
                MessageBox.Show(obl.OgrenciSil(Ogrenciid) ? "Silme Başarılı" : "Başarısız!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata:"+ ex.Message );
            }
            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                txtAd.Clear();
                txtSoyad.Clear();
                txtNumara.Clear();
                var obl = new OgrenciBL();
                MessageBox.Show(obl.OgrenciGuncelle(new Ogrenci { Ad = txtAd.Text.Trim(), Soyad = txtSoyad.Text.Trim(), Numara = txtNumara.Text.Trim(), Ogrenciid = Ogrenciid }) ? "Güncelleme Başarılı" : "Güncelleme Başarısız!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("hata:" + ex.Message);
           
            }
            
        }
    }

    interface ITransfer
    {
        int EFT(string aliciiban, string gondereniban, double tutar);
        int Havale(string aliciiban, string gondereniban, double tutar, DateTime tarih);
    }

    class TransferIslemleri : ITransfer
    {
        public int EFT(string aliciiban, string gondereniban, double tutar)
        {
            throw new NotImplementedException();
        }

        public int Havale(string aliciiban, string gondereniban, double tutar, DateTime tarih)
        {
            throw new NotImplementedException();
        }
    }
}
