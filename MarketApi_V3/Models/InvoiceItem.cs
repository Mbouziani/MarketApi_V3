using System;
using System.Collections.Generic;

namespace MarketApi_V3.Models
{
    public partial class InvoiceItem
    {
        public int Id { get; set; }
        public int FacilityId { get; set; }
        public int BranchId { get; set; }
        public int SaleOfPointId { get; set; }
        public int InvoiceId { get; set; }
        public int? SellerId { get; set; }
        public string? Type { get; set; }
        public double? Price { get; set; }
        public int? TypeInvoiceDetail { get; set; }
        public double? Quantity { get; set; }
        public int? Counterid { get; set; }
        public string? ArbName { get; set; }
        public int? WhereHouseid { get; set; }
        public int? Bomba { get; set; }
        public int? Closecahier { get; set; }
        public double? Tax { get; set; }
        public double? TimeStamp { get; set; }
        public double? TotalPrice { get; set; }
        public double? DateStamp { get; set; }
    }
}
