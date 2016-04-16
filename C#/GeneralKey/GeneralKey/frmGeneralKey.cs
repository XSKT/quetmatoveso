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
            label4.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        HandelXml obj = new HandelXml();
        private void button1_Click(object sender, EventArgs e)
        {
            pbCreateFile.Value = 0;
            if (textBox2.Text.Trim().Equals(""))
            {
                MessageBox.Show("Độ dài key không được rỗng !");
                return;
            }

            if (Convert.ToDouble(textBox2.Text.Trim()) <12 )
            {
                MessageBox.Show("Độ dài key không được nhỏ hơn 12 !");
                return;
            }

            richTextBox1.Text = obj.RandomString(pbCreateFile, Convert.ToDouble(textBox2.Text), false);
        }


        private void Data_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        public delegate void updatebar();
        private void UpdateProgress()
        {
            pbCreateFile.Value += 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            DialogResult dlr = MessageBox.Show(this,"Bạn có muốn lưu key này không?", "IceTea Việt", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                try
                {
                    obj.writeXML(richTextBox1.Text,label4.Text, Application.StartupPath + "/test.xml");
                    MessageBox.Show("Lưu key thành công !");
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Lưu key không thành công !");
                }
            }
            
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            pbCreateFile.Maximum = Convert.ToInt16(textBox2.Text.ToString());
        }


    }
}
