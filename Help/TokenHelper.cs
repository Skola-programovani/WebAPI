using System;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Text;  
using System.Security.Cryptography;
using TodoApi.Models;

namespace TodoApi.Help{
    public static class TokenHelper{
        public static string getPasswordHash(string psswd){

            StringBuilder passwordHash = new StringBuilder(512);
            
            using (SHA256 sha = SHA256.Create())
                {  
                    byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(psswd));
                    foreach (byte b in bytes)
                        passwordHash.AppendFormat("{0:x2}", b);
                }
            return passwordHash.ToString();
        }
    }
}
