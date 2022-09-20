using System;
using System.Collections.Generic;

namespace MarketApi_V3.Models
{
    public partial class Branche
    {
        public Branche()
        {
            Zones = new HashSet<Zone>();
        }

        public int BrancheId { get; set; }
        public long BrancheNumber { get; set; }
        public string? BrancheName { get; set; }
        public string BrancheDirector { get; set; } = null!;
        public string BrancheAddress { get; set; } = null!;
        public string BranchePhone { get; set; } = null!;
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; } = null!;
        public virtual ICollection<Zone> Zones { get; set; }
    }
}
