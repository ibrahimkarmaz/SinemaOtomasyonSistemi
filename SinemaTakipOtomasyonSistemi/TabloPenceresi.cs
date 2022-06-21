using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SinemaTakipOtomasyonSistemi
{
    public partial class TabloPenceresi : Form
    {
        public TabloPenceresi()
        {
            InitializeComponent();
        }
        SqlProcess SqlKutuphanem = new SqlProcess();
        private void TabloPenceresi_Load(object sender, EventArgs e)
        {
            TabloGetir();
            TabloDuzen();

        }
        private void TabloGetir()
        {
            this.Text = "FİLM LİSTESİ";
            GControlDatabase.DataSource = SqlKutuphanem.SQLKodDataGridViewReturn("select * from VWTblFilmAktif", SqlKutuphanem.BaglantiAc()).Tables[0];
        }
        private void TabloDuzen()
        {//OptionsBehavior: Seçenekler Davranış(TR)
            GViewTabloGoster.OptionsBehavior.Editable = false;//VERİTABANINDAN ÇEKİLEN TABLO ÜZERİNDE HERHANGİ BİR DEĞİŞİKLİK YAPILMASINI ENGELLİYOR.
            GViewTabloGoster.Columns["FilmAd"].Caption = "FİLM ADI";
            GViewTabloGoster.Columns["FilmYonetmen"].Caption = "FİLM YÖNETMENİ";
            GViewTabloGoster.Columns["TurAd"].Caption = "FİLM TÜRÜ";
            GViewTabloGoster.Columns["FilmSure"].Caption = "FİLM SÜRESİ";
            GViewTabloGoster.Columns["FilmYerli"].Caption = "FİLM MENŞEİ";
            GViewTabloGoster.Columns["FilmKonu"].Caption = "FİLM KONUSU";
            GViewTabloGoster.Columns["FilmYil"].Caption = "FİLM YILI";
            GViewTabloGoster.Columns["D3"].Caption = "3D";
        }
    }
}
