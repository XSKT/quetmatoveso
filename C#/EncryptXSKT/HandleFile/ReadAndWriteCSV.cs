using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;

namespace EncryptXSKT.HandleFile
{
    class ReadAndWriteCSV
    {

        private System.Windows.Forms.ProgressBar progressBar;

     
        public List<LotteryPattern> ReadCSV(string urlFile, Boolean FileMaHoa)
        {
            var reader = new StreamReader(File.OpenRead(urlFile));
            List<LotteryPattern> listA = new List<LotteryPattern>();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                string[] values = line.Split(',');
                LotteryPattern obj = new LotteryPattern();
                if (!FileMaHoa)
                {
                    if (values.Count() > 0)
                    {
                        obj.LoaiVe = values[0].ToString();
                       // obj.NgaySo = values[1].ToString();
                        obj.So = values[2].ToString();
                    }
                }
                else
                {
                    if (values.Count() > 0)
                    {
                        obj.LoaiVe = values[0].ToString();
                       // obj.NgaySo = values[1].ToString();
                        obj.So = values[2].ToString();
                        obj.SoMaHoa = values[3].ToString();
                    }

                }
                listA.Add(obj);


            }
            return listA;
        }
        private void UpdateProgress()
        {

            progressBar.Value += 1;

        }
        public delegate void updatebar();
        public void ReadAndWriteMaHoa(System.Windows.Forms.ProgressBar progressBar,string urlFile, string urlFileMaHoa)
        {
            this.progressBar = progressBar;
            var reader = new StreamReader(File.OpenRead(urlFile));
            StreamWriter sw = new StreamWriter(urlFileMaHoa, true);
            
            List<LotteryPattern> listA = new List<LotteryPattern>();
            StringBuilder str = new StringBuilder();
            string encodeString;
            string notesString = ";";
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                string[] values = line.Split(',');
                LotteryPattern obj = new LotteryPattern();

                if (values.Count() > 0)
                {
                    obj.LoaiVe = values[0].ToString();
                    obj.KyVe = values[1].ToString();
                    string ngayso = values[2].ToString();
                    obj.So = values[3].ToString();
                    encodeString = obj.LoaiVe + notesString + obj.KyVe + notesString + ngayso + notesString + obj.So;
                    obj.SoMaHoa = DecryptAndEcryptClass.Encrypt(encodeString, DecryptAndEcryptClass.GetConfigEncrytKey(), DecryptAndEcryptClass.IsHashEncryptDecryptEnable());
                    str.AppendFormat("{0} , {1} , {2} , {3}, {4}", obj.LoaiVe, obj.KyVe, obj.NgaySo, obj.So, obj.SoMaHoa);
                    str.AppendLine();
                    this.progressBar.Invoke(new updatebar(this.UpdateProgress));
                }

            }
            sw.Write(str.ToString());
            sw.Flush();
            sw.Close();

        }

        public void WriteCSV(List<LotteryPattern> lst, string URLFileLuu)
        {
            if (lst.Count == 0 || lst == null)
                return;

            StringBuilder str = new StringBuilder();
            foreach (var obj in lst)
            {
                obj.SoMaHoa = DecryptAndEcryptClass.Encrypt(obj.So, DecryptAndEcryptClass.GetConfigEncrytKey(), DecryptAndEcryptClass.IsHashEncryptDecryptEnable());
                str.AppendFormat("{0} , {1} , {2} , {3}", obj.LoaiVe, obj.NgaySo, obj.So, obj.SoMaHoa);
                str.AppendLine();
            }
            StreamWriter sw = new StreamWriter(URLFileLuu, true);
            sw.Write(str.ToString());
            sw.Flush();
            sw.Close();
        }

    }
}
