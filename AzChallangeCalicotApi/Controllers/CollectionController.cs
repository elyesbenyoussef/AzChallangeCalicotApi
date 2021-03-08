using AzChallangeCalicotApi.Base;
using AzChallangeCalicotApi.Type.Interfaces;
using AzChallangeCalicotApi.Type.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AzChallangeCalicotApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionController : ControllerBase
    {
        private IProductService _productService;
        private IConfiguration _configuration;

        public CollectionController(IProductService productService, IConfiguration configuration)
        {
            _productService = productService;
            _configuration = configuration;
        }
        [HttpGet("all")]
        public ActionResult<EnveloppeReponse<List<Produit>>> GetAllProducts()
        {
            try
            {
                return this.OkAvecEnveloppe(_productService.GetProducts());
            }
            catch (Exception ex)
            {
                var msg = $"GetToken={_configuration.GetValue<bool>("GetToken")} UserAssignedIdentity={_configuration.GetValue<string>("UserAssignedIdentity")} DefaultConnection={_configuration.GetConnectionString("DefaultConnection")}";
                throw new Exception(msg, ex);
            }
            
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
