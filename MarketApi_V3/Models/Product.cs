using System;
using System.Collections.Generic;

namespace MarketApi_V3.Models
{
    public partial class Product
    {
        public Product()
        {
            Salereturneds = new HashSet<Salereturned>();
            Sales = new HashSet<Sale>();
        }

        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public double? ProductPrice { get; set; }
        public string? ProductBarcode { get; set; }
        public string? ProductImageLink { get; set; }
        public string? ProductTypeSize { get; set; }
        public int? ProductActiveStatus { get; set; }
        public string? ProductTypeProduct { get; set; }
        public int? ProductZone { get; set; }

        public virtual ICollection<Salereturned> Salereturneds { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
