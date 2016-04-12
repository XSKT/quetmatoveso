using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GeneralKey
{
    public partial class frmGeneralKey : Form
    {
        public frmGeneralKey()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        HandelXml obj = new HandelXml();
        private void button1_Click(object sender, EventArgs e)
        {


            textBox1.Text = obj.RandomString(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            DialogResult dlr = MessageBox.Show(this,"Bạn có muốn lưu key này không?", "IceTea Việt", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                try
                {
                    obj.writeXML(textBox1.Text, Application.StartupPath + "/test.xml");
                    MessageBox.Show("Lưu key thành công !");
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Lưu key không thành công !");
                }
            }
            
        }
    }
}
