
namespace SinemaTakipOtomasyonSistemi
{
    partial class FilmAnasayfa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SBtnYeniKayit = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.GControlFilm = new DevExpress.XtraEditors.GroupControl();
            this.GControlDatabase = new DevExpress.XtraGrid.GridControl();
            this.GViewTabloGoster = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.GControlFilm)).BeginInit();
            this.GControlFilm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GControlDatabase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GViewTabloGoster)).BeginInit();
            this.SuspendLayout();
            // 
            // SBtnYeniKayit
            // 
            this.SBtnYeniKayit.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.SBtnYeniKayit.Appearance.Options.UseFont = true;
            this.SBtnYeniKayit.ImageOptions.Image = global::SinemaTakipOtomasyonSistemi.Properties.Resources.add_32x32;
            this.SBtnYeniKayit.Location = new System.Drawing.Point(12, 31);
            this.SBtnYeniKayit.Name = "SBtnYeniKayit";
            this.SBtnYeniKayit.Size = new System.Drawing.Size(110, 40);
            this.SBtnYeniKayit.TabIndex = 0;
            this.SBtnYeniKayit.Text = "Yeni";
            this.SBtnYeniKayit.Click += new System.EventHandler(this.SBtnYeniKayit_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.ImageOptions.Image = global::SinemaTakipOtomasyonSistemi.Properties.Resources.pencolor_32x32;
            this.simpleButton2.Location = new System.Drawing.Point(128, 31);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(110, 40);
            this.simpleButton2.TabIndex = 1;
            this.simpleButton2.Text = "Düzenle";
            // 
            // simpleButton3
            // 
            this.simpleButton3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.simpleButton3.Appearance.Options.UseFont = true;
            this.simpleButton3.ImageOptions.Image = global::SinemaTakipOtomasyonSistemi.Properties.Resources.remove_32x32;
            this.simpleButton3.Location = new System.Drawing.Point(244, 31);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(110, 40);
            this.simpleButton3.TabIndex = 2;
            this.simpleButton3.Text = "Çıkar";
            // 
            // GControlFilm
            // 
            this.GControlFilm.Controls.Add(this.simpleButton3);
            this.GControlFilm.Controls.Add(this.SBtnYeniKayit);
            this.GControlFilm.Controls.Add(this.simpleButton2);
            this.GControlFilm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GControlFilm.Location = new System.Drawing.Point(0, 428);
            this.GControlFilm.Name = "GControlFilm";
            this.GControlFilm.Size = new System.Drawing.Size(919, 79);
            this.GControlFilm.TabIndex = 5;
            this.GControlFilm.Text = "Film İşlemleri";
            this.GControlFilm.Paint += new System.Windows.Forms.PaintEventHandler(this.GControlFilm_Paint);
            // 
            // GControlDatabase
            // 
            this.GControlDatabase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GControlDatabase.Location = new System.Drawing.Point(0, 0);
            this.GControlDatabase.MainView = this.GViewTabloGoster;
            this.GControlDatabase.Name = "GControlDatabase";
            this.GControlDatabase.Size = new System.Drawing.Size(919, 428);
            this.GControlDatabase.TabIndex = 6;
            this.GControlDatabase.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GViewTabloGoster});
            // 
            // GViewTabloGoster
            // 
            this.GViewTabloGoster.GridControl = this.GControlDatabase;
            this.GViewTabloGoster.Name = "GViewTabloGoster";
            this.GViewTabloGoster.OptionsView.ShowGroupPanel = false;
            this.GViewTabloGoster.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.GViewTabloGoster_CustomUnboundColumnData);
            // 
            // FilmAnasayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(919, 507);
            this.Controls.Add(this.GControlDatabase);
            this.Controls.Add(this.GControlFilm);
            this.Name = "FilmAnasayfa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FilmAnasayfa";
            this.Load += new System.EventHandler(this.FilmAnasayfa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GControlFilm)).EndInit();
            this.GControlFilm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GControlDatabase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GViewTabloGoster)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton SBtnYeniKayit;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.GroupControl GControlFilm;
        private DevExpress.XtraGrid.GridControl GControlDatabase;
        private DevExpress.XtraGrid.Views.Grid.GridView GViewTabloGoster;
    }
}