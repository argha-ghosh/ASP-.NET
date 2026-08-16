using AutoMapper;
using BLL.Models;
using DAL.EF.Tables;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class DepartmentServices
    {
        DepartmentRepo repo;
        IMapper mapper;
        public DepartmentServices(DepartmentRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public List<DepartmentModel> All() {
            var data = repo.GetAll();
            var mappedData = mapper.Map<List<DepartmentModel>>(data);
            return mappedData;
        }

    }
}
