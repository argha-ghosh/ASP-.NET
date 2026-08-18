using AutoMapper;
using BLL.Models;
using DAL.EF.Tables;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace BLL.Services
{
    public class ProductService
    {
        ProductRepo services;
        IMapper mapper;
        public ProductService(ProductRepo services, IMapper mapper)
        {
            this.services = services;
            this.mapper = mapper;
        }

        //Add Product
        public ProductModel AddService(ProductModel model)
        {
            var mappedData = mapper.Map<Product>(model);
            var r = services.AddProduct(mappedData);
            return mapper.Map<ProductModel>(r);
        }

        //Get all Productss
        public List<ProductModel> GetAllProducts()
        {
            var data = services.GetAllProducts();
            var mappedData = mapper.Map<List<ProductModel>>(data);
            return mappedData;
        }
    }
}
