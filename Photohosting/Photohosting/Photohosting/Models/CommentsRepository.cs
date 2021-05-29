using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photohosting.Models
{
    class CommentsRepository :IRepository<CommentsRepository>
    {
        static PhotohostingEntities db;
        static CommentsRepository()
        {
            db = new PhotohostingEntities();
        }


        public static void AddComment(Comment com)
        {
            db.Comments.Add(com);
            db.SaveChanges();
        }
        public static void Update(Comment com)
        {
            db.Entry(com).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Comments.Remove(GetComment(id));
            db.SaveChanges();
        }

        public static Comment GetComment(int id)
        {
            if (db.Comments.Where(p => (p.Id == id)).Count() != 0)
                return db.Comments.Where(p => (p.Id == id)).Single();
            else
                return null;
        }

        public static ObservableCollection<Comment> GetComments(int id)
        {
            ObservableCollection<Comment> comments = new ObservableCollection<Comment>();
            if (db.Comments.Count() != 0)
            {
                foreach (Comment com in db.Comments.Where(p=>p.PId==id).OrderBy(p=>p.Date).ToList())
                    comments.Add(com);
            }
            return comments;
        }

        public IEnumerable<CommentsRepository> GetItemList()
        {
            throw new NotImplementedException();
        }

        public CommentsRepository GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(CommentsRepository item)
        {
            throw new NotImplementedException();
        }

        public void Update(CommentsRepository item)
        {
            throw new NotImplementedException();
        }


        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
