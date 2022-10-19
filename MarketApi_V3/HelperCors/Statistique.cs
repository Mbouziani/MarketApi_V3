﻿using MarketApi_V3.Models;
using System.ComponentModel.DataAnnotations;

namespace MarketApi_V3.HelperCors
{
    public class Statistique
    {
      
        
         


        public int ZoneCount { get; set; }
        public int BranchCount { get; set; }
        public int ReciepCount { get; set; }
        public int ReturnCount { get; set; }
        public int AgentCount { get; set; }
        public double? BigReciepPrice { get; set; } 
        public double? BigDiscountPrice { get; set; }
        public double TtcReciepPrice { get; set; }
        public double TtcReturnPrice { get; set; }
        public double TotalNetReciepPrice { get; set; }
        public double TotalDiscountPrice { get; set; }
        public dynamic? TopClientsOnSale { get; set; }
      //  public dynamic? TopClientsOnDisc { get; set; }
        public dynamic? PaymentTypeCount { get; set; }
        public dynamic? ProductTypeCount { get; set; }
        public dynamic? TtcByZone { get; set; }
      //  public dynamic? TtcByBranch { get; set; }
        public dynamic? FixDigit { get; set; }



        public   Task<Statistique> getStatic(MarketManagementV2DBContext _context)
        {

            
            Statistique s = new Statistique();

            // Count of Column
            s.ZoneCount = _context.Zones.Count();
            s.BranchCount = _context.Branches.Count();
            s.ReciepCount = _context.Recieps.Count();
            s.ReturnCount = _context.Returnes.Count();
            s.AgentCount = _context.Agents.Count();

            s.FixDigit = (int)_context.Companies.FirstOrDefault()!.CompanyFractionDigits!;

            //// Big Value in Column
            s.BigReciepPrice =   (double)_context.Recieps.Max(r => r.ReciepPriceTotalWithTax ?? 0) ;
            s.BigDiscountPrice  = (double)_context.Recieps.Max(r => r.ReciepPercDiscount ?? 0) ;

            // Sum of Column
            s.TtcReciepPrice =  (double)_context.Recieps.Sum(r => r.ReciepPriceTotalWithTax ?? 0) ;
            s.TtcReturnPrice =  (double)_context.Returnes.Sum(r => r.ReturnPriceTotalWithTax ?? 0) ;
            s.TotalNetReciepPrice = (double)_context.Recieps.Sum(r => r.ReciepTotalPrice ?? 0) ;
            s.TotalDiscountPrice =  (double)_context.Recieps.Sum(r => r.ReciepPercDiscount ?? 0) ;

            //Top Value On Column
          

            //s.TopClientsOnDisc = _context.Recieps.Where(c => c.ReciepAgentNumber != 0).GroupBy(m => m.ReciepAgentNumber)
            //                     .Select(m => new 
            //                     { 
            //                         AgentNumber = m.Key,
            //                         Price = m.Sum(v => v.ReciepPercDiscount)
            //                     })
            //                     .OrderBy(m => m.Price);
              s.TopClientsOnSale = _context.Recieps.Where(c=>c.ReciepAgentNumber!=0).GroupBy(m =>new { m.ReciepAgentNumber, m.ReciepAgentName, m.ReciepPercDiscount })
                                             .Select(m => new 
                                             { 
                                                 AgentInfo = m.Key,
                                                 Price = m.Sum(v => v.ReciepPriceTotalWithTax)
                                             })
                                             .OrderBy(m => m.Price).Take(5);
            // Multi Grouped Value
            s.PaymentTypeCount = _context.Recieps.GroupBy(m => m.ReciepPaymentMethode)
                                 .Select(m => new { PaymentType = m.Key, Count = m.Count()})
                                 .OrderBy(m => m.Count);

            s.ProductTypeCount = _context.Products.GroupBy(m =>m.ProductTypeProduct)
                                 .Select(m => new { ProductType = m.Key, Count = m.Count() })
                                 .OrderBy(m => m.Count); ;

            s.TtcByZone = _context.Recieps.GroupBy(m => new { m.ZoneId , m.Zone!.ZoneType, m.Zone!.ZoneNumber })
                                 .Select(m => new 
                                 {
                                     ZoneInfo = m.Key,
                                     TotalPrice = m.Sum(v => v.ReciepPriceTotalWithTax)
                                 })
                                 .Take(15);

            //s.TtcByBranch = _context.Recieps.GroupBy(m => new { m.BranchId, m.Branch!.BrancheName, m.Branch!.BrancheNumber })
            //                    .Select(m => new 
            //                    { 
            //                        BranchInfo = m.Key, 
            //                        TotalPrice = m.Sum(v => v.ReciepPriceTotalWithTax)
            //                    })
            //                    .OrderBy(m => m.TotalPrice);

            return Task.FromResult( s);

        }
    }
     
}
