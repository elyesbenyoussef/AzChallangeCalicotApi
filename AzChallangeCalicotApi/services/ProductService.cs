using System.Collections.Generic;

namespace AzChallangeCalicotApi.services
{
    public class ProductService
    {
        public static List<Models.Product> ELEMENT_DATA = new List<Models.Product>
        {
            new Models.Product{ Id= 1, Name= "Sweat", Price= 49.99, Description= "Sweat à capuche enfilable - Rouge et bleu", ImageSrc= "../../assets/img/products/produit1.jpg" },
            new Models.Product{ Id= 2, Name= "Chaussures blanc", Price= 129.99, Description= "Chaussures Décontractées En Cuir - Blanc", ImageSrc= "../../assets/img/products/produit2.png" },
            new Models.Product{ Id= 3, Name= "Chaussures noir", Price= 129.99, Description= "Chaussures Décontractées En Cuir - Noir", ImageSrc= "../../assets/img/products/produit3.png" },
            new Models.Product{ Id= 4, Name= "Chemise", Price= 54.99, Description= "Chemise slim blanche imprimée", ImageSrc= "../../assets/img/products/produit4.jpg" }
        };

        internal List<Models.Product> GetProducts()
        {
            return ELEMENT_DATA;
        }

        internal void AddProduct(Models.Product product)
        {
            ELEMENT_DATA.Add(product);
        }
    }

}
