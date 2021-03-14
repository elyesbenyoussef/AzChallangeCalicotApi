using AzChallangeCalicotApi.Type.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzChallangeCalicotApi.Type.Interfaces
{
    public interface IProductService
    {
        List<Produit> GetProducts();
        List<Produit> GetProductsActifs();
        Produit AjouterProduit(Produit produit);
        Produit ModifierProduit(Produit produit);
        bool SupprimerProduit(Produit produit);
    }
}
