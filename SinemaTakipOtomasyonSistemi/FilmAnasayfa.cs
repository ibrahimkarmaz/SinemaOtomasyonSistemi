using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;
using System.IO;
using System.Collections;
using DevExpress.XtraGrid.Views.Base;


namespace SinemaTakipOtomasyonSistemi
{
    public partial class FilmAnasayfa : Form
    {
        public FilmAnasayfa()
        {
            InitializeComponent();
        }
        SqlProcess SqlKutuphanem = new SqlProcess();
        private void FilmAnasayfa_Load(object sender, EventArgs e)
        {
            TabloGetir();
            TabloDuzen();
            AddUnboundColumn(GViewTabloGoster); 
            AssignPictureEdittoImageColumn(GViewTabloGoster.Columns["Image"]);
        }
        private void TabloGetir()
        {
            this.Text = "FİLM LİSTESİ";
            GControlDatabase.DataSource = SqlKutuphanem.SQLKodDataGridViewReturn("select * from TblFilmler", SqlKutuphanem.BaglantiAc()).Tables[0];
        }
        private void TabloDuzen()
        {//OptionsBehavior: Seçenekler Davranış(TR)
            /*GViewTabloGoster.OptionsBehavior.Editable = false;//VERİTABANINDAN ÇEKİLEN TABLO ÜZERİNDE HERHANGİ BİR DEĞİŞİKLİK YAPILMASINI ENGELLİYOR.
            GViewTabloGoster.Columns["FilmAd"].Caption = "FİLM ADI";
            GViewTabloGoster.Columns["FilmYonetmen"].Caption = "FİLM YÖNETMENİ";
            GViewTabloGoster.Columns["TurAd"].Caption = "FİLM TÜRÜ";
            GViewTabloGoster.Columns["FilmSure"].Caption = "FİLM SÜRESİ";
            GViewTabloGoster.Columns["FilmYerli"].Caption = "FİLM MENŞEİ";
            GViewTabloGoster.Columns["FilmKonu"].Caption = "FİLM KONUSU";
            GViewTabloGoster.Columns["FilmYil"].Caption = "FİLM YILI";
            GViewTabloGoster.Columns["D3"].Caption = "3D";*/

        }

        private void SBtnYeniKayit_Click(object sender, EventArgs e)
        {
            FilmEkle YeniFilm = new FilmEkle();
            YeniFilm.ShowDialog();
        }

        private void GControlFilm_Paint(object sender, PaintEventArgs e)
        {

        }
        void AddUnboundColumn(GridView view)
        {
            // Create an unbound column.
            GridColumn colImage = new GridColumn();
            colImage.FieldName = "Image";
            colImage.Caption = "AFİŞ";
            colImage.UnboundType = UnboundColumnType.Object;
            colImage.OptionsColumn.AllowEdit = false;
            colImage.Visible = true;

            // Add the Image column to the grid's Columns collection.
            view.Columns.Add(colImage);
        }
        void AssignPictureEdittoImageColumn(GridColumn column)
        {
            // Create and customize the PictureEdit repository item.
            RepositoryItemPictureEdit riPictureEdit = new RepositoryItemPictureEdit();
            riPictureEdit.SizeMode = PictureSizeMode.Zoom;

            // Add the PictureEdit to the grid's RepositoryItems collection.
            GControlDatabase.RepositoryItems.Add(riPictureEdit);

            // Assign the PictureEdit to the 'Image' column.
            column.ColumnEdit = riPictureEdit;
        }

        Dictionary<string, Image> imageCache = new Dictionary<string, Image>(StringComparer.OrdinalIgnoreCase);

        private void GViewTabloGoster_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "Image" && e.IsGetData)
            {
                GridView view = sender as GridView;
                string fileName = view.GetRowCellValue(view.GetRowHandle(e.ListSourceRowIndex), "FilmAfisResim") as string ?? string.Empty;
                if (!imageCache.ContainsKey(fileName))
                {
                    Image img = null;
                    if (File.Exists(fileName))
                        img = Image.FromFile(fileName);
                    else
                        img = Image.FromFile(@"image\AfisYok.jpg");

                    imageCache.Add(fileName, img);
                }
                e.Value = imageCache[fileName];
            }
        }
    }
}
