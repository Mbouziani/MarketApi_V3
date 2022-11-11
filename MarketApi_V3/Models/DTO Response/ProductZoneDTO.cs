namespace MarketApi_V3.Models.DTO_Response
{
    public class ProductZoneDTO
    {
        
        public string? ProductZoneName { get; set; }
        public long? ProductZoneNumber { get; set; }




        public List<ProductZoneDTO> GetProductZones(MarketManagementV2DBContext _context)

        {
            if (_context.Zones == null)
            {
                return new List<ProductZoneDTO> { };
            }

            var _zones = _context.Zones.ToList();
            List < ProductZoneDTO > result = new List<ProductZoneDTO>();
            foreach (var zone in _zones)
            {
                var zoneDTO = new ProductZoneDTO();
                zoneDTO.ProductZoneName = zone.ZoneName;
                zoneDTO.ProductZoneNumber = zone.ZoneNumber;
                result.Add(zoneDTO);
            }



            return result;
        }

    }
}
