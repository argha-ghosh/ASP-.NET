using AutoMapper;
using BLL.Models;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class MappingConfig : Profile
    {
        public MappingConfig() {
            CreateMap<Product,ProductModel>().ReverseMap();
        }
    }
}
