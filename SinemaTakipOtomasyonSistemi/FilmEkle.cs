using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace SinemaTakipOtomasyonSistemi
{
    public partial class FilmEkle : Form
    {
        public FilmEkle()
        {
            InitializeComponent();
        }
        SqlProcess SqlKutuphanem = new SqlProcess();
        MessageClass MesajKutuphanem = new MessageClass();
        List<string> TurIDListe = new List<string>();
        OpenFileDialog AfisSec = new OpenFileDialog();
        ArrayList TabloAlan = new ArrayList();
        ArrayList AlanVeri = new ArrayList();
        DragDropProvider Surukle;
        private void FilmEkle_Load(object sender, EventArgs e)
        {
            SqlKutuphanem.BaglantiAc();
            GorselDuzenlemeler();
            FilmTurleriniCek();
            AfisAyarlari();
           

        }
        private void GorselDuzenlemeler()
        {
            CbeTur.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            TeFilmAd.Properties.NullValuePrompt = "Film Adını Giriniz";
            TeFilmYonetmen.Properties.NullValuePrompt = "Film Yönetmen Bilgisini Giriniz";
            TeSure.Properties.NullValuePrompt = "00:00";
            TeYil.Properties.NullValuePrompt = "Örnek:2023";
            MeFilmKonu.Properties.NullValuePrompt = "Film oyuncuları, içeriği ve diğer bilgiler hakkında kısa bilgiler giriniz";
        }

        private void FilmTurleriniCek()
        {
            CbeTur.Properties.Items.Clear();
            CbeTur.Properties.Items.AddRange(SqlKutuphanem.SQLTabloAlanDiziReturn("TurAd", "TblTur", SqlKutuphanem.BaglantiAc()));
            TurIDListe.Clear();//
            foreach (string STurID in SqlKutuphanem.SQLTabloAlanDiziReturn("TurAd", "TblTur", SqlKutuphanem.BaglantiAc()))//Veriler ArrayList Üzerinden gelmektedir.
            {
                TurIDListe.Add(STurID);
            }
        }

        private void AfisAyarlari()
        {
            AfisSec.Title = "AFİŞ SEÇ";
            AfisSec.Multiselect = false;
            AfisSec.RestoreDirectory = true;
            AfisSec.Filter = "AFİŞ SEÇ | *jpg; *png;";
            Surukle = new DragDropProvider(PEAfis);
            Surukle.EnableDragDrop();
            PEAfis.Properties.ShowMenu = false;//SAĞ TIK MENÜLERİ KAPATTIM - LOAD-DELETE-CAM VS.
        }
        private void SBtnVezgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int TurIDKontrol = -1;
        private void CbeTur_SelectedIndexChanged(object sender, EventArgs e)
        {//Seçilen Türün ID Belirlenir Yok ise -1 yazılır.
            TurIDKontrol = TurIDListe.IndexOf(CbeTur.SelectedItem.ToString());
        }
        private void SBtnAfisSec_Click(object sender, EventArgs e)
        {
            if (AfisSec.ShowDialog() == DialogResult.OK)
            {
                PEAfis.Image = Image.FromFile(AfisSec.FileName);
            }
        }
        string AfisYeniAdres, AfisYeniAdresApplicationStart;
        private void SBtnKaydet_Click(object sender, EventArgs e)
        {
            if (TeFilmAd.Text != "")
            {
                if (TeFilmYonetmen.Text != "")
                {
                    if (CbeTur.SelectedIndex != -1)
                    {
                        if (TeSure.Text != "")
                        {
                            if (TeYil.Text != "")
                            {
                                if (MeFilmKonu.Text != "")
                                {
                                    if (AfisSec.FileName != "" || Surukle.FileLocation != "")
                                    {
                                        FilmParametreVeVerileri();
                                        try
                                        {
                                            if (SqlKutuphanem.SQLTabloAlanDiziAlanVeriInsert("TblFilmler", TabloAlan, AlanVeri, SqlKutuphanem.BaglantiAc()))
                                            {
                                                MesajKutuphanem.MesajGoster("KAYIT İŞLEMİ BAŞARILI", "FİLM KAYIT", 1);
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            MesajKutuphanem.MesajGoster("FİLM KAYIT İŞLEMİ BAŞARISIZ", "FİLM KAYIT", 2);
                                        }
                                    }
                                    else
                                    {
                                        MesajKutuphanem.MesajGoster("AFIŞ ALANI BOŞ BIRAKILAMAZ", "BOŞ ALAN", 3);
                                    }
                                }
                                else
                                {
                                    MesajKutuphanem.MesajGoster("FİLM KONU ALANI BOŞ BIRAKILAMAZ", "BOŞ ALAN", 3);
                                }
                            }
                            else
                            {
                                MesajKutuphanem.MesajGoster("FİLM YILI ALANI BOŞ BIRAKILAMAZ", "BOŞ ALAN", 3);
                            }
                        }
                        else
                        {
                            MesajKutuphanem.MesajGoster("FİLM SÜRE ALANI BOŞ BIRAKILAMAZ", "BOŞ ALAN", 3);
                        }
                    }
                    else
                    {
                        MesajKutuphanem.MesajGoster("FİLM TÜRÜ SEÇİLMELİ", "SEÇİLMEMİŞ ALAN", 3);
                    }
                }
                else
                {
                    MesajKutuphanem.MesajGoster("YÖNETMEN ALANI BOŞ BIRAKILAMAZ", "BOŞ ALAN", 3);
                }
            }
            else
            {
                MesajKutuphanem.MesajGoster("FİLM ADI ALANI BOŞ BIRAKILAMAZ", "BOŞ ALAN", 3);
            }
        }
        private void FilmParametreVeVerileri()
        {
            TabloAlan.Clear();
            AlanVeri.Clear();
            //10 ALAN İÇİN EKLEME ALANIN ADI DEĞİL SIRASI ÖNEMLİ OLDUĞU İÇİN HEPSİNE P1....P10 YAPILACAK
            for (int i = 0; i < 10; i++)
            {
                TabloAlan.Add("P" + i.ToString());
            }

            AlanVeri.Add(TeFilmAd.Text);
            AlanVeri.Add(TeFilmYonetmen.Text);
            AlanVeri.Add(TurIDKontrol);
            AlanVeri.Add(TeSure.Text);
            if (CheckYerli.Checked)
            {
                AlanVeri.Add(1);
            }
            else
            {
                AlanVeri.Add(0);
            }
            AlanVeri.Add(MeFilmKonu.Text);
            AlanVeri.Add(TeYil.Text);
            if (Check3D.Checked)
            {
                AlanVeri.Add(1);
            }
            else
            {
                AlanVeri.Add(0);
            }
            AfisYeniAdresApplicationStart= @"image\imageAfis\" + Guid.NewGuid() + ".jpg";
            AfisYeniAdres = Application.StartupPath +"\\"+ AfisYeniAdresApplicationStart;
            if (PEAfis.GetLoadedImageLocation() == "")
            {
                File.Copy(AfisSec.FileName, AfisYeniAdres);
            }
            else
            {
                File.Copy(PEAfis.GetLoadedImageLocation(), AfisYeniAdres);
            }

            AlanVeri.Add(AfisYeniAdresApplicationStart);
            AlanVeri.Add(1);//ARŞİV  1 TRUE
        }

        private void PEAfis_DragDrop(object sender, DragEventArgs e)
        {//Sürükle bırak yöntemi ile fotoğrafları getiriyor fakat dosya yolunu getirmiyordu dosya yolu oluşturuldu ve çağrıldı eklenmesi için dragdrop eventi kullanıldı.
            AfisSec.FileName = Surukle.FileLocation;
        }
    }
}
