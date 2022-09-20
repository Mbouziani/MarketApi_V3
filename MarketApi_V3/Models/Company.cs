using System;
using System.Collections.Generic;

namespace MarketApi_V3.Models
{
    public partial class Company
    {
        public Company()
        {
            Branches = new HashSet<Branche>();
            Zones = new HashSet<Zone>();
        }

        public int CompanyId { get; set; }
        public long CompanyNumber { get; set; }
        public string? CompanyName { get; set; }
        public string CompanyAddress { get; set; } = null!;
        public string CompanyTaxNumber { get; set; } = null!;
        public string CompanyPhone { get; set; } = null!;
        public string CompanyCommercial { get; set; } = null!;

        public virtual ICollection<Branche> Branches { get; set; }
        public virtual ICollection<Zone> Zones { get; set; }
    }
}
