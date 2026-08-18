using BLL.Models;
using BLL.Services;
using Microsoft.AspNetCore.Http;
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
    }
}
