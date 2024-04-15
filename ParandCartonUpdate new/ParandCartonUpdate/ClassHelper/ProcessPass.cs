using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParandCartonUpdate.ClassHelper
{
    public class ProcessPass
    {
        public string MD5(string val)
        {
            System.Security.Cryptography.MD5 md5serv = System.Security.Cryptography.MD5CryptoServiceProvider.Create();
            byte[] hash;
            System.Text.StringBuilder stringbuff = new System.Text.StringBuilder();
            System.Text.ASCIIEncoding asciiDEV = new System.Text.ASCIIEncoding();
            byte[] buffer = asciiDEV.GetBytes(val);
            hash = md5serv.ComputeHash(buffer);
            foreach (byte b in hash)
                stringbuff.Append(b.ToString("x2"));
            return (stringbuff.ToString());
        }
        public string SHA1(string val)
        {
            System.Security.Cryptography.SHA1 sha1serv = System.Security.Cryptography.SHA1CryptoServiceProvider.Create();
            byte[] hash;
            System.Text.StringBuilder stringbuff = new System.Text.StringBuilder();
            System.Text.ASCIIEncoding asciiDEV = new System.Text.ASCIIEncoding();
            byte[] buffer = asciiDEV.GetBytes(val);
            hash = sha1serv.ComputeHash(buffer);
            foreach (byte b in hash)
                stringbuff.Append(b.ToString("x2"));
            return (stringbuff.ToString());
        }
    }
}