using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class DepartmentRepo
    {
        SchoolManagmentContext db;
        public DepartmentRepo(SchoolManagmentContext db)
        {
            this.db = db;
        }

        //Get all departments
        public List<Department> GetAll()
        {
            return db.Departments.ToList();
        }

        //Create New Department
        public bool create(Department d)
        {
            db.Departments.Add(d);
             return db.SaveChanges() > 0;
        }

        //Get Department By Id
        //public Department GetById(int id)
        //{
        //    return db.Departments.Find(id);
        //}
    }
}
