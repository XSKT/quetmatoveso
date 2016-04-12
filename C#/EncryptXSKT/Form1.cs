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

namespace EncryptXSKT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dlgFile.Multiselect = false;
            rwobj = new ReadAndWriteCSV();
            //  TestDecrypt();
        }
        ReadAndWriteCSV rwobj;
        //void TestDecrypt()
        //{
        //    string str = DecryptAndEcryptClass.Encrypt("811860", DecryptAndEcryptClass.GetConfigEncrytKey(), DecryptAndEcryptClass.IsHashEncryptDecryptEnable());
        //    //string str = DecryptAndEcryptClass.Encrypt("811860"+"A"+"/05/07/2017" + DecryptAndEcryptClass.GetConfigEncrytKey(), DecryptAndEcryptClass.GetConfigEncrytKey(), DecryptAndEcryptClass.IsHashEncryptDecryptEnable());
        //    MessageBox.Show(str);
        //    string str1= DecryptAndEcryptClass.Decrypt(str,DecryptAndEcryptClass.GetConfigEncrytKey(),DecryptAndEcryptClass.IsHashEncryptDecryptEnable());

        //    MessageBox.Show(str1);
        //    MessageBox.Show(str1.Substring(0,6));

        //}

        //void ReadFile()
        //{ 
        //    if(dlgFile.

        //}

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
            //List<LotteryPattern> lst = rwobj.ReadCSV(txtDuongDanFile.Text.ToString(),false);
            //rwobj.WriteCSV(lst, lblduongdan.Text + "/" + txtFileMaHoa.Text);
            try
            {
                rwobj.ReadAndWriteMaHoa(txtDuongDanFile.Text.ToString(), lblduongdan.Text + "/" + txtFileMaHoa.Text);

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
    }
}
