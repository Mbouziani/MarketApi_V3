using System;
using System.Collections.Generic;

namespace MarketApi_V3.Models
{
    public partial class Zone
    {
        public Zone()
        {
            Recieps = new HashSet<Reciep>();
            Returnes = new HashSet<Returne>();
        }
        public int ZoneId { get; set; }
        public long ZoneNumber { get; set; }
        public string? ZoneName { get; set; }
        public string ZoneDirector { get; set; } = null!;
        public string ZoneAddress { get; set; } = null!;
        public string ZonePhone { get; set; } = null!;
        public int? BrancheId { get; set; }
        public int? CompanyId { get; set; }
        public string? ZoneType { get; set; }
        public int? ZoneTax { get; set; }
        public int? ZoneReciepCount { get { return Recieps.Count(); } }
        public int? ZoneReturnCount { get { return Returnes.Count(); } }
        public virtual Branche? Branche { get; set; }
        public virtual Company? Company { get; set; }
        public virtual ICollection<Reciep> Recieps { get; set; }
        public virtual ICollection<Returne> Returnes { get; set; }
    }
}
