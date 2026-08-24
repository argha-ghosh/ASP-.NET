using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class EventRepo
    {
        EventManagmentContext db;
        public EventRepo(EventManagmentContext db)
        {
            this.db = db;
        }

        // Post Event
        public bool CreateEvent(Event ev)
        {
            db.Events.Add(ev);
            return db.SaveChanges() > 0;
        }

        // Get All Events
        public List<Event> GetAllEvents()
        {
            return db.Events.ToList();
        }

        // Get Event by ID
        public Event? GetEventById(int id)
        {
            return db.Events.Find(id);
        }

        //Update Event
        public bool UpdateEvent(Event ev)
        {
            var ex = db.Events.Find(ev.EventId);
            if (ex != null)
            {
                ex.EventName = ev.EventName;
                ex.EventDate = ev.EventDate;
                ex.OrgId = ev.OrgId;
                return db.SaveChanges() > 0;
            }
            return false;
        }

        // Delete Event
        public bool DeleteEvent(int id)
        {
            var employee = db.Events.Find(id);
            if (employee != null)
            {
                db.Events.Remove(employee);
                return db.SaveChanges() > 0;
            }
            return false;
        }
    }
}
