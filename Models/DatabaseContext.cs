using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleLoginForm.Models
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
        {
        }

        public DbSet<AccountModel> accountsTable { get; set; }


        public void addEntry(object obj)
        {
            Add(obj);
            SaveChanges();
        }

        public void removeEntry(object obj)
        {
            Remove(obj);
            SaveChanges();
        }

        public void updateEntry(object obj)
        {
            Update(obj);
            SaveChanges();
        }

        public bool UserExist(string email)
        {

            bool retval = false;

            if ((from AccountModel in accountsTable where AccountModel.email == email select AccountModel) != null)
            {
                retval = true;
            }

            return retval;
        }

        public AccountModel GetAccount(string email)
        {

            AccountModel retval = null;

            if (UserExist(email))
            {
                retval = (from AccountModel in accountsTable where AccountModel.email == email select AccountModel).ToArray()[0];
            }

            return retval;
        }
    }
}
