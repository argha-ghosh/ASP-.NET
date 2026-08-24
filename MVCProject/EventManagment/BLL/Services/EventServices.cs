using AutoMapper;
using BLL.Model;
using DAL.EF.Tables;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class EventServices
    {
        EventRepo repo;
        IMapper mapper;
        public EventServices(EventRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        // Create Event
        public bool CreateEvent(EventModel model)
        {
            var mapped = mapper.Map<Event>(model);
            return repo.CreateEvent(mapped);
        }

        // Get All Events
        public List<EventModel> GetAllEvents()
        {
            var data = repo.GetAllEvents();
            return mapper.Map<List<EventModel>>(data);
        }

        // Get Event by ID
        public EventModel GetEventById(int id)
        {
            var data = repo.GetEventById(id);
            return mapper.Map<EventModel>(data);
        }

        // Update Event
        public bool UpdateEvent(EventModel model)
        {
            var mapped = mapper.Map<Event>(model);
            return repo.UpdateEvent(mapped);
        }

        // Delete Event
        public bool DeleteEvent(int id)
        {
            return repo.DeleteEvent(id);
        }
    }
}
