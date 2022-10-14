using System;
using System.Collections.Generic;

namespace MarketApi_V3.Models
{
    public partial class Branche
    {
        public Branche()
        {
            Recieps = new HashSet<Reciep>();
            Returnes = new HashSet<Returne>();
            Zones = new HashSet<Zone>();
        }

        public int BrancheId { get; set; }
        public long BrancheNumber { get; set; }
        public string? BrancheName { get; set; }
        public string BrancheDirector { get; set; } = null!;
        public string BrancheAddress { get; set; } = null!;
        public string BranchePhone { get; set; } = null!;
        public int? CompanyId { get; set; }

        public virtual Company? Company { get; set; }
        public virtual ICollection<Reciep> Recieps { get; set; }
        public virtual ICollection<Returne> Returnes { get; set; }
        public virtual ICollection<Zone> Zones { get; set; }
    }
}
