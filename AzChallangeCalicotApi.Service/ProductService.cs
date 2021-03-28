using AzChallangeCalicotApi.Type.Interfaces;
using AzChallangeCalicotApi.Type.Models;
using System.Collections.Generic;

namespace AzChallangeCalicotApi.services
{
    public class ProductService : IProductService
    {
        private IDataService _dataService;
        private IBlobStorageService _blobStorageService;

        public ProductService(IDataService dataService, IBlobStorageService blobStorageService)
        {
            _dataService = dataService;
            _blobStorageService = blobStorageService;
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

                // Create thumb
                _blobStorageService.CreateThumb(image.Nom);
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
