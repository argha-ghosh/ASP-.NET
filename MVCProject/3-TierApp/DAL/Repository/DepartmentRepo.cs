using DAL.EF;
using DAL.EF.Tables;
using Microsoft.EntityFrameworkCore;
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

        //Get all departments with students
        public List<Department> GetWithStudents() {
            var data = db.Departments.Include(d=>d.Students).ToList();
            return data;
        }




        //Create New Department
        //public bool create(Department d)
        //{
        //    db.Departments.Add(d);
        //     return db.SaveChanges() > 0;
        //}

        //Get Department By Id
        //public Department GetById(int id)
        //{
        //    return db.Departments.Find(id);
        //}
    }
}
