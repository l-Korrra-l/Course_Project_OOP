using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photohosting.Models
{
    public class ErrorsRepository
    {
        static PhotohostingEntities db;
        static ErrorsRepository()
        {
            db = new PhotohostingEntities();
        }

        public static void AddError(Error err)
        {
                db.Errors.Add(err);
                db.SaveChanges();
        }
        public static void Update(Error err)
        {
            db.Entry(err).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public static void Delete(int id)
        {
            db.Errors.Remove(GetError(id));
            db.SaveChanges();
        }

        public static Error GetError(int id)
        {
            if (db.Errors.Where(p => (p.Id == id)).Count() != 0)
                return db.Errors.Where(p => (p.Id == id)).Single();
            else
                return null;
        }

        public static ObservableCollection<Error> GetErrors()
        {
            ObservableCollection<Error> errors = new ObservableCollection<Error>();
            if (db.Errors.Count() != 0)
            {
                foreach (Error err in db.Errors.ToList())
                    errors.Add(err);
            }
            return errors;
        }

    }

   
}
