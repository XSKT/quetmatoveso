using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace EncryptXSKT
{
    class HandleFile
    {
        public List<LotteryPattern> ReadFile(string csv)
        {
            var reader = new StreamReader(File.OpenRead("@"+csv));
            List<LotteryPattern> listA = new List<LotteryPattern>();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                ////////Doc tung dong`////////////
                LotteryPattern obj = new LotteryPattern();
                if(values.Count() >0)
                {
                    obj.KyTu = values[0].ToString();
                    obj.NgayXo = Convert.ToDateTime(values[1].ToString());
                    obj.So = Convert.ToInt16(values[2].ToString());
                }
                listA.Add(obj);
            }
            return listA;
        }
    }
}
