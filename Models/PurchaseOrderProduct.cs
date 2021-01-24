using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseOrderTestBE.Models
{
    public class PurchaseOrderProduct
    {
        [Key]
        public long Id { get; set; }
        public long PurchaseOrderId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int Qty { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public DateTime? ProductDeliveryDate { get; set; }
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}
