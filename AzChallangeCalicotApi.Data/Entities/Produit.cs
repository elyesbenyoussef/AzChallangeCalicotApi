﻿using System;
using System.Collections.Generic;
using System.Text;

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
    }
}