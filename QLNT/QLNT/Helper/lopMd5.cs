using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace QLNT.Helper
{
    public class lopMd5
    {
        [DebuggerNonUserCode]
        public lopMd5()
        {
        }

        public string Decrypt(string cipherString, bool i_blUseHashing)
        {
            byte[] inputBuffer = new byte[checked(cipherString.Length - 1 + 1)];
            try
            {
                inputBuffer = Convert.FromBase64String(cipherString);
            }
            catch (Exception ex)
            {
               
            }
            string s = "fatherofbill";
            byte[] numArray;
            if (i_blUseHashing)
            {
                MD5CryptoServiceProvider cryptoServiceProvider = new MD5CryptoServiceProvider();
                numArray = cryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(s));
                cryptoServiceProvider.Clear();
            }
            else
                numArray = Encoding.UTF8.GetBytes(s);
            TripleDESCryptoServiceProvider cryptoServiceProvider1 = new TripleDESCryptoServiceProvider();
            cryptoServiceProvider1.Key = numArray;
            cryptoServiceProvider1.Mode = CipherMode.ECB;
            cryptoServiceProvider1.Padding = PaddingMode.PKCS7;
            byte[] bytes = cryptoServiceProvider1.CreateDecryptor().TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
            cryptoServiceProvider1.Clear();
            return Encoding.UTF8.GetString(bytes);
        }

        public string Encrypt(string i_strEncrypt, bool i_blUseHashing)
        {
            byte[] inputBuffer = new byte[checked(i_strEncrypt.Length - 1 + 1)];
            try
            {
                inputBuffer = Encoding.UTF8.GetBytes(i_strEncrypt);
            }
            catch (Exception ex)
            {
               
            }
            string s = "fatherofbill";
            byte[] numArray;
            if (i_blUseHashing)
            {
                MD5CryptoServiceProvider cryptoServiceProvider = new MD5CryptoServiceProvider();
                numArray = cryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(s));
                cryptoServiceProvider.Clear();
            }
            else
                numArray = Encoding.UTF8.GetBytes(s);
            TripleDESCryptoServiceProvider cryptoServiceProvider1 = new TripleDESCryptoServiceProvider();
            cryptoServiceProvider1.Key = numArray;
            cryptoServiceProvider1.Mode = CipherMode.ECB;
            cryptoServiceProvider1.Padding = PaddingMode.PKCS7;
            byte[] inArray = cryptoServiceProvider1.CreateEncryptor().TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
            cryptoServiceProvider1.Clear();
            return Convert.ToBase64String(inArray, 0, inArray.Length);
        }
    }

}
