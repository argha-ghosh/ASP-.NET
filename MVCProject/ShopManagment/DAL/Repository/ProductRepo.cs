using DAL.EF;
using DAL.EF.Tables;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Text;


namespace DAL.Repository
{
    public class ProductRepo
    {
        ShopManagmentContext db;
        public ProductRepo(ShopManagmentContext db)
        {
            this.db = db;
        }


        //Add Product
        public Product AddProduct(Product product)
        {
            var data = db.Products.Add(product);
            db.SaveChanges();
            return product;
        }

        //Get all Products
        public List<Product> GetAllProducts()
        {
            var data = db.Products.ToList();
            return data;
        }
    }
}
