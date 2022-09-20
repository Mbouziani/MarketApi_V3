using System;
using System.Collections.Generic;

namespace MarketApi_V3.Models
{
    public partial class Zone
    {
        public int ZoneId { get; set; }
        public long ZoneNumber { get; set; }
        public string? ZoneName { get; set; }
        public string ZoneDirector { get; set; } = null!;
        public string ZoneAddress { get; set; } = null!;
        public string ZonePhone { get; set; } = null!;
        public int BrancheId { get; set; }
        public int CompanyId { get; set; }
        public string? ZoneType { get; set; }

        public virtual Branche Branche { get; set; } = null!;
        public virtual Company Company { get; set; } = null!;
    }
}
