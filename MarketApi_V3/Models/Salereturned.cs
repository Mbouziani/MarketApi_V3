using System;
using System.Collections.Generic;

namespace MarketApi_V3.Models
{
    public partial class Salereturned
    {
        public int RsaleId { get; set; }
        public int? ProductId { get; set; }
        public int? ReturnId { get; set; }
        public double? RsaleQuntity { get; set; }
        public double? RsaleTotalPrice { get; set; }
        public long? RsaleReturnNumber { get; set; }
        public string? RsaleProductName { get; set; }
        public string? RsaleProductTypeSize { get; set; }

        public virtual Product? Product { get; set; }
        public virtual Reciepreturned? Return { get; set; }
    }
}
