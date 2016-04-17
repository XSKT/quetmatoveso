using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ZXing;
using System.IO;

namespace EncryptXSKT.HandleFile
{
   public  class QRcode
    {
       public Bitmap GenerateQRCode(string stringencode, int height, int with)
       {
           IBarcodeWriter writer = new BarcodeWriter
           {
               Format = BarcodeFormat.QR_CODE,
               Options = new ZXing.Common.EncodingOptions
               {
                   Height = height,
                   Width = with,
                   Margin=0
               }
           };
           return writer.Write(stringencode);
       
       }
       public byte[] ConertArrayByte(Bitmap bitmap) {

           MemoryStream ms = new MemoryStream();
           bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
           return ms.ToArray();
       }
    }
}
