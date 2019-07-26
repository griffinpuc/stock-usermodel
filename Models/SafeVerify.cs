using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLoginForm.Models
{
    public class SafeVerify
    {

        private DatabaseContext _context;

        public SafeVerify(DatabaseContext context)
        {
            _context = context;
        }

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

        public bool secureLogin(string email, string password)
        {
            bool retval = false;

            if (_context.GetAccount(email).password.Equals(password))
            {
                retval = true;
            }

            return retval;
        }

        public bool secureCreation(string email, string password, string uname)
        {
            bool ret = false;

            AccountModel newAccount = new AccountModel() {username = uname, email = email, password = computeHash(password) };

            try
            {
                _context.addEntry(newAccount);
                ret = true;
            }
            catch
            {
                //???
            }

            return ret;
        }

    }
}
