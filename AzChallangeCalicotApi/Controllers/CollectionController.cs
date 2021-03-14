using AzChallangeCalicotApi.Base;
using AzChallangeCalicotApi.Type.Interfaces;
using AzChallangeCalicotApi.Type.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AzChallangeCalicotApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionController : ControllerBase
    {
        private IProductService _productService;

        public CollectionController(IProductService productService)
        {
            _productService = productService;
        }
        
        [HttpGet("all")]
        public ActionResult<EnveloppeReponse<List<Produit>>> GetAllProducts()
        {
            return this.OkAvecEnveloppe(_productService.GetProducts());
        }

        [HttpGet("actifs")]
        public ActionResult<EnveloppeReponse<List<Produit>>> GetAllProductsActifs()
        {
            return this.OkAvecEnveloppe(_productService.GetProductsActifs());
        }

        [HttpPost]
        public ActionResult<EnveloppeReponse<Produit>> Create(Produit product)
        {
            return this.OkAvecEnveloppe(_productService.AjouterProduit(product));
        }

        [HttpPut]
        public ActionResult<EnveloppeReponse<Produit>> Update(Produit product)
        {
            return this.OkAvecEnveloppe(_productService.ModifierProduit(product));
        }

        [HttpDelete]
        public ActionResult<EnveloppeReponse<bool>> Delete(Produit product)
        {
            return this.OkAvecEnveloppe(_productService.SupprimerProduit(product)); 
        }
    }
}
