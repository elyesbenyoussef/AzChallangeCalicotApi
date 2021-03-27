using System.Collections.Generic;

namespace AzChallangeCalicotApi.Data.Entities
{
    public class Produit : EntiteBase
    {
        public int ProduitId { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public decimal Prix { get; set; }
        public string ImageSrc { get; set; }
        public bool IndActive { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
