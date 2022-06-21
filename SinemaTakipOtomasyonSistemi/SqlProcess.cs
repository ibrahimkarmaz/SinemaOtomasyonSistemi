using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;


namespace SinemaTakipOtomasyonSistemi
{
    /* NOT SAHİBİ:İBRAHİM KARMAZ
     * KENDİME NOTLAR;
     *BAZI İŞLEMLERDE HANTAL KALIYOR. DAHA DÜZGÜN BİR KOD SİSTEMİ YAPILACAK.
     *İNSERT VB. İŞLEMLERİNDE PARAMETRE YOLLAMADAN SADECE PARAMETRE SAYISIYLA İŞLEM YAPILABILIR MI ? KONTROL ET
     *PROC,FOKSİYON VB YAPILAR İÇİN ÖZEL METOTLAR GELİŞTİRİLMELİ
     */
    class SqlProcess
    {
        static SqlCommand komut;
        static SqlDataReader oku;
        static SqlDataAdapter KomutAdapte;
        DataSet TabloSeti = new DataSet();
        static string BaglantiAdresi = "";
        public SqlConnection BaglantiAc()
        {
            StreamReader DosyaYolu = new StreamReader("Config.txt");
            foreach(var BaglantiBilgileri in DosyaYolu.ReadLine())
            {
                if (BaglantiBilgileri != null)
                {
                    BaglantiAdresi += BaglantiBilgileri;
                }
            }
            SqlConnection baglanti = new SqlConnection(BaglantiAdresi.ToString());
            baglanti.Open();
            return baglanti;
        }

        public ArrayList SQLTabloAlanDiziReturn(string AlanAd, string TabloAd, SqlConnection baglanti_adresi)
        {
            /*METOT İŞLEYİŞ ŞEKLİ:ŞARTSIZ BİR ALANDAN VERİ ÇEKİLECEK İSE KULLANILIR*/
            ArrayList Liste = new ArrayList();
            try
            {
                komut = new SqlCommand("select " + AlanAd + " from " + TabloAd, baglanti_adresi);
                oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    Liste.Add(oku[AlanAd].ToString().Trim());
                }
            }
            catch (Exception HATA)
            {
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Liste;
        }

        public ArrayList SQLTabloAlanSartDiziReturn(string AlanAd, string TabloAd, string Sart, SqlConnection baglanti_adresi)
        {/*METOT İŞLEYİŞ: ŞARTLI OLUP TEK BİR ALANDAN VERİ ÇEKİLECEK İSE KULLANILIR.*/
            ArrayList IllerListei = new ArrayList();
            try//HATA ENGELLEYİCİ
            {
                komut = new SqlCommand("select " + AlanAd + " from " + TabloAd + " where " + Sart, baglanti_adresi);
                oku = komut.ExecuteReader();//KOMUTLARI ÇALIŞTIRIP VERİLERİ SAKLADIĞIMIZ KOMUT
                while (oku.Read())//VERİ VARSA ÇALIŞACAK YER
                {
                    IllerListei.Add(oku[AlanAd].ToString().Trim());
                }
            }
            catch (Exception HATA)//HATA OLURSA GİRECEĞİ YER
            {
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);//HATA BİLGİSİ MESAJ PENCERESİ İLE KULLANICIYA GÖSTERİLDİ.
            }
            return IllerListei;
        }

        public bool SQLTabloAlanDiziAlanVeriInsert(string TabloAd, ArrayList TabloAlan, ArrayList AlanVeri, SqlConnection baglanti_adresi)
        {/*METOT İŞLEYİŞ:ALAN ADETİNE GÖRE VERİ EKLEMEK İÇİN KULLANILAN METOTDUR GERİ DÖNÜŞ DEĞERİ ALINMASININ SEBEBİ BURADA Kİ İŞLEMLERİN GERÇEKLEŞİP GERÇEKLEŞMEDİĞİDİR.*/
            //TRY CATCH BLOKLARININ KONMAMA NEDENİ EKLEME SIRASINDA Kİ HATALARIN BELLİ BAŞLI SORUNLARDAN OLABİLECEĞİ VE BU MOTUTU ÇAĞRIRKEN BUNA GÖRE BİR KULLANICIYA AÇIKLAMA YAZABİLİRİZ.
            string AlanAdlariniBirlestirVeOnuneETIsaretiKoy = "";
            foreach (string EklenenecekAlan in TabloAlan)
            {
                AlanAdlariniBirlestirVeOnuneETIsaretiKoy += "@" + EklenenecekAlan + ",";
            }
            Console.WriteLine(AlanAdlariniBirlestirVeOnuneETIsaretiKoy);
            AlanAdlariniBirlestirVeOnuneETIsaretiKoy = AlanAdlariniBirlestirVeOnuneETIsaretiKoy.Substring(0, AlanAdlariniBirlestirVeOnuneETIsaretiKoy.Length - 1);
            komut = new SqlCommand("insert into " + TabloAd + " values(" + AlanAdlariniBirlestirVeOnuneETIsaretiKoy + ")", baglanti_adresi);
            for (int i = 0; i < TabloAlan.Count; i++)
            {
                komut.Parameters.AddWithValue(("@" + TabloAlan[i]), AlanVeri[i]);
                Console.WriteLine(("@" + TabloAlan[i]) + "     " + AlanVeri[i]);
            }
            komut.ExecuteNonQuery();
            return true;
        }

        public bool SQLTabloAlanSartBenzersizlikKontrolReturn(string AlanAd, string TabloAd, string Sart, SqlConnection baglanti_adresi)
        {//METOT İŞLEYİŞ; TEK ŞARTA GÖRE VERİTABANINDA ŞARTTA KI KAYİTİN VAR OLUP OLMAMASI
            komut = new SqlCommand("select " + AlanAd + " from " + TabloAd + " where " + AlanAd + "=@P1", baglanti_adresi);
            komut.Parameters.AddWithValue("@P1", Sart);
            oku = komut.ExecuteReader();
            if (oku.Read())
            {
                return true;

            }
            return false;

        }
        public DataSet SQLTabloAlanVeriDataGridViewReturn(string TabloAd, SqlConnection baglanti_adresi)
        {//METOT İŞEYİŞ: ŞARTSIZ DİREK TABLOYU ÇEKME
            TabloSeti.Clear();
            KomutAdapte = new SqlDataAdapter("select * from " + TabloAd, baglanti_adresi);
            KomutAdapte.Fill(TabloSeti);
            return TabloSeti;
        }

        public DataSet SQLTabloAlanVeriSartDataGridViewReturn(ArrayList AlanAd, string TabloAd, ArrayList Sart, SqlConnection baglanti_adresi)
        {
            try
            {
                string SartBlogunuOlustur = "";
                for (int i = 0; i < AlanAd.Count; i++)
                {
                    SartBlogunuOlustur += AlanAd[i] + "=" + Sart[i] + " and ";
                }
                SartBlogunuOlustur = SartBlogunuOlustur.Substring(0, (SartBlogunuOlustur.Length - 5));


                TabloSeti.Clear();
                KomutAdapte = new SqlDataAdapter("select * from " + TabloAd + " where " + SartBlogunuOlustur, baglanti_adresi);
                KomutAdapte.Fill(TabloSeti);
                return TabloSeti;
            }
            catch (Exception HATA)//HATA OLURSA GİRECEĞİ YER
            {
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return TabloSeti;
        }

        public DataSet SQLTabloAlanVeriSartDataGridViewSearchReturn(ArrayList AlanAd, string TabloAd, ArrayList Sart, SqlConnection baglanti_adresi)
        {
            try
            {
                string SartBlogunuOlustur = "";
                for (int i = 0; i < AlanAd.Count; i++)
                {
                    SartBlogunuOlustur += AlanAd[i] + " like '%" + Sart[i] + "%' and ";

                }
                SartBlogunuOlustur = SartBlogunuOlustur.Substring(0, (SartBlogunuOlustur.Length - 5));
                Console.WriteLine(SartBlogunuOlustur);

                TabloSeti.Clear();
                KomutAdapte = new SqlDataAdapter("select * from " + TabloAd + " where " + SartBlogunuOlustur, baglanti_adresi);
                KomutAdapte.Fill(TabloSeti);
                return TabloSeti;
            }
            catch (Exception HATA)//HATA OLURSA GİRECEĞİ YER
            {
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return TabloSeti;
        }

        public bool SQLTabloAlanVeriSartVeriUpdateReturn(string TabloAd, ArrayList AlanAd, ArrayList AlanVeri, ArrayList SartAlan, ArrayList SartVeri, SqlConnection baglanti_adresi)
        {
            try
            {
                string GuncellenencekAlanVeriBirlestir = "";
                for (int i = 0; i < AlanAd.Count; i++)
                {
                    GuncellenencekAlanVeriBirlestir += AlanAd[i] + "=@P" + i + ",";

                }
                GuncellenencekAlanVeriBirlestir = GuncellenencekAlanVeriBirlestir.Substring(0, (GuncellenencekAlanVeriBirlestir.Length - 1));

                string SartBlogunuOlustur = "";
                for (int i = 0; i < SartAlan.Count; i++)
                {
                    SartBlogunuOlustur += SartAlan[i] + "=@V" + i.ToString() + " and ";
                }
                SartBlogunuOlustur = SartBlogunuOlustur.Substring(0, (SartBlogunuOlustur.Length - 5));

                komut = new SqlCommand("update " + TabloAd + " set " + GuncellenencekAlanVeriBirlestir + " where " + SartBlogunuOlustur, baglanti_adresi);
                for (int a = 0; a < AlanVeri.Count; a++)
                {
                    komut.Parameters.AddWithValue("@P" + (a.ToString()), AlanVeri[a].ToString());
                }
                for (int b = 0; b < SartVeri.Count; b++)
                {
                    komut.Parameters.AddWithValue("@V" + (b.ToString()), SartVeri[b]);
                }
                komut.ExecuteNonQuery();
                return true;
            }
            catch (Exception HATA)//HATA OLURSA GİRECEĞİ YER
            {
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public bool SQLTabloAlanVeriSartVeriDeleteReturn(string TabloAd, ArrayList SartAlan, ArrayList SartVeri, SqlConnection baglanti_adresi)
        {
            try
            {
                string SartBlogunuOlustur = "";
                for (int i = 0; i < SartAlan.Count; i++)
                {
                    SartBlogunuOlustur += SartAlan[i] + "=@V" + i.ToString() + " and ";
                }
                SartBlogunuOlustur = SartBlogunuOlustur.Substring(0, (SartBlogunuOlustur.Length - 5));

                komut = new SqlCommand("Delete from " + TabloAd + " where " + SartBlogunuOlustur, baglanti_adresi);
                for (int b = 0; b < SartVeri.Count; b++)
                {
                    komut.Parameters.AddWithValue("@V" + (b.ToString()), SartVeri[b]);
                }
                komut.ExecuteNonQuery();
                return true;
            }
            catch (Exception HATA)//HATA OLURSA GİRECEĞİ YER
            {
                MessageBox.Show(HATA.ToString() + "\nSİSTEM DIŞI HATA OLUŞMUŞTUR...", "KONTROL DIŞI HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public DataSet SQLKodDataGridViewReturn(string SQLKOD, SqlConnection baglanti_adresi)
        {//METOT İŞEYİŞ: YAZILAN KODU GELİR
            //GENELLİKLE FOKSİYON,PROC VB İŞLEMLER İÇİN KULLANILIR
            TabloSeti.Clear();
            KomutAdapte = new SqlDataAdapter(SQLKOD, baglanti_adresi);
            KomutAdapte.Fill(TabloSeti);
            return TabloSeti;
        }

    }
}
