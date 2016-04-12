using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessRefinery.Barcode;
using System.Drawing.Imaging;
using System.IO;
using EncryptXSKT.HandleFile;
using CrystalDecisions.CrystalReports.Engine;


namespace EncryptXSKT
{
    public partial class frmQRCodeViewer : Form
    {
        public frmQRCodeViewer()
        {
            InitializeComponent();
            rwcs = new ReadAndWriteCSV();
        }
        ReadAndWriteCSV rwcs;
        private void frmQRCodeViewer_Load(object sender, EventArgs e)
        {

           
        }

        void LoadQrCodeFileImage()
        { 
        
        }


        void loadReportQrCode()
        {
            DataSet ds = new DataSet();
            ds.Tables.Add();
            DataTable td = ds.Tables[0];
            ds.Tables.Clear();
            ds.Tables.Add();

            ds.Tables[0].Columns.Add("SoThuTu");
            ds.Tables[0].Columns.Add("NgayXo");
            ds.Tables[0].Columns.Add("So");
            ds.Tables[0].Columns.Add("MaHoa");
            Object[] pr = new Object[4];
            List<LotteryPattern> lst = rwcs.ReadCSV(txtDuongDan.Text, true);
            if (lst.Count > 0)
            {
                foreach (var obj in lst)
                {
                    pr[0] = obj.LoaiVe;
                    pr[1] = obj.NgaySo;
                    pr[2] = obj.So;
                    pr[3] = QrCodeByte(obj.SoMaHoa);
                    ds.Tables[0].Rows.Add(pr);
                }
            
            }

            ReportDocument rpt = new ReportDocument();

            rpt.Load(Application.StartupPath + @"\CrystalReport2.rpt");
            rpt.SetDataSource(ds.Tables[0]);
            crystalReportViewer1.ReportSource = rpt;
        }

        byte[] QrCodeByte(string mahoa)
        {

            try
            {
                QRCode barcode = new QRCode();
                barcode.Code = mahoa;
                barcode.Resolution = 1004;
                barcode.Rotate = Rotate.Rotate180;

                barcode.Format = ImageFormat.Jpeg;
                return barcode.drawBarcode2ByteArray();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadReportQrCode();
        }


       
    }
}
