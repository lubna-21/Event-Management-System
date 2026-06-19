using DAL.EF;
using DAL.EF.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repo
{
        public class BookingRepo
        {
            EventDBContext db;
            public BookingRepo(EventDBContext db)
            {
                this.db = db;
            }
            public List<Booking> Get()
            {
                return (from b in db.Bookings
                         select b).Include(b => b.User).Include(b => b.EventCategory).ToList();
            }
        public List<Booking> GetByUser(int userId)
        {
            return (from b in db.Bookings
                    where b.UserId == userId
                    select b).Include(b => b.EventCategory).ToList();
        }

        public Booking Get(int id)
        {
            return (from b in db.Bookings
                    where b.Id == id
                    select b).Include(b => b.User).Include(b => b.EventCategory).FirstOrDefault()!;
        }
        public bool Create(Booking b)
            {
                db.Bookings.Add(b);
                return db.SaveChanges() > 0;
            }

        public bool UpdateStatus(int id , string status)
        {
            var up = db.Bookings.Find(id)!;
            up.Status = status;
            return db.SaveChanges() > 0;
        }
            public bool Delete(int id)
            {
                var exobj = db.Bookings.Find(id)!;
                db.Bookings.Remove(exobj);
                return db.SaveChanges() > 0;
            }
        }
    }
    