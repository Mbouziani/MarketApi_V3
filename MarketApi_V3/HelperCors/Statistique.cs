using System.ComponentModel.DataAnnotations;

namespace MarketApi_V3.HelperCors
{
    public class Statistique
    {
        [Key]
        public int reciepCount { get; set; }
        public double reciepTotalPrice { get; set; }
        public double reciepTotalDiscount { get; set; }
        public double reciepTotalWithDiscount { get; set; }
        public double reciepTotalTax { get; set; }
        public double reciepTotalWithTax { get; set; }




    }
}
