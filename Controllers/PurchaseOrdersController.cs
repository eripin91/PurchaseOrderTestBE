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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrdersController : ControllerBase
    {
        private readonly PurchaseOrderContext _context;

        public PurchaseOrdersController(PurchaseOrderContext context)
        {
            _context = context;
        }

        // GET: api/PurchaseOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseOrder>>> GetPurchaseOrder()
        {
            return await _context.PurchaseOrders.ToListAsync();
        }

        // GET: api/PurchaseOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseOrderDTO>> GetPurchaseOrder(long id)
        {
            var purchaseOrder = await _context.PurchaseOrders
                .Include(s => s.PurchaseOrderShipping)
                .Include(s => s.PurchaseOrderProduct)
                .FirstOrDefaultAsync(s=>s.Id == id);

            if (purchaseOrder == null)
            {
                return NotFound();
            }
            // Find Subtotal
            decimal subTotal = purchaseOrder.PurchaseOrderProduct.Sum(s => s.Price * s.Qty);
            decimal subTotalLessDiscount = subTotal - (subTotal * purchaseOrder.Discount/100);
            decimal totalTax = subTotal * (purchaseOrder.TaxRate/100);
            decimal total = subTotalLessDiscount - totalTax - purchaseOrder.ShippingFee;

            PurchaseOrderDTO purchaseOrderDTO = new PurchaseOrderDTO
            {
                Id = purchaseOrder.Id,
                CompanyName = purchaseOrder.CompanyName,
                Address = purchaseOrder.Address,
                PurchaseOrderNo = purchaseOrder.PurchaseOrderNo,
                VendorContactName = purchaseOrder.VendorContactName,
                VendorClientCompanyName = purchaseOrder.VendorClientCompanyName,
                VendorAddress = purchaseOrder.VendorAddress,
                VendorPhone = purchaseOrder.VendorPhone,
                ShipToName = purchaseOrder.ShipToName,
                ShipToClientCompanyName = purchaseOrder.ShipToClientCompanyName,
                ShipToAddress = purchaseOrder.ShipToAddress,
                ShipToPhone = purchaseOrder.ShipToPhone,
                Remarks = purchaseOrder.Remarks,
                Discount = purchaseOrder.Discount,
                TaxRate = purchaseOrder.TaxRate,
                ShippingFee = purchaseOrder.ShippingFee,
                Status = purchaseOrder.Status,
                CreatedOn = purchaseOrder.CreatedOn,
                CreatedBy = purchaseOrder.CreatedBy,
                ModifiedOn = purchaseOrder.ModifiedOn,
                ModifiedBy = purchaseOrder.ModifiedBy,
                PurchaseOrderProduct = purchaseOrder.PurchaseOrderProduct,
                PurchaseOrderShipping = purchaseOrder.PurchaseOrderShipping,
                Subtotal = subTotal,
                SubtotalLessDiscount = subTotalLessDiscount,
                TotalTax = totalTax,
                Total = total
            };

            return purchaseOrderDTO;
        }

        // PUT: api/PurchaseOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchaseOrder(long id, PurchaseOrder purchaseOrder)
        {
            if (id != purchaseOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(purchaseOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseOrderExists(id))
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

        // POST: api/PurchaseOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PurchaseOrder>> PostPurchaseOrder(PurchaseOrder purchaseOrder)
        {
            _context.PurchaseOrders.Add(purchaseOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPurchaseOrder), new { id = purchaseOrder.Id }, purchaseOrder);
        }

        // DELETE: api/PurchaseOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchaseOrder(long id)
        {
            var purchaseOrder = await _context.PurchaseOrders.FindAsync(id);
            if (purchaseOrder == null)
            {
                return NotFound();
            }

            _context.PurchaseOrders.Remove(purchaseOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PurchaseOrderExists(long id)
        {
            return _context.PurchaseOrders.Any(e => e.Id == id);
        }
    }
}
