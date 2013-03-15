using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ExperimentalCMS.Domain.Utility
{
     public static class Crypto
    {
        public static string Hash(string word, string salt)
        {
            SHA256 sha256 = System.Security.Cryptography.SHA256.Create();

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(String.Concat(word, salt));
            byte[] hash = sha256.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public static bool DecryptSecurityToken(string securityToken, out int delimiter0, out string delimiter1)
        {
            string[] decrpytedStrings = Decrypt(securityToken, true).Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            delimiter0 = -1;
            delimiter1 = String.Empty;
            if (decrpytedStrings.Count() == 2)
            {
                delimiter0 = int.Parse(decrpytedStrings[0]);
                delimiter1 = decrpytedStrings[1];
                return true;
            }
            return false;
        }

        public static string HashPassword(string password, string salt)
        {
            return Hash(password, salt + password);
        }

        public static string CreateRandomPassword(int passwordLength)
        {
            const string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            var randNum = new Random();
            var chars = new char[passwordLength];

            for (int i = 0; i < passwordLength; i++)
            {
                chars[i] = allowedChars[randNum.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }
        public static string Encrypt(string ToEncrypt, bool useHasing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(ToEncrypt);
            
            string Key = "TruPhone";
            if (useHasing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Key));
                hashmd5.Clear();
            }
            else
            {
                keyArray = UTF8Encoding.UTF8.GetBytes(Key);
            }
            TripleDESCryptoServiceProvider tDes = new TripleDESCryptoServiceProvider();
            tDes.Key = keyArray;
            tDes.Mode = CipherMode.ECB;
            tDes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tDes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tDes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string Decrypt(string cypherString, bool useHasing)
        {
            byte[] keyArray;
            cypherString = cypherString.Replace(" ", "+");
            byte[] toDecryptArray = Convert.FromBase64String(cypherString);

            string key = "TruPhone";
            if (useHasing)
            {
                MD5CryptoServiceProvider hashmd = new MD5CryptoServiceProvider();
                keyArray = hashmd.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd.Clear();
            }
            else
            {
                keyArray = UTF8Encoding.UTF8.GetBytes(key);
            }
            TripleDESCryptoServiceProvider tDes = new TripleDESCryptoServiceProvider();
            tDes.Key = keyArray;
            tDes.Mode = CipherMode.ECB;
            tDes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tDes.CreateDecryptor();
            try
            {
                byte[] resultArray = cTransform.TransformFinalBlock(toDecryptArray, 0, toDecryptArray.Length);

                tDes.Clear();
                return UTF8Encoding.UTF8.GetString(resultArray, 0, resultArray.Length);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

