using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLoginForm.Models
{
    public class Encrypt
    {

        /* Compute hash from string */
        public string computeHash(string value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }

        public bool secureLogin(string email, string password, string address)
        {
            bool ret = false;
            return ret;
        }

        public bool secureCreation(string email, string password, string address)
        {
            bool ret = false;



            return ret;
        }

    }
}
