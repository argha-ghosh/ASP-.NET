using AutoMapper;
using BLL.Model;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Event, EventModel>().ReverseMap();
            CreateMap<Volunteer, VolunteerModel>().ReverseMap();
        }
    }
}
