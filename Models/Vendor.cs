using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseOrderTestBE.Models
{
    public class Vendor
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string ClientCompanyName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}
