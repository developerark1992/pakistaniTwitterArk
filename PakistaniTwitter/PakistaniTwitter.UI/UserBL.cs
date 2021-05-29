using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PakistaniTwitter;
using PakistaniTwitter.Models;


namespace PakistaniTwitter
{
    public class UserBL
    {
        public void AddUser(Users_PakistaniTwitter item)
        {
            using (PakistaniTwitterDBEntities db = new PakistaniTwitterDBEntities())
            {
                db.Users_PakistaniTwitter.Add(item);
                db.SaveChanges();
            }
        }

        public void UpdateUser(Users_PakistaniTwitter person)
        {
            using (PakistaniTwitterDBEntities db = new PakistaniTwitterDBEntities())
            {
                if (!string.IsNullOrWhiteSpace(person.UserId))                
                {
                    Users_PakistaniTwitter p;
                    p = SearchUser(person.UserId);
                    p.Active = person.Active;
                    p.Email = person.Email;
                    p.FullName = person.FullName;
                    p.Password = person.Password;
                    db.Users_PakistaniTwitter.Attach(p);
                    db.Entry(p).State = (System.Data.Entity.EntityState)EntityState.Modified;
                }
                db.SaveChanges();
            }
        }
        public Users_PakistaniTwitter Validate(string uname,string pwd)
        {
            using (PakistaniTwitterDBEntities db = new PakistaniTwitterDBEntities())
            {
                Users_PakistaniTwitter obj = db.Users_PakistaniTwitter.FirstOrDefault(i => i.UserId == uname && i.Password == pwd && i.Active == true);
                return obj;
            }
        }
        public Users_PakistaniTwitter SearchUser(string uname)
        {
            using (PakistaniTwitterDBEntities db = new PakistaniTwitterDBEntities())
            {
                Users_PakistaniTwitter obj = db.Users_PakistaniTwitter.FirstOrDefault(i => i.UserId.Contains(uname));
                return obj;
            }
        }


    }
}
