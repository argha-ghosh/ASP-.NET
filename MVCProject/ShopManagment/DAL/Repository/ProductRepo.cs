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

        //Get Product by ID
        public Product GetProducts(int id)
        {
            var data = db.Products.Find(id);
            var result = db.Products
                .Where(p => p.ProductId == id)
                .FirstOrDefault();
            return result;
        }

        //Update Product
        public Product UpdateProducts(Product product)
        {
            db.Products.Update(product);
            db.SaveChanges();
            return product;
        }

        //Delete Product
        public void DeleteProduct(int id) {
            var data = db.Products.Find(id);
            if (data != null)
            {
                db.Products.Remove(data);
                db.SaveChanges();
            }
        }


        //Get Product by Price
        public List<Product> GetByPrice() {
            var data = db.Products.ToList();
            var result = db.Products
                .Where(p => Convert.ToDecimal(p.ProductPrice) > 50)
                //.Where(p => Convert.ToDecimal(p.ProductPrice) < 50)  //Products with price less than 50
                .ToList();
            return result;
        }        
    }
}
