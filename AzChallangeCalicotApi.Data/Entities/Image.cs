namespace AzChallangeCalicotApi.Data.Entities
{
    public class Image : EntiteBase
    {
        public int ImageId { get; set; }
        public int ProduitId { get; set; }
        public string Nom { get; set; }
        public string Url { get; set; }

        public virtual Produit Produit { get; set; }
    }
}
