using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseOrderTestBE.Models
{
    public class PurchaseOrder
    {
        [Key]
        public long Id { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string PurchaseOrderNo { get; set; }
        public string VendorContactName { get; set; }
        public string VendorClientCompanyName { get; set; }
        public string VendorAddress { get; set; }
        public string VendorPhone { get; set; }
        public string ShipToName { get; set; }
        public string ShipToClientCompanyName { get; set; }
        public string ShipToAddress { get; set; }
        public string ShipToPhone { get; set; }
        public string Remarks { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Discount { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TaxRate { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal ShippingFee { get; set; }
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public List<PurchaseOrderProduct> PurchaseOrderProduct { get; set; } = new List<PurchaseOrderProduct>();
        public List<PurchaseOrderShipping> PurchaseOrderShipping { get; set; } = new List<PurchaseOrderShipping>();

    }
}
