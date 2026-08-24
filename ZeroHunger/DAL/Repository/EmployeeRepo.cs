using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class EmployeeRepo
    {
        ZeroHungerDbContext db;

        public EmployeeRepo(ZeroHungerDbContext db)
        {
            this.db = db;
        }

        public List<Employee> Get()
        {
            return db.Employees.ToList();
        }

        public Employee Get(int id)
        {
            return db.Employees.Find(id);
        }

        public bool Create(Employee e)
        {
            db.Employees.Add(e);
            return db.SaveChanges() > 0;
        }

        public bool Update(Employee e)
        {
            var ex = Get(e.EmployeeId);

            ex.Name = e.Name;
            ex.Phone = e.Phone;
            ex.Email = e.Email;

            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var data = Get(id);

            db.Employees.Remove(data);
            return db.SaveChanges() > 0;
        }
    }
}
