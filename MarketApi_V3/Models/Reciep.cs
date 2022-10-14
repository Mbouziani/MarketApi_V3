using System;
using System.Collections.Generic;

namespace MarketApi_V3.Models
{
    public partial class Reciep
    {
        public Reciep()
        {
            Sales = new HashSet<Sale>();
        }

        public int ReciepId { get; set; }
        public long? ReciepNumber { get; set; }
        public double? ReciepProductCount { get; set; }
        public double? ReciepTotalPrice { get; set; }
        public double? ReciepPriceTax { get; set; }
        public double? ReciepPriceTotalWithTax { get; set; }
        public string? ReciepDate { get; set; }
        public string? ReciepPaymentMethode { get; set; }
        public double? ReciepPaymentPrice { get; set; }
        public int ReciepZoneNumber { get; set; }
        public long? ReciepAgentNumber { get; set; }
        public double? ReciepPercDiscount { get; set; }
        public double? ReciepTotalWithDiscount { get; set; }
        public int? ReciepCloseCashier { get; set; }
        public string? ReciepVatNumber { get; set; }
        public string? ReciepAgentName { get; set; }
        public int? ZoneId { get; set; }
        public int? BranchId { get; set; }
        public int? CompanyId { get; set; }

        public virtual Branche? Branch { get; set; }
        public virtual Company? Company { get; set; }
        public virtual Zone? Zone { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
