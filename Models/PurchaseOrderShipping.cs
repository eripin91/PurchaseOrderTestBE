using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseOrderTestBE.Models
{
    public class PurchaseOrderShipping
    {
        [Key]
        public long Id { get; set; }
        public long PurchaseOrderId { get; set; }
        public string ShippingAgent { get; set; }
        public string ShippingMethod { get; set; }
        public string ShippingTerms { get; set; }
        public DateTime? ShippingDeliveryDate { get; set; }
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}
