using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class CollectRequestRepo
    {
        ZeroHungerDbContext db;

        public CollectRequestRepo(ZeroHungerDbContext db)
        {
            this.db = db;
        }

        public List<CollectRequest> Get()
        {
            return db.CollectRequests.ToList();
        }

        public CollectRequest Get(int id)
        {
            return db.CollectRequests.Find(id);
        }

        public bool Create(CollectRequest c)
        {
            db.CollectRequests.Add(c);
            return db.SaveChanges() > 0;
        }

        public bool Update(CollectRequest c)
        {
            var ex = Get(c.CollectRequestId);

            ex.RestaurantId = c.RestaurantId;
            ex.EmployeeId = c.EmployeeId;
            ex.FoodDescription = c.FoodDescription;
            ex.Quantity = c.Quantity;
            ex.RequestDate = c.RequestDate;
            ex.PreserveUntil = c.PreserveUntil;
            ex.Status = c.Status;

            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var data = Get(id);

            db.CollectRequests.Remove(data);
            return db.SaveChanges() > 0;
        }
    }
}
