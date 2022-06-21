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
using DevExpress.XtraEditors;

namespace SinemaTakipOtomasyonSistemi
{
    class MessageClass
    {
        public void MesajGoster(string icerik="Veri Bulunamadı",string Baslik="Veri",byte simge=1)
        {
            switch (simge)
            {
                case 1://BİLGİ
                    XtraMessageBox.Show(icerik,Baslik,MessageBoxButtons.OK,MessageBoxIcon.Information);
                    break;
                case 2://HATA
                    XtraMessageBox.Show(icerik, Baslik, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 3://UYARI
                    XtraMessageBox.Show(icerik, Baslik, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case 4://SORU
                    XtraMessageBox.Show(icerik, Baslik, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    break;
                default://DEFAULT BİLGİ
                    XtraMessageBox.Show(icerik, Baslik, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

    }
}
