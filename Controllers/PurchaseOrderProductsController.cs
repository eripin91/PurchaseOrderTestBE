using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurchaseOrderTestBE.Models;

namespace PurchaseOrderTestBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrderProductsController : ControllerBase
    {
        private readonly PurchaseOrderContext _context;

        public PurchaseOrderProductsController(PurchaseOrderContext context)
        {
            _context = context;
        }

        // GET: api/PurchaseOrderProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseOrderProduct>>> GetPurchaseOrderProduct()
        {
            return await _context.PurchaseOrderProducts.ToListAsync();
        }

        // GET: api/PurchaseOrderProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseOrderProduct>> GetPurchaseOrderProduct(long id)
        {
            var purchaseOrderProduct = await _context.PurchaseOrderProducts.FindAsync(id);

            if (purchaseOrderProduct == null)
            {
                return NotFound();
            }

            return purchaseOrderProduct;
        }

        // PUT: api/PurchaseOrderProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchaseOrderProduct(long id, PurchaseOrderProduct purchaseOrderProduct)
        {
            if (id != purchaseOrderProduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(purchaseOrderProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseOrderProductExists(id))
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

        // POST: api/PurchaseOrderProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PurchaseOrderProduct>> PostPurchaseOrderProduct(PurchaseOrderProduct purchaseOrderProduct)
        {
            _context.PurchaseOrderProducts.Add(purchaseOrderProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPurchaseOrderProduct), new { id = purchaseOrderProduct.Id }, purchaseOrderProduct);
        }

        // DELETE: api/PurchaseOrderProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchaseOrderProduct(long id)
        {
            var purchaseOrderProduct = await _context.PurchaseOrderProducts.FindAsync(id);
            if (purchaseOrderProduct == null)
            {
                return NotFound();
            }

            _context.PurchaseOrderProducts.Remove(purchaseOrderProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PurchaseOrderProductExists(long id)
        {
            return _context.PurchaseOrderProducts.Any(e => e.Id == id);
        }
    }
}
