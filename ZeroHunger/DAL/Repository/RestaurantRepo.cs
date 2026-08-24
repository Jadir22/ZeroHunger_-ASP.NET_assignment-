using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class RestaurantRepo
    {
        ZeroHungerDbContext db;

        public RestaurantRepo(ZeroHungerDbContext db)
        {
            this.db = db;
        }

        public List<Restaurant> Get()
        {
            return db.Restaurants.ToList();
        }

        public Restaurant Get(int id)
        {
            return db.Restaurants.Find(id);
        }

        public bool Create(Restaurant r)
        {
            db.Restaurants.Add(r);
            return db.SaveChanges() > 0;
        }

        public bool Update(Restaurant r)
        {
            var ex = Get(r.RestaurantId);

            ex.Name = r.Name;
            ex.Address = r.Address;
            ex.Phone = r.Phone;
            ex.Email = r.Email;

            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var data = Get(id);

            db.Restaurants.Remove(data);
            return db.SaveChanges() > 0;
        }
    }
}
