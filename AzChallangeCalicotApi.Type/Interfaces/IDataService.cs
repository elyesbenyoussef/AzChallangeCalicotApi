using AzChallangeCalicotApi.Type.Models;
using System.Collections.Generic;

namespace AzChallangeCalicotApi.Type.Interfaces
{
    public interface IDataService
    {
        List<Produit> ObtenirListeProduits();
        List<Produit> ObtenirListeProduitsActives();
        Produit AjouterProduit(Produit produit);
        Produit ModifierProduit(Produit produit);
        bool SupprimerProduit(Produit produit);
        Produit ObtenirProduit(int produitId);
        Image AjouterImage(Image image);
    }
}
