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
            var produit = _dataService.AjouterProduit(product);
            foreach (var image in product.Images)
            {
                image.ProduitId = produit.ProduitId;
                _dataService.AjouterImage(image);
            }

            return _dataService.ObtenirProduit(produit.ProduitId);
            
        }

        public Produit ModifierProduit(Produit produit)
        {
            return _dataService.ModifierProduit(produit);
        }

        public bool SupprimerProduit(Produit produit)
        {
            return _dataService.SupprimerProduit(produit);
        }

        public Produit GetProduct(int produitId)
        {
            return _dataService.ObtenirProduit(produitId);
        }
    }

}
