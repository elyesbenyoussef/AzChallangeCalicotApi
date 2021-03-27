namespace AzChallangeCalicotApi.Type.Models
{
    public class Image : ModelBase
    {
        public int ImageId { get; set; }
        public int ProduitId { get; set; }
        public string Nom { get; set; }
        public string Url { get; set; }
        public Produit Produit { get; set; }
    }
}
