using AzChallangeCalicotApi.Type.Interfaces;
using AzChallangeCalicotApi.Type.Models;
using System.Collections.Generic;

namespace AzChallangeCalicotApi.services
{
    public class ProductService : IProductService
    {
        public static List<Produit> ELEMENT_DATA = new List<Produit>
        {
            new Produit{ ProduitId= 1, Nom= "Sweat", Prix= 49.99m, Description= "Sweat à capuche enfilable - Rouge et bleu", ImageSrc= "../../assets/img/products/produit1.jpg" },
            new Produit{ ProduitId= 2, Nom= "Chaussures blanc", Prix= 129.99m, Description= "Chaussures Décontractées En Cuir - Blanc", ImageSrc= "../../assets/img/products/produit2.png" },
            new Produit{ ProduitId= 3, Nom= "Chaussures noir", Prix= 129.99m, Description= "Chaussures Décontractées En Cuir - Noir", ImageSrc= "../../assets/img/products/produit3.png" },
            new Produit{ ProduitId= 4, Nom= "Chemise", Prix= 54.99m, Description= "Chemise slim blanche imprimée", ImageSrc= "../../assets/img/products/produit4.jpg" }
        };
        private IDataService _dataService;

        public ProductService(IDataService dataService)
        {
            _dataService = dataService;
        }

        public List<Produit> GetProducts()
        {
            //return ELEMENT_DATA;
            var products = _dataService.ObtenirListeProduits();
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
