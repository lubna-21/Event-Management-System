using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repo
{
        public class AdminRepo
        {
            EventDBContext db;
            public AdminRepo(EventDBContext db)
            {
                this.db = db;
            }
        public Admin? Login(string email, string password)
        {
            return (from a in db.Admins
                    where a.Email == email && a.Password == password
                    select a).FirstOrDefault();
        }
        public List<Admin> Get()
        {
            return (from a in db.Admins
                    select a).ToList();
        }

        public Admin Get(int id)
        {
            return (from a in db.Admins
                    where a.Id == id
                    select a).FirstOrDefault()!;
        }
        public bool Create(Admin a)
            {
                db.Admins.Add(a);
                return db.SaveChanges() > 0;
            }
            public bool Update(Admin a)
            {
                var exobj = Get(a.Id);
                db.Entry(exobj).CurrentValues.SetValues(a);
                return db.SaveChanges() > 0;
            }
            public bool Delete(int id)
            {
                var exobj = Get(id);
                db.Admins.Remove(exobj);
                return db.SaveChanges() > 0;
            }
        }
    }
    internal class AdminRepo
    {
    }

