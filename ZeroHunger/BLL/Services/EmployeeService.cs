using AutoMapper;
using BLL.Models;
using DAL.EF.Tables;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class EmployeeService
    {
        EmployeeRepo repo;
        IMapper mapper;

        public EmployeeService(EmployeeRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public List<EmployeeModel> Get()
        {
            var data = repo.Get();
            return mapper.Map<List<EmployeeModel>>(data);
        }

        public EmployeeModel Get(int id)
        {
            var data = repo.Get(id);
            return mapper.Map<EmployeeModel>(data);
        }

        public bool Create(EmployeeModel model)
        {
            var data = mapper.Map<Employee>(model);
            return repo.Create(data);
        }

        public bool Update(EmployeeModel model)
        {
            var data = mapper.Map<Employee>(model);
            return repo.Update(data);
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}
