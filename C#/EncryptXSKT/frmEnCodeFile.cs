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
using ZXing;

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
                string namefileoutput= lblduongdan.Text + "/" + txtFileMaHoa.Text+".csv";
                rwobj.ReadAndWriteMaHoa(pbCreateFile, txtDuongDanFile.Text.ToString(), namefileoutput);
              
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
             this.Hide();
             frm.Show();
        }
        private void UpdateProgress()
        {

            pbCreateFile.Value += 1;

        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
