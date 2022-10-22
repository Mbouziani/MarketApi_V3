using MarketApi_V3.Models;
using System.ComponentModel.DataAnnotations;

namespace MarketApi_V3.HelperCors
{
    public class Statistique
    {
      
        
         


        public int? ZoneCount { get; set; }
        public int? BranchCount { get; set; }
        public int? ReciepCount { get; set; }
        public int? ReturnCount { get; set; }
        public int? AgentCount { get; set; }
        public double? BigReciepPrice { get; set; } 
        public double? BigDiscountPrice { get; set; }
        public double? TtcReciepPrice { get; set; }
        public double? TtcReturnPrice { get; set; }
        public double? TotalNetReciepPrice { get; set; }
        public double? TotalDiscountPrice { get; set; }
        public dynamic? TopClientsOnSale { get; set; }
      //  public dynamic? TopClientsOnDisc { get; set; }
        public dynamic? PaymentTypeCount { get; set; }
        public dynamic? ProductTypeCount { get; set; }
        public dynamic? TtcByZone { get; set; }
      //  public dynamic? TtcByBranch { get; set; }
        public dynamic? FixDigit { get; set; }



        public Task<Statistique> getStatic(MarketManagementV2DBContext _context)
        {


            Statistique s = new Statistique();

            // Count of Column
            if (_context.Companies.Any())
            {
                s.FixDigit = (int)(_context.Companies.FirstOrDefault()?.CompanyFractionDigits ?? 0);

            }
            else
            {
                s.FixDigit = null;
            }
            if (_context.Branches.Any())
            {
                s.BranchCount = _context.Branches.Count();
            }
            else
            {
                s.BranchCount = null;
            }
            if (_context.Zones.Any())
            {
                s.ZoneCount = _context.Zones.Count();
            }
            else
            {
                s.ZoneCount = null;
            }
            if (_context.Recieps.Any())
            {
                s.ReciepCount = _context.Recieps.Count();
                s.BigReciepPrice = (double)_context.Recieps.Max(r => r.ReciepPriceTotalWithTax ?? 0);
                s.BigDiscountPrice = (double)_context.Recieps.Max(r => r.ReciepPercDiscount ?? 0);
                s.TtcReciepPrice = (double)_context.Recieps.Sum(r => r.ReciepPriceTotalWithTax ?? 0);
                s.TotalNetReciepPrice = (double)_context.Recieps.Sum(r => r.ReciepTotalPrice ?? 0);
                s.TotalDiscountPrice = (double)_context.Recieps.Sum(r => r.ReciepPercDiscount ?? 0);
                s.TopClientsOnSale = _context.Recieps.Where(c => c.ReciepAgentNumber != 0)
                                         .GroupBy(m => new { m.ReciepAgentNumber, m.ReciepAgentName, m.ReciepPercDiscount })
                                         .Select(m => new
                                         {
                                             AgentInfo = m.Key,
                                             Price = m.Sum(v => v.ReciepPriceTotalWithTax)
                                         }).OrderBy(m => m.Price).Take(5);

                s.PaymentTypeCount = _context.Recieps.GroupBy(m => m.ReciepPaymentMethode)
                                     .Select(m => new { PaymentType = m.Key, Count = m.Count() })
                                     .OrderBy(m => m.Count);

                s.TtcByZone = _context.Recieps.GroupBy(m => new { m.ZoneId, m.Zone!.ZoneType, m.Zone!.ZoneNumber })
                                     .Select(m => new
                                     {
                                         ZoneInfo = m.Key,
                                         TotalPrice = m.Sum(v => v.ReciepPriceTotalWithTax)
                                     })
                                     .Take(15);
            }
            else
            {
                s.ReciepCount = null;
                s.BigReciepPrice = null;
                s.BigDiscountPrice = null;
                s.TtcReciepPrice = null;
                s.TotalNetReciepPrice = null;
                s.TotalDiscountPrice = null;
                s.TopClientsOnSale = null;
                s.PaymentTypeCount = null;
                s.TtcByZone = null;
            }
            if (_context.Returnes.Any())
            {
                s.ReturnCount = _context.Returnes.Count();
                s.TtcReturnPrice = (double)_context.Returnes.Sum(r => r.ReturnPriceTotalWithTax ?? 0);
            }
            else
            {
                s.ReturnCount = null;
                s.TtcReturnPrice = null;
            }
            if (_context.Agents.Any())
            {
                s.AgentCount = _context.Agents.Count();
            }
            else
            {
                s.AgentCount = null;
            }
            if (_context.Products.Any())
            {
                s.ProductTypeCount = _context.Products.GroupBy(m => m.ProductTypeProduct)
                                 .Select(m => new { ProductType = m.Key, Count = m.Count() })
                                 .OrderBy(m => m.Count);
            }
            else
            {
                s.ProductTypeCount = null;
            }

            return Task.FromResult(s);
        }



        private dynamic? checkNullable(List<dynamic> val)
        {
            if (val.Any())
            {
                return val;
            }
            else
            {
                return null;

            }
        }
    }
     
}
