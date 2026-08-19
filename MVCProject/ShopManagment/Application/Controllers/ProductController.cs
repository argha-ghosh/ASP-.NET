using BLL.Models;
using BLL.Services;
using DAL.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ProductService service;
        
        public ProductController(ProductService service)
        {
            this.service = service;
        }

        //Add Product
        [HttpPost("addProducts")]
        public IActionResult AddProduct(ProductModel model)
        {
            var result = service.AddService(model);
            return Ok(result);
        }

        //Get all Products
        [HttpGet("allProducts")]
        public IActionResult GetAllProducts()
        {
            var result = service.GetAllProducts();
            return Ok(result);
        }

        //Get Product by ID
        [HttpGet("getProducts/{id}")]
        public IActionResult GetProduct(int id) {
            var result = service.GetProducts(id);
            if (result == null)
                return NotFound("Product not found");

            return Ok(result);
        }

        //Update Product by ID
        [HttpPut("updateProducts/{id}")]
        public IActionResult UpdateProduct(int id, ProductModel model)
        {
            var result = service.UpdateProducts(id, model);
            return Ok(result);
        }

        //Delete Product by ID
        [HttpDelete("deleteProducts/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            service.DeleteProduct(id);
            return Ok("Product deleted successfully");
        }

        //Get Product by Price
        [HttpGet("getByPrice")]
        public IActionResult GetByPrice()
        {
            var result = service.GetByPrice();
            if (result == null)
                return NotFound("Product not found");

            return Ok(result);
        }
    }
}
