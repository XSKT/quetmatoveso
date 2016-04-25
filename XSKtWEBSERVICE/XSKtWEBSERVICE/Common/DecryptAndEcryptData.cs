using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;

namespace XSKtWEBSERVICE.Common
{
    public class DecryptAndEcryptData
    {
        public static string Decrypt(string target, string key, bool useHashing)
        {
            try
            {
                if (string.IsNullOrEmpty(key))
                    throw new ArgumentNullException("The key must not be null or empty.");

                if (string.IsNullOrEmpty(target))
                    return target;

                byte[] keyArray;
                byte[] resultArray;
                byte[] targetArray = Convert.FromBase64String(target);
                if (useHashing)
                {
                    using (MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider())
                    {
                        keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(key));
                        goto Label_003E;
                    }
                }
                keyArray = Encoding.UTF8.GetBytes(key);
            Label_003E:
                using (TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = keyArray;
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;
                    resultArray = tdes.CreateDecryptor().TransformFinalBlock(targetArray, 0, targetArray.Length);
                }
                return Encoding.UTF8.GetString(resultArray);
            }
            catch (Exception ex)
            {
                throw new Exception("Loi Decrypt" + ex.Message);

            }
        }

        public static string Encrypt(string target, string key, bool useHashing)
        {
            try
            {
                if (string.IsNullOrEmpty(key))
                    throw new ArgumentNullException("The key must not be null or empty.");

                if (string.IsNullOrEmpty(target))
                    return target;

                byte[] keyArray;
                byte[] resultArray;
                byte[] targetArray = Encoding.UTF8.GetBytes(target);
                if (useHashing)
                {
                    using (MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider())
                    {
                        keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(key));
                        goto Label_0043;
                    }
                }
                keyArray = Encoding.UTF8.GetBytes(key);
            Label_0043:
                using (TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = keyArray;
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;
                    resultArray = tdes.CreateEncryptor().TransformFinalBlock(targetArray, 0, targetArray.Length);
                }
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
            catch (Exception ex)
            {
                throw new Exception("Loi Encrypt" + ex.Message);

            }
        }

        public static string GetConfigEncrytKey()
        {
            return ConfigurationSettings.AppSettings["KeyEncode"];
        }
        public static bool IsHashEncryptDecryptEnable()
        {
            return true;
        }

    }
}