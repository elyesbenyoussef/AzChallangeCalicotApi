using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzChallangeCalicotApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionController : ControllerBase
    {
        [HttpGet("all")]
        public List<Models.Product> GetAllProducts()
        {
            var _productService = new services.ProductService();
            return _productService.GetProducts();
        }

        [HttpPost]
        public ActionResult Create(Models.Product product)
        {
            var _productService = new services.ProductService();
            _productService.AddProduct(product);
            return Ok();
        }
    }
}
