using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repo
{
    public class EventCategoryRepo
    {
        EventDBContext db;
        public EventCategoryRepo(EventDBContext db)
        {
            this.db = db;
        }
        public List<EventCategory> Get()
        {
            return (from e in db.EventCategories
                    select e).ToList();
        }

        public List<EventCategory> Search(string? name, double? minPrice, double? maxPrice)
        {
            var query = from e in db.EventCategories
                        select e;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.Name.Contains(name));
            }
            if (minPrice.HasValue)
            {
                query = query.Where(e => e.Price >= minPrice.Value);
            }
            if (maxPrice.HasValue)
            {
                query = query.Where(e => e.Price <= maxPrice.Value);
            }

            return query.ToList();
        }

        public EventCategory Get(int id)
        {
            return (from e in db.EventCategories
                    where e.Id == id
                    select e).FirstOrDefault()!;
        }
        public bool Create(EventCategory ec)
        {
            db.EventCategories.Add(ec);
            return db.SaveChanges() > 0;
        }
        public bool Update(EventCategory ec)
        {
            var exobj = Get(ec.Id);
            db.Entry(exobj).CurrentValues.SetValues(ec);
            return db.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var bookings = (from b in db.Bookings
                            where b.EventCategoryId == id
                            select b).ToList();
            db.Bookings.RemoveRange(bookings);
            var exobj = Get(id);
            db.EventCategories.Remove(exobj);
            return db.SaveChanges() > 0;
        }
    }
}