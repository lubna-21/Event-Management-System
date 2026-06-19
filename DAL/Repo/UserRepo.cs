using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repo
{
        public class UserRepo
        {
            EventDBContext db;
            public UserRepo(EventDBContext db)
            {
                this.db = db;
            }
        public User? Login(string email, string password)
        {
            return (from u in db.Users
                    where u.Email == email && u.Password == password
                    select u).FirstOrDefault();
        }

        public bool EmailExists(string email)
        {
            return (from u in db.Users
                    where u.Email == email
                    select u).Any();
        }
        public List<User> Get()
        {
            return (from u in db.Users
                    select u).ToList();
        }

        public User Get(int id)
        {
            return (from u in db.Users
                    where u.Id == id
                    select u).FirstOrDefault()!;
        }
        public bool Create(User u)
            {
                db.Users.Add(u);
                return db.SaveChanges() > 0;
            }
            public bool Update(User u)
            {
                var exobj = Get(u.Id);
                db.Entry(exobj).CurrentValues.SetValues(u);
                return db.SaveChanges() > 0;
            }
            public bool Delete(int id)
            {
                var exobj = Get(id);
                db.Users.Remove(exobj);
                return db.SaveChanges() > 0;
            }
        }
    }
   