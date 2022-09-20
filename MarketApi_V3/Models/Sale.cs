using System;
using System.Collections.Generic;

namespace MarketApi_V3.Models
{
    public partial class Sale
    {
        public int SaleId { get; set; }
        public int? ProductId { get; set; }
        public int? ReciepId { get; set; }
        public double? SaleQuntity { get; set; }
        public double? SaleTotalPrice { get; set; }
        public long? SaleReciepNumber { get; set; }
        public string? SaleProductName { get; set; }
        public string? SaleProductTypeSize { get; set; }

        public virtual Product? Product { get; set; }
        public virtual Reciep? Reciep { get; set; }
    }
}
