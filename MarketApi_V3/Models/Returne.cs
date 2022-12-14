using System;
using System.Collections.Generic;

namespace MarketApi_V3.Models
{
    public partial class Returne
    {
        public Returne()
        {
            Salereturneds = new HashSet<Salereturned>();
        }

        public int ReturnId { get; set; }
        public long? ReturnreciepNumber { get; set; }
        public long? ReturnNumber { get; set; }
        public double? ReturnProductCount { get; set; }
        public double? ReturnTotalPrice { get; set; }
        public double? ReturnPriceTax { get; set; }
        public double? ReturnPriceTotalWithTax { get; set; }
        public string? ReturnDate { get; set; }
        public string? ReturnReciepDate { get; set; }
        public string? ReturnPaymentMethode { get; set; }
        public double? ReturnPaymentPrice { get; set; }
        public int ReturnZoneNumber { get; set; }
        public long? ReturnAgentNumber { get; set; }
        public double? ReturnPercDiscount { get; set; }
        public double? ReturnotalWithDiscount { get; set; }
        public int? ReturnCloseCashier { get; set; }
        public string? ReturnVatNumber { get; set; }
        public string? ReturnAgentName { get; set; }
        public int? ZoneId { get; set; }
        public int? BranchId { get; set; }
        public int? CompanyId { get; set; }

        public virtual Branche? Branch { get; set; }
        public virtual Company? Company { get; set; }
        public virtual Zone? Zone { get; set; }
        public virtual ICollection<Salereturned> Salereturneds { get; set; }
    }
}
