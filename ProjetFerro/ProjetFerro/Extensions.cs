using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ProjetFerro
{
    static class Extensions
    {
        public static string Crypter(this string chaineACrypter, string cleDeCryptage)
        {
            var des = new TripleDESCryptoServiceProvider();

            var hashMD5 = new MD5CryptoServiceProvider();
            var pwdHash = hashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cleDeCryptage));
            hashMD5 = null;

            des.Key = pwdHash;

            des.Mode = CipherMode.ECB;

            var buff = ASCIIEncoding.ASCII.GetBytes(chaineACrypter);

            var chaineCryptee = Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buff, 0, buff.Length));

            return chaineCryptee;
        }

        public static string Decrypter(this string chaineADecrypter, string cleDeCryptage)
        {
            var des = new TripleDESCryptoServiceProvider();

            var hashMD5 = new MD5CryptoServiceProvider();
            var pwdHash = hashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cleDeCryptage));
            hashMD5 = null;

            des.Key = pwdHash;

            des.Mode = CipherMode.ECB;

            var buff = Convert.FromBase64String(chaineADecrypter);

            var chaineDecryptee = ASCIIEncoding.ASCII.GetString(des.CreateDecryptor().TransformFinalBlock(buff, 0, buff.Length));

            return chaineDecryptee;
        }
    }
}
