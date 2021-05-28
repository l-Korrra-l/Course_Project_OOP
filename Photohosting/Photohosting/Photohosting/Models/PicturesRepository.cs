using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photohosting.Models
{
    public static class PicturesRepository
    {
        static PhotohostingEntities db;
        static PicturesRepository()
        {
            db = new PhotohostingEntities();
        }

        public static int GetPicturesCount()
        {
            return db.Pictures.Count();
        }

        public static void AddPicture(Picture pic)
        {
            if (db.Pictures.Where(p => (pic.Pic == p.Pic)).Count() < 1)
            {
                db.Pictures.Add(pic);
                db.SaveChanges();
            }

        }

        public static List<Picture> GetPicturesTopic(string topic)
        {
            if (db.Pictures.Where(p => (p.MainTopic == topic)).Count() != 0)
                return (List<Picture>)db.Pictures.Where(p => (p.MainTopic == topic)).ToList();
            else
                return null;
        }
        public static List<Picture> GetPictures()
        {
            Random rnd = new Random();

            if (db.Pictures.Count() != 0)
                return (List<Picture>)db.Pictures.ToList();
            else
                return null;
        }
    }
}
