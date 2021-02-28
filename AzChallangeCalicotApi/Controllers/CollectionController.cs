using AzChallangeCalicotApi.Base;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AzChallangeCalicotApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionController : ControllerBase
    {
        [HttpGet("all")]
        public ActionResult<EnveloppeReponse<List<Models.Product>>> GetAllProducts()
        {
            var _productService = new services.ProductService();
            return new OkObjectResult(new EnveloppeReponse<List<Models.Product>>() { Data = _productService.GetProducts() });
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
