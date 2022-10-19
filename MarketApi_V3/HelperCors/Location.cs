using MarketApi_V3.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketApi_V3.HelperCors
{
    public class Location
    {
        public int? companyID { get; set; }
        public string? companyName { get; set; }
        public long? companyNumber { get; set; }
        public string? companyTaxNumber { get; set; }
        public string? companyAddress { get; set; }
        public string? companyPhone { get; set; }
        public string? companyMobile { get; set; }
        public string? companyComercial { get; set; }
        public string? companyLink { get; set; }
        public int? brancheID { get; set; }
        public long? brancheNumber { get; set; }
        public string? brancheName { get; set; }
        public int?    zoneID { get; set; }
        public long? zoneNumber { get; set; }
        public string? zoneType { get; set; }
        public int?    zonTax { get; set; }
        public int? fixDigit { get; set; }


        public Task<Location>  getLocation(MarketManagementV2DBContext _context, long number)
        {
            Location l= new Location();


            var result =   _context.Zones.Include(z => z.Company).Include(z => z.Branche).Where(_zone => _zone.ZoneNumber == number)
                .First();

           

            l.companyID = result.CompanyId;
            l.companyName = result.Company?.CompanyName;
            l.companyNumber = result.Company?.CompanyNumber;
            l.companyTaxNumber = result.Company?.CompanyTaxNumber;
            l.companyAddress = result.Company?.CompanyAddress;
            l.companyPhone = result.Company?.CompanyPhone;
            l.companyMobile = result.Company?.CompanyPhone;
            l.companyComercial = result.Company?.CompanyCommercial;
            l.companyLink = result.Company?.CompanyLink;
            l.brancheID = result.Branche?.BrancheId;
            l.brancheNumber = result.Branche?.BrancheNumber;
            l.brancheName = result.Branche?.BrancheName;
            l.zoneID = result.ZoneId;
            l.zoneNumber = result.ZoneNumber;
            l.zoneType = result.ZoneType;
            l.zonTax = result.ZoneTax;
            l.fixDigit = result.Company?.CompanyFractionDigits;










            return Task.FromResult(l);
        }



    }
}
