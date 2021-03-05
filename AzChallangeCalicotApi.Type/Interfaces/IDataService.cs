using AzChallangeCalicotApi.Type.Models;
using System.Collections.Generic;

namespace AzChallangeCalicotApi.Type.Interfaces
{
    public interface IDataService
    {
        List<Produit> ObtenirListeProduits();
        Produit AjouterProduit(Produit produit);
        Produit ModifierProduit(Produit produit);
        bool SupprimerProduit(Produit produit);
    }
}
