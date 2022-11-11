using Microsoft.AspNetCore.Mvc;

namespace MarketApi_V3.Models.DTO_Response
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public double? ProductPrice { get; set; }
        public string? ProductBarcode { get; set; }
        public string? ProductImageLink { get; set; }
        public string? ProductTypeSize { get; set; }
        public int? ProductActiveStatus { get; set; }
        public string? ProductTypeProduct { get; set; }
        public int? ProductZone { get; set; }
        public int? ProductSaleCount { get; set; }
        public int? ProductReturnSaleCount { get; set; }






        public   IEnumerable<ProductDTO> toProductDTO(IEnumerable<Product> listProduct)
        {
           
            List<ProductDTO> resultProductDTO = new List<ProductDTO> { };
            foreach (var item in listProduct)
            {
                ProductDTO pDTO= new ProductDTO();
                pDTO.ProductId = item.ProductId;
                pDTO.ProductName = item.ProductName;
                pDTO.ProductPrice = item.ProductPrice;
                pDTO.ProductBarcode = item.ProductBarcode;
                pDTO.ProductImageLink = item.ProductImageLink;
                pDTO.ProductTypeSize = item.ProductTypeSize;
                pDTO.ProductActiveStatus = item.ProductActiveStatus;
                pDTO.ProductTypeProduct = item.ProductTypeProduct;
                pDTO.ProductZone = item.ProductZone;
                pDTO.ProductSaleCount = item.Sales.Count;
                pDTO.ProductReturnSaleCount = item.Salereturneds.Count;

                resultProductDTO.Add(pDTO);

            }
            IEnumerable<ProductDTO> result = resultProductDTO;

            return result;

        }


        public IEnumerable<Product> FilterProduct(List<Product> listProduct, [FromQuery] String? typeProduct, String? zoneProductNbr, String? productNameOrBareCode)
        {

            if (!string.IsNullOrWhiteSpace(productNameOrBareCode))
            {
                listProduct = listProduct.Where(pro => pro.ProductName == productNameOrBareCode || pro.ProductBarcode== productNameOrBareCode).ToList();
            }
            if (!string.IsNullOrWhiteSpace(typeProduct))
            {
                listProduct = listProduct.Where(pro => pro.ProductTypeProduct == typeProduct).ToList();
            }
            if ( !string.IsNullOrWhiteSpace(zoneProductNbr))
            {
                listProduct = listProduct.Where(pro => pro.ProductZone == int.Parse(zoneProductNbr)).ToList();
            }

            IEnumerable<Product> result = listProduct;
            return listProduct;
        }


    }
}
