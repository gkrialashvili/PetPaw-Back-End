using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetPaw.Helper
{
    public static class GetHashAndRandom32
    {
        public static string MD5Hash(string input)
        {
            byte[] data = System.Security.Cryptography.MD5.Create().ComputeHash
                (System.Text.Encoding.UTF8.GetBytes(input));
            string md5 = "";
            for (int i = 0; i < data.Length; i++)
            {
                md5 += data[i].ToString("x2");
            }
            return md5;
        }

        public static string Random32()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}