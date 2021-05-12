using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Photohosting.Models;

namespace Photohosting.Models
{
    public static class AccountsRepository
    {
        static PhotohostingEntities db;
        static AccountsRepository()
        {
            db = new PhotohostingEntities();
        }


        public static void AddAccount(Account acc)
        {
            if (db.Accounts.Where(p => (acc.Login == p.Login)).Count() < 1)
            {
                db.Accounts.Add(acc);
                db.SaveChanges();
            }

        }
        public static Account GetAccount(string login)
        {
            if (db.Accounts.Where(p => (p.Login == login)).Count() != 0)
                return db.Accounts.Where(p => (p.Login == login)).Single();
            else
                return null;
        }
        public static Account GetAccount(int id)
        {
            if (db.Accounts.Where(p => (p.UID == id)).Count() != 0)
                return db.Accounts.Where(p => (p.UID == id)).Single();
            else
                return null;
        }
        
        public static bool ContainsAccount(Account acc)
        {
            if (acc != null)
            {
                if (db.Accounts.Count() == 0)
                    return false;

                if (db.Accounts.Where(p => (p.Login == acc.Login)).Count() > 0)
                    return true;
            }
            return false;
        }
        public static bool ContainsAccount(string login, string password)
        {
            if (login != null && password != null)
            {
                if (db.Accounts.Count() == 0)
                    return false;
                if (db.Accounts.Where(p => (p.Login == login && p.Password == password)).Count() > 0)
                    return true;
            }
            return false;
        }

        public static int GetAccountsCount()
        {
            return db.Accounts.Count();
        }
        public static string HashPassword(string password)
        {
            var sha = new SHA512CryptoServiceProvider();
            Byte[] inputBytes = Encoding.UTF8.GetBytes(password);

            Byte[] hashedBytes = sha.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);
        }
    }
}
