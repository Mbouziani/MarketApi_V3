using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarketApi_V3.Models;
using MARKET_API_V3.HelperCors;
using MarketApi_V3.Models.DTO_Response;

namespace MarketApi_V3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly MarketManagementV2DBContext _context;

        public ProductsController(MarketManagementV2DBContext context)
        {
            _context = context;
        }
        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts([FromQuery] PagingMove paging , [FromQuery]  String? searchQry)
        {
          if (_context.Products == null)
          {
              return NotFound();
          } 
            
          var _products = await _context.Products.OrderByDescending(p=>p.ProductId).Include(ps=>ps.Salereturneds).Include(psr=>psr.Sales)
                .ToListAsync();

          ProductDTO  productDTO = new ProductDTO();
          var filterProducts = productDTO.FilterProduct(_products , searchQry);
          var resultProducts = productDTO.toProductDTO(filterProducts);

            ProductZoneDTO zoneDTO = new ProductZoneDTO();
            var zones = zoneDTO.GetProductZones(_context);
 
             
           var pagedResponse = new PagingResponse<ProductDTO>(resultProducts.AsQueryable(), paging, zones);
          return Ok(pagedResponse);
        }


        // GET: api/Products
        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts([FromQuery] String? typeProduct, String zoneProductNbr, String allProductNbr)
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            var _product = await _context.Products
               .ToListAsync();
           
            if (!string.IsNullOrWhiteSpace(typeProduct))
            {
                _product = _product.Where(pro => pro.ProductTypeProduct == typeProduct).ToList();
            }
            if (!string.IsNullOrWhiteSpace(allProductNbr) && !string.IsNullOrWhiteSpace(zoneProductNbr))
            {
                _product = _product.Where(pro => pro.ProductZone == int.Parse(allProductNbr) || pro.ProductZone == int.Parse(zoneProductNbr)).ToList();
            }
            return _product;
             
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
          if (_context.Products == null)
          {
              return NotFound();
          }
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
          if (_context.Products == null)
          {
              return Problem("Entity set 'MarketManagementV2DBContext.Products'  is null.");
          }
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }


        [HttpPost("List")]
        public async Task<ActionResult<string>> PostListOfProducts([FromBody] List<Product> _list)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set is null.");
            }
            for (int i = 0; i < _list.Count; i++)
            {
                _context.Products.Add(_list[i]);
                await _context.SaveChangesAsync();
            }

            return Ok(_list.Count.ToString());
        }


        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return (_context.Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}
