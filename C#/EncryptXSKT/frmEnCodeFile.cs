using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EncryptXSKT.HandleFile;
using System.IO;
using BusinessRefinery.Barcode;
using System.Drawing.Imaging;
using System.Data.OleDb;
using System.Threading;

namespace EncryptXSKT
{
    public partial class frmEnCodeFile : Form
    {
        public frmEnCodeFile()
        {
            InitializeComponent();
            
            dlgFile.Multiselect = false;
            rwobj = new ReadAndWriteCSV();
        }
        ReadAndWriteCSV rwobj;

        private void btnMoFile_Click(object sender, EventArgs e)
        {
            DialogResult dr = dlgFile.ShowDialog();
            if (dr == DialogResult.OK)
            {
                if (dlgFile.FileName.Contains(".csv"))
                {
                    txtDuongDanFile.Text = dlgFile.FileName;
                    lblduongdan.Text = Path.GetDirectoryName(txtDuongDanFile.Text);
                }
                else
                {
                    txtDuongDanFile.Text = "";
                    MessageBox.Show("File Không Đúng Định Dạng ! Bạn hãy chọn file Khác");
                }
            }

        }
        void LuuFile()
        {
            try
            {
                this.Enabled = true;
                rwobj.ReadAndWriteMaHoa(pbCreateFile, txtDuongDanFile.Text.ToString(), lblduongdan.Text + "/" + txtFileMaHoa.Text);
                this.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }



        private void btnFile_Click(object sender, EventArgs e)
        {
            try
            {

                LuuFile();
                MessageBox.Show("File Mã Hóa lưu thành công !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("File Mã Hóa lưu không thành công !");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
        }

        private void label4_Click(object sender, EventArgs e)
        {
            frmQRCodeViewer frm = new frmQRCodeViewer();
            frm.Show();
            this.Close();
        }
        private void UpdateProgress()
        {

            pbCreateFile.Value += 1;

        }
        public delegate void updatebar();

        public void ReadFromExcel()
        {
            try
            {
                string fileLocation = txtDuongDanFile.Text;
                string name = Path.GetFileName(txtDuongDanFile.Text);
                DataTable sheet = new DataTable();
                OleDbConnectionStringBuilder csbuilder = new OleDbConnectionStringBuilder();
                csbuilder.Provider = "Microsoft.ACE.OLEDB.12.0";
                csbuilder.DataSource= fileLocation.Substring(0, fileLocation.LastIndexOf('\\'));
                csbuilder.Add("Extended Properties", "Text;Excel 12.0;HDR=No;IMEX=1;FMT=Delimited");
                string selectSql = @"SELECT * FROM [" + name + "]";
                using (OleDbConnection connection = new OleDbConnection(csbuilder.ConnectionString))
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(selectSql, connection))
                {
                    connection.Open();
                    adapter.Fill(sheet);
                    connection.Close();
                }
                foreach (DataRow row in sheet.Rows)
                {

                } 

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
