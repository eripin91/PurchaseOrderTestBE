using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PurchaseOrderTestBE.Models;

namespace PurchaseOrderTestBE.Models
{
    public class PurchaseOrderContext : DbContext
    {
        public PurchaseOrderContext(DbContextOptions<PurchaseOrderContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Client> Clients { get; set; }

        public DbSet<PurchaseOrderShipping> PurchaseOrderShippings { get; set; }

        public DbSet<PurchaseOrderProduct> PurchaseOrderProducts { get; set; }

        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
