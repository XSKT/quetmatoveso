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
using System.Data.OleDb;
using System.Globalization;


namespace EncryptXSKT
{
    public partial class frmQRCodeViewer : Form
    {
        public frmQRCodeViewer()
        {
            InitializeComponent();
            rwcs = new ReadAndWriteCSV();
            LoadData();
        }
        void LoadData()
        {
            
            //crystalReportViewer.SetDataSource();
            //crystalReportViewer.ReportSource = tab;
        }
        ReadAndWriteCSV rwcs;
        private void frmQRCodeViewer_Load(object sender, EventArgs e)
        {

           
        }

        void LoadQrCodeFileImage()
        { 
        
        }
        DataSet TableVeSo()
        {
            DataSet ds = new DataSet();
            ds.Tables.Add();
            ds.Tables.Clear();
            ds.Tables.Add();
            ds.Tables[0].Columns.Add("No");
            ds.Tables[0].Columns.Add("NgayXo",typeof(DateTime));
            ds.Tables[0].Columns.Add("So");
            ds.Tables[0].Columns.Add("MaHoa");
            ds.Tables[0].Columns.Add("KyVe");
            ds.Tables[0].Columns.Add("RQCodeLeft", typeof(byte[]));
            ds.Tables[0].Columns.Add("RQCodebottom",typeof(byte[]));
            ds.Tables[0].Columns.Add("RQCodeBlock", typeof(byte[]));
            ds.Tables[0].Columns.Add("LoaiVe");
            return ds;
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
            List<LotteryPattern> lst = rwcs.ReadCSV(txtDuongDanFile.Text, true);
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
            crystalReportViewer.ReportSource = rpt;
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
            LoadRQCodeinReport(txtDuongDanFile.Text);
        }

        private void btOpenFile_Click(object sender, EventArgs e)
        {
            DialogResult dr = dlopenFile.ShowDialog();
            if (dr == DialogResult.OK)
            {
                if (dlopenFile.FileName.Contains(".csv"))
                {
                    txtDuongDanFile.Text = dlopenFile.FileName;
                    //lblduongdan.Text = Path.GetDirectoryName(txtDuongDan.Text);
                    LoadDatainReport(txtDuongDanFile.Text);
                }
                else
                {
                    // txtDuongDanFile.Text = "";
                    MessageBox.Show("File Không Đúng Định Dạng ! Bạn hãy chọn file Khác");
                }
            }
        }
        public void LoadRQCodeinReport(string namefile)
        {
            try
            {
                DataTable sheet = new DataTable();
                sheet = ReadFromExcels(namefile);
                ReportDocument rpt = new ReportDocument();
                rpt.Load(Application.StartupPath + @"\CrystalReport2.rpt");
                //rpt.SetDataSource(ds.Tables[0]);
                rpt.Database.Tables["DataTable1"].SetDataSource(sheet);
                crystalReportViewer.ReportSource = rpt;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void LoadDatainReport(string namefile)
        {
            try
            {
                DataTable sheet = new DataTable();
                sheet = ReadFromExcels(namefile);
                ReportDocument rpt = new ReportDocument();
                rpt.Load(Application.StartupPath + @"\CrystalReport3.rpt");
                //rpt.SetDataSource(ds.Tables[0]);
                rpt.Database.Tables["DataTableBlockVeSo"].SetDataSource(sheet);
                crystalReportViewer.ReportSource = rpt;
                GeQRCode.Enabled = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public DataTable ReadFromExcels(string namefile)
        {
            try
            {
                QRcode qrcode = new QRcode();
                string fileLocation = txtDuongDanFile.Text;
                string name = Path.GetFileName(txtDuongDanFile.Text);
                DataTable sheet = new DataTable();
                OleDbConnectionStringBuilder csbuilder = new OleDbConnectionStringBuilder();
                csbuilder.Provider = "Microsoft.ACE.OLEDB.12.0";
                csbuilder.DataSource = fileLocation.Substring(0, fileLocation.LastIndexOf('\\'));
                csbuilder.Add("Extended Properties", "Text;Excel 12.0;HDR=No;IMEX=1;FMT=Delimited");
                string selectSql = @"SELECT * FROM [" + name + "]";
                using (OleDbConnection connection = new OleDbConnection(csbuilder.ConnectionString))
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(selectSql, connection))
                {
                    connection.Open();
                    adapter.Fill(sheet);
                    connection.Close();
                }
                DataSet ds = TableVeSo();
                Decimal No = 1;
                foreach (DataRow row in sheet.Rows)
                {
                    LotteryPattern lotteryPattern = new LotteryPattern();
                    lotteryPattern.NO = No.ToString();
                    if (row[0] != null)
                    {
                        lotteryPattern.LoaiVe = row[0].ToString();
                    }
                    if (row[1] != null)
                    {
                        lotteryPattern.KyVe = row[1].ToString();
                    }
                    if (row[2] != null)
                    {
                       lotteryPattern.NgaySo =Convert.ToDateTime(row[2].ToString());
                    }
                    if (row[3] != null)
                    {
                        lotteryPattern.So = row[3].ToString();
                    }
                    if (row[4] != null)
                    {
                        lotteryPattern.SoMaHoa = row[4].ToString();
                    }
                    byte[] qrcodebyte = qrcode.ConertArrayByte(qrcode.GenerateQRCode(lotteryPattern.SoMaHoa, 70, 70));
                    byte[] qrcodebytebottom = qrcode.ConertArrayByte(qrcode.GenerateQRCode(lotteryPattern.SoMaHoa, 40, 40));
                    ds.Tables[0].Rows.Add(lotteryPattern.NO, lotteryPattern.NgaySo, lotteryPattern.So, lotteryPattern.SoMaHoa, lotteryPattern.KyVe, qrcodebyte, qrcodebytebottom, qrcodebyte, lotteryPattern.LoaiVe);
                    No++;
                }
                return ds.Tables[0];
            }
            catch (Exception e)
            { 
                Console.WriteLine(e.Message);
                return null;
            }
        
        }
       
    }
}
