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
    public class PurchaseOrderShippingsController : ControllerBase
    {
        private readonly PurchaseOrderContext _context;

        public PurchaseOrderShippingsController(PurchaseOrderContext context)
        {
            _context = context;
        }

        // GET: api/PurchaseOrderShippings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseOrderShipping>>> GetPurchaseOrderShipping()
        {
            return await _context.PurchaseOrderShippings.ToListAsync();
        }

        // GET: api/PurchaseOrderShippings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseOrderShipping>> GetPurchaseOrderShipping(long id)
        {
            var purchaseOrderShipping = await _context.PurchaseOrderShippings.FindAsync(id);

            if (purchaseOrderShipping == null)
            {
                return NotFound();
            }

            return purchaseOrderShipping;
        }

        // PUT: api/PurchaseOrderShippings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchaseOrderShipping(long id, PurchaseOrderShipping purchaseOrderShipping)
        {
            if (id != purchaseOrderShipping.Id)
            {
                return BadRequest();
            }

            _context.Entry(purchaseOrderShipping).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseOrderShippingExists(id))
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

        // POST: api/PurchaseOrderShippings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PurchaseOrderShipping>> PostPurchaseOrderShipping(PurchaseOrderShipping purchaseOrderShipping)
        {
            _context.PurchaseOrderShippings.Add(purchaseOrderShipping);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPurchaseOrderShipping), new { id = purchaseOrderShipping.Id }, purchaseOrderShipping);
        }

        // DELETE: api/PurchaseOrderShippings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchaseOrderShipping(long id)
        {
            var purchaseOrderShipping = await _context.PurchaseOrderShippings.FindAsync(id);
            if (purchaseOrderShipping == null)
            {
                return NotFound();
            }

            _context.PurchaseOrderShippings.Remove(purchaseOrderShipping);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PurchaseOrderShippingExists(long id)
        {
            return _context.PurchaseOrderShippings.Any(e => e.Id == id);
        }
    }
}
