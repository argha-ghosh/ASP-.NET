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
        ProductRepo repo;
        IMapper mapper;
        public ProductService(ProductRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        //Add Product
        public ProductModel AddService(ProductModel model)
        {
            var mappedData = mapper.Map<Product>(model);
            var r = repo.AddProduct(mappedData);
            return mapper.Map<ProductModel>(r);
        }

        //Get all Productss
        public List<ProductModel> GetAllProducts()
        {
            var data = repo.GetAllProducts();
            var mappedData = mapper.Map<List<ProductModel>>(data);
            return mappedData;
        }

        //Get Product by ID
        public ProductModel GetProducts(int id)
        {
            var data = repo.GetProducts(id);
            return mapper.Map<ProductModel>(data);
        }

        //Update Product
        public ProductModel UpdateProducts(int id, ProductModel model)
        {
            var mappedData = mapper.Map<Product>(model);
            mappedData.ProductId = id;
            var r = repo.UpdateProducts(mappedData);
            return mapper.Map<ProductModel>(r);
        }

        //Delete Product
        public void DeleteProduct(int id)
        {
            repo.DeleteProduct(id);
        }

        //Get Products by Pricesss
        public List<ProductModel> GetByPrice()
        {
            var data = repo.GetByPrice();
            return mapper.Map<List<ProductModel>>(data);
        }
    }
}
