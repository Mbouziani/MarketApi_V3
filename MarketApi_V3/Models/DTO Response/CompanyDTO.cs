namespace MarketApi_V3.Models.DTO_Response
{
    public class CompanyDTO
    {
        public int CompanyId { get; set; }
        public long CompanyNumber { get; set; }
        public string? CompanyName { get; set; }
        public string CompanyAddress { get; set; } = null!;
        public string CompanyTaxNumber { get; set; } = null!;
        public string CompanyPhone { get; set; } = null!;
        public string CompanyCommercial { get; set; } = null!;
        public int? CompanyZoneCount { get; set; }
        public int? CompanyFractionDigits { get; set; }
        public string? CompanyLink { get; set; }

        public virtual ICollection<BrancheDTO>? Branches { get; set; }  
    }
}
