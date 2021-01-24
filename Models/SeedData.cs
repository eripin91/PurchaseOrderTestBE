using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseOrderTestBE.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PurchaseOrderContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PurchaseOrderContext>>()))
            {
                #region Product
                // Look for any Products.
                if (!context.Products.Any())
                {
                    context.Products.AddRange(
                        new Product
                        {
                            Code = "112",
                            Name = "Scanner HX 123",
                            Description = "Scanner thermal dengan 3 lapis",
                            Qty = 180,
                            Price = 7000,
                            CreatedBy = "1x0wwk2",
                            CreatedOn = DateTime.UtcNow
                        },
                        new Product
                        {
                            Code = "113",
                            Name = "Printer HX 123",
                            Description = "Printer thermal dengan 3 lapis",
                            Qty = 100,
                            Price = 75000,
                            CreatedBy = "1x0wwk2",
                            CreatedOn = DateTime.UtcNow
                        },
                        new Product
                        {
                            Code = "114",
                            Name = "Barcode HX 123",
                            Description = "Barcode thermal dengan 3 lapis",
                            Qty = 190,
                            Price = 79000,
                            CreatedBy = "1x0wwk2",
                            CreatedOn = DateTime.UtcNow
                        },
                        new Product
                        {
                            Code = "115",
                            Name = "Speaker HX 123",
                            Description = "Speaker thermal dengan 3 lapis",
                            Qty = 500,
                            Price = 17000,
                            CreatedBy = "1x0wwk2",
                            CreatedOn = DateTime.UtcNow
                        }
                    );
                }

                
                #endregion

                #region Vendor
                // Look for any Vendors.
                if (!context.Vendors.Any())
                {
                    context.Vendors.AddRange(
                    new Vendor
                    {
                        Name = "Isabella Karim",
                        ClientCompanyName = "Printing unlimited, Inc",
                        Address = "55 Third Street",
                        Phone = "555-555",
                        CreatedBy = "1x0wwk2",
                        CreatedOn = DateTime.UtcNow
                    },
                    new Vendor
                    {
                        Name = "Rosita Karim",
                        ClientCompanyName = "Magazine unlimited, Inc",
                        Address = "66 Third Street",
                        Phone = "666-666",
                        CreatedBy = "1x0wwk2",
                        CreatedOn = DateTime.UtcNow
                    },
                    new Vendor
                    {
                        Name = "Serena Karim",
                        ClientCompanyName = "Gaming unlimited, Inc",
                        Address = "77 Third Street",
                        Phone = "777-777",
                        CreatedBy = "1x0wwk2",
                        CreatedOn = DateTime.UtcNow
                    },
                    new Vendor
                    {
                        Name = "Poa Karim",
                        ClientCompanyName = "Gas unlimited, Inc",
                        Address = "88 Third Street",
                        Phone = "888-888",
                        CreatedBy = "1x0wwk2",
                        CreatedOn = DateTime.UtcNow
                    }
                );
                }

                
                #endregion

                #region Client
                // Look for any Clients.
                if (!context.Clients.Any())
                {
                    context.Clients.AddRange(
                    new Client
                    {
                        Name = "Jolena Sincero",
                        ClientCompanyName = "XYZ Offices",
                        Address = "25 First Cambridge Street",
                        Phone = "444-444",
                        CreatedBy = "1x0wwk2",
                        CreatedOn = DateTime.UtcNow
                    },
                    new Client
                    {
                        Name = "Elizabeth Sincero",
                        ClientCompanyName = "BBBB Offices",
                        Address = "38 Second Cambridge Street",
                        Phone = "333-222",
                        CreatedBy = "1x0wwk2",
                        CreatedOn = DateTime.UtcNow
                    },
                    new Client
                    {
                        Name = "Lorita Sincero",
                        ClientCompanyName = "SSS Offices",
                        Address = "66 Third Cambridge Street",
                        Phone = "222-333",
                        CreatedBy = "1x0wwk2",
                        CreatedOn = DateTime.UtcNow
                    },
                    new Client
                    {
                        Name = "Rodrigeo Sincero",
                        ClientCompanyName = "LOW Offices",
                        Address = "335 Third Cambridge Street",
                        Phone = "111-111",
                        CreatedBy = "1x0wwk2",
                        CreatedOn = DateTime.UtcNow
                    }
                );
                }

                
                #endregion

                #region PurchaseOrder
                // Look for any PurchaseOrders.
                if (!context.PurchaseOrders.Any())
                {
                    context.PurchaseOrders.AddRange(
                    new PurchaseOrder
                    {
                        CompanyName = "XX Company",
                        Address = "XYZ street",
                        PurchaseOrderNo = "001/po/01/2021",
                        VendorContactName = "Rosita",
                        VendorClientCompanyName = "PT XBC",
                        VendorAddress = "899 Street Peak",
                        VendorPhone = "6695812",
                        ShipToName = "Lorena",
                        ShipToClientCompanyName = "PT BBVCS",
                        ShipToAddress = "09 Axe Street",
                        ShipToPhone = "981902",
                        Remarks = "Please forward to purchasing",
                        Discount = 5.50M,
                        TaxRate = 7.50M,
                        ShippingFee = 2000,
                        CreatedBy = "1x0wwk2",
                        CreatedOn = DateTime.UtcNow,
                        PurchaseOrderShipping = new List<PurchaseOrderShipping>()
                        {
                            new PurchaseOrderShipping
                            {
                                ShippingAgent = "UPS",
                                ShippingMethod = "UPS",
                                ShippingTerms = "UPS",
                                ShippingDeliveryDate = DateTime.UtcNow,
                                CreatedBy = "1x0wwk2",
                                CreatedOn = DateTime.UtcNow,
                            },
                            new PurchaseOrderShipping
                            {
                                ShippingAgent = "BB",
                                ShippingMethod = "DD",
                                ShippingTerms = "EE",
                                ShippingDeliveryDate = DateTime.UtcNow,
                                CreatedBy = "1x0wwk2",
                                CreatedOn = DateTime.UtcNow,
                            }
                        },
                        PurchaseOrderProduct = new List<PurchaseOrderProduct>()
                        {
                            new PurchaseOrderProduct
                            {
                                ProductCode = "332",
                                ProductName = "Laser x Beam",
                                Qty = 321,
                                Price = 123000,
                                ProductDeliveryDate = DateTime.UtcNow,
                                CreatedBy = "1x0wwk2",
                                CreatedOn = DateTime.UtcNow,
                            },
                            new PurchaseOrderProduct
                            {
                                ProductCode = "333",
                                ProductName = "Keyboard x Beam",
                                Qty = 121,
                                Price = 3000,
                                ProductDeliveryDate = DateTime.UtcNow,
                                CreatedBy = "1x0wwk2",
                                CreatedOn = DateTime.UtcNow,
                            }
                        }
                    },
                    new PurchaseOrder
                    {
                        CompanyName = "YY Company",
                        Address = "YSB street",
                        PurchaseOrderNo = "002/po/01/2021",
                        VendorContactName = "Sosita",
                        VendorClientCompanyName = "SXX XBC",
                        VendorAddress = "199 Street Peak",
                        VendorPhone = "65-895452",
                        ShipToName = "Lorena",
                        ShipToClientCompanyName = "PT BBVCS",
                        ShipToAddress = "09 Axe Street",
                        ShipToPhone = "981902",
                        Remarks = "Please forward to purchasing",
                        Discount = 5.50M,
                        TaxRate = 7.50M,
                        ShippingFee = 2000,
                        CreatedBy = "1x0wwk2",
                        CreatedOn = DateTime.UtcNow,
                        PurchaseOrderShipping = new List<PurchaseOrderShipping>()
                        {
                            new PurchaseOrderShipping
                            {
                                ShippingAgent = "UPS",
                                ShippingMethod = "UPS",
                                ShippingTerms = "UPS",
                                ShippingDeliveryDate = DateTime.UtcNow,
                                CreatedBy = "1x0wwk2",
                                CreatedOn = DateTime.UtcNow,
                            },
                            new PurchaseOrderShipping
                            {
                                ShippingAgent = "BB",
                                ShippingMethod = "DD",
                                ShippingTerms = "EE",
                                ShippingDeliveryDate = DateTime.UtcNow,
                                CreatedBy = "1x0wwk2",
                                CreatedOn = DateTime.UtcNow,
                            }
                        },
                        PurchaseOrderProduct = new List<PurchaseOrderProduct>()
                        {
                            new PurchaseOrderProduct
                            {
                                ProductCode = "338",
                                ProductName = "Watch x Beam",
                                Qty = 321,
                                Price = 123000,
                                ProductDeliveryDate = DateTime.UtcNow,
                                CreatedBy = "1x0wwk2",
                                CreatedOn = DateTime.UtcNow,
                            },
                            new PurchaseOrderProduct
                            {
                                ProductCode = "339",
                                ProductName = "Window x Beam",
                                Qty = 121,
                                Price = 3000,
                                ProductDeliveryDate = DateTime.UtcNow,
                                CreatedBy = "1x0wwk2",
                                CreatedOn = DateTime.UtcNow,
                            }
                        }
                    },
                    new PurchaseOrder
                    {
                        CompanyName = "GG Company",
                        Address = "GSB street",
                        PurchaseOrderNo = "003/po/01/2021",
                        VendorContactName = "Sosita",
                        VendorClientCompanyName = "SXX XBC",
                        VendorAddress = "399 Street Peak",
                        VendorPhone = "65-895452",
                        ShipToName = "Lorena",
                        ShipToClientCompanyName = "PT BBVCS",
                        ShipToAddress = "09 Axe Street",
                        ShipToPhone = "981902",
                        Remarks = "Please forward to purchasing",
                        Discount = 5.50M,
                        TaxRate = 7.50M,
                        ShippingFee = 2000,
                        CreatedBy = "1x0wwk2",
                        CreatedOn = DateTime.UtcNow,
                        PurchaseOrderShipping = new List<PurchaseOrderShipping>()
                        {
                            new PurchaseOrderShipping
                            {
                                ShippingAgent = "UPS",
                                ShippingMethod = "UPS",
                                ShippingTerms = "UPS",
                                ShippingDeliveryDate = DateTime.UtcNow,
                                CreatedBy = "1x0wwk2",
                                CreatedOn = DateTime.UtcNow,
                            },
                            new PurchaseOrderShipping
                            {
                                ShippingAgent = "BB",
                                ShippingMethod = "DD",
                                ShippingTerms = "EE",
                                ShippingDeliveryDate = DateTime.UtcNow,
                                CreatedBy = "1x0wwk2",
                                CreatedOn = DateTime.UtcNow,
                            }
                        },
                        PurchaseOrderProduct = new List<PurchaseOrderProduct>()
                        {
                            new PurchaseOrderProduct
                            {
                                ProductCode = "338",
                                ProductName = "Watch x Beam",
                                Qty = 321,
                                Price = 123000,
                                ProductDeliveryDate = DateTime.UtcNow,
                                CreatedBy = "1x0wwk2",
                                CreatedOn = DateTime.UtcNow,
                            },
                            new PurchaseOrderProduct
                            {
                                ProductCode = "339",
                                ProductName = "Window x Beam",
                                Qty = 121,
                                Price = 3000,
                                ProductDeliveryDate = DateTime.UtcNow,
                                CreatedBy = "1x0wwk2",
                                CreatedOn = DateTime.UtcNow,
                            }
                        }
                    },
                    new PurchaseOrder
                    {
                        CompanyName = "BBB Company",
                        Address = "DQQA street",
                        PurchaseOrderNo = "004/po/01/2021",
                        VendorContactName = "Sosita",
                        VendorClientCompanyName = "SXX XBC",
                        VendorAddress = "199 Street Peak",
                        VendorPhone = "65-895452",
                        ShipToName = "Lorena",
                        ShipToClientCompanyName = "PT BBVCS",
                        ShipToAddress = "09 Axe Street",
                        ShipToPhone = "981902",
                        Remarks = "Please forward to purchasing",
                        Discount = 5.50M,
                        TaxRate = 7.50M,
                        ShippingFee = 2000,
                        CreatedBy = "1x0wwk2",
                        CreatedOn = DateTime.UtcNow,
                        PurchaseOrderShipping = new List<PurchaseOrderShipping>()
                        {
                            new PurchaseOrderShipping
                            {
                                ShippingAgent = "UPS",
                                ShippingMethod = "UPS",
                                ShippingTerms = "UPS",
                                ShippingDeliveryDate = DateTime.UtcNow,
                                CreatedBy = "1x0wwk2",
                                CreatedOn = DateTime.UtcNow,
                            },
                            new PurchaseOrderShipping
                            {
                                ShippingAgent = "BB",
                                ShippingMethod = "DD",
                                ShippingTerms = "EE",
                                ShippingDeliveryDate = DateTime.UtcNow,
                                CreatedBy = "1x0wwk2",
                                CreatedOn = DateTime.UtcNow,
                            }
                        },
                        PurchaseOrderProduct = new List<PurchaseOrderProduct>()
                        {
                            new PurchaseOrderProduct
                            {
                                ProductCode = "338",
                                ProductName = "Watch x Beam",
                                Qty = 321,
                                Price = 123000,
                                ProductDeliveryDate = DateTime.UtcNow,
                                CreatedBy = "1x0wwk2",
                                CreatedOn = DateTime.UtcNow,
                            },
                            new PurchaseOrderProduct
                            {
                                ProductCode = "339",
                                ProductName = "Window x Beam",
                                Qty = 121,
                                Price = 3000,
                                ProductDeliveryDate = DateTime.UtcNow,
                                CreatedBy = "1x0wwk2",
                                CreatedOn = DateTime.UtcNow,
                            }
                        }
                    }
                );
                }


                #endregion

                #region User
                // Look for any Users.
                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User
                        {
                            FirstName = "Siska",
                            LastName = "Siregar",
                            Password = "test",
                            Username = "Siska"
                        },
                        new User { 
                            FirstName = "Test", 
                            LastName = "User", 
                            Username = "test", 
                            Password = "test" 
                        },
                        new User
                        {
                            FirstName = "Doni",
                            LastName = "Niagara",
                            Username = "Doni",
                            Password = "test"
                        },
                        new User
                        {
                            FirstName = "Reinar",
                            LastName = "Halim",
                            Username = "Reinar",
                            Password = "test"
                        }
                    );
                }

                #endregion

                context.SaveChanges();
            }
        }
    }
}
