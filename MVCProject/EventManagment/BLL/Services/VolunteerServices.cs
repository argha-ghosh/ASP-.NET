using AutoMapper;
using BLL.Model;
using DAL.EF.Tables;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class VolunteerServices
    {
        VolunteerRepo repo;
        IMapper mapper;
        public VolunteerServices(VolunteerRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        // Create Volunteer
        public bool CreateVolunteer(VolunteerModel model)
        {
            var mapped = mapper.Map<Volunteer>(model);
            return repo.CreateVolunteer(mapped);
        }

        // Get All Volunteers
        public List<VolunteerModel> GetAllVolunteers()
        {
            var data = repo.GetAllVolunteers();
            return mapper.Map<List<VolunteerModel>>(data);
        }

        // Get Volunteer by ID
        public VolunteerModel GetVolunteerById(int id)
        {
            var data = repo.GetVolunteerById(id);
            return mapper.Map<VolunteerModel>(data);
        }

        // Update Volunteer
        public bool UpdateVolunteer(VolunteerModel model)
        {
            var mapped = mapper.Map<Volunteer>(model);
            return repo.UpdateVolunteer(mapped);
        }

        // Delete Volunteer
        public bool DeleteVolunteer(int id)
        {
            return repo.DeleteVolunteer(id);
        }
    }
}
