using AzChallangeCalicotApi.Type.Interfaces;
using AzChallangeCalicotApi.Type.Models;
using System.Collections.Generic;

namespace AzChallangeCalicotApi.services
{
    public class ProductService : IProductService
    {
        private IDataService _dataService;

        public ProductService(IDataService dataService)
        {
            _dataService = dataService;
        }

        public List<Produit> GetProducts()
        {
            var products = _dataService.ObtenirListeProduits();
            return products;
        }

        public List<Produit> GetProductsActifs()
        {
            var products = _dataService.ObtenirListeProduitsActives();
            return products;
        }

        public Produit AjouterProduit(Produit product)
        {
            return _dataService.AjouterProduit(product);
        }

        public Produit ModifierProduit(Produit produit)
        {
            return _dataService.ModifierProduit(produit);
        }

        public bool SupprimerProduit(Produit produit)
        {
            return _dataService.SupprimerProduit(produit);
        }
    }

}
