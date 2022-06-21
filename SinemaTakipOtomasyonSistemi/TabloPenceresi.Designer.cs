
namespace SinemaTakipOtomasyonSistemi
{
    partial class TabloPenceresi
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
            this.GControlDatabase = new DevExpress.XtraGrid.GridControl();
            this.GViewTabloGoster = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.GControlDatabase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GViewTabloGoster)).BeginInit();
            this.SuspendLayout();
            // 
            // GControlDatabase
            // 
            this.GControlDatabase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GControlDatabase.Location = new System.Drawing.Point(0, 0);
            this.GControlDatabase.MainView = this.GViewTabloGoster;
            this.GControlDatabase.Name = "GControlDatabase";
            this.GControlDatabase.Size = new System.Drawing.Size(840, 482);
            this.GControlDatabase.TabIndex = 0;
            this.GControlDatabase.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GViewTabloGoster});
            // 
            // GViewTabloGoster
            // 
            this.GViewTabloGoster.GridControl = this.GControlDatabase;
            this.GViewTabloGoster.Name = "GViewTabloGoster";
            this.GViewTabloGoster.OptionsView.ShowGroupPanel = false;
            // 
            // TabloPenceresi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 482);
            this.Controls.Add(this.GControlDatabase);
            this.Name = "TabloPenceresi";
            this.Text = "TabloPenceresi";
            this.Load += new System.EventHandler(this.TabloPenceresi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GControlDatabase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GViewTabloGoster)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl GControlDatabase;
        private DevExpress.XtraGrid.Views.Grid.GridView GViewTabloGoster;
    }
}