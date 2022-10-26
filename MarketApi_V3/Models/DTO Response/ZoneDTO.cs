namespace MarketApi_V3.Models.DTO_Response
{
    public class ZoneDTO
    {
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
        public int? ZoneReciepCount { get; set; }
        public int? ZoneReturnCount { get; set; }
    }
}
