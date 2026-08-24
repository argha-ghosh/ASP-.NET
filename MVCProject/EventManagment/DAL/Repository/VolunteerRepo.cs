using DAL.EF;
using DAL.EF.Tables;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class VolunteerRepo
    {
        EventManagmentContext db;
        public VolunteerRepo(EventManagmentContext db)
        {
            this.db = db;
        }

        // Post Volunteer
        public bool CreateVolunteer(Volunteer ev)
        {
            db.Volunteers.Add(ev);
            return db.SaveChanges() > 0;
        }

        // Get All Volunteers
        public List<Volunteer> GetAllVolunteers()
        {
            return db.Volunteers.ToList();
        }

        // Get Volunteer by ID
        public Volunteer? GetVolunteerById(int id)
        {
            return db.Volunteers.Find(id);
        }

        //Update Volunteer
        public bool UpdateVolunteer(Volunteer ev)
        {
            var ex = db.Volunteers.Find(ev.VolunteerId);
            if (ex != null)
            {
                ex.FullName = ev.FullName;
                ex.Phone = ev.Phone;
                ex.JoinDate = ev.JoinDate;
                return db.SaveChanges() > 0;
            }
            return false;
        }

        // Delete Volunteer
        public bool DeleteVolunteer(int id)
        {
            var employee = db.Volunteers.Find(id);
            if (employee != null)
            {
                db.Volunteers.Remove(employee);
                return db.SaveChanges() > 0;
            }
            return false;
        }
    }
}
