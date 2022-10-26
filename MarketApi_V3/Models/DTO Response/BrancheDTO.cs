namespace MarketApi_V3.Models.DTO_Response
{
    public class BrancheDTO
    {
        public int BrancheId { get; set; }
        public long BrancheNumber { get; set; }
        public string? BrancheName { get; set; }
        public string BrancheDirector { get; set; } = null!;
        public string BrancheAddress { get; set; } = null!;
        public string BranchePhone { get; set; } = null!;
        public int? CompanyId { get; set; }
        public virtual ICollection<ZoneDTO>? Zones { get; set; }
    }
}
