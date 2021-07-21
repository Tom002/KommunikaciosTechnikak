using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("Vendor", Schema = "Purchasing")]
    [Index(nameof(AccountNumber), Name = "AK_Vendor_AccountNumber", IsUnique = true)]
    public partial class Vendor
    {
        public Vendor()
        {
            ProductVendors = new HashSet<ProductVendor>();
            PurchaseOrderHeaders = new HashSet<PurchaseOrderHeader>();
        }

        [Key]
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        [Required]
        [StringLength(15)]
        public string AccountNumber { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public byte CreditRating { get; set; }
        [Required]
        public bool? PreferredVendorStatus { get; set; }
        [Required]
        public bool? ActiveFlag { get; set; }
        [Column("PurchasingWebServiceURL")]
        [StringLength(1024)]
        public string PurchasingWebServiceUrl { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(BusinessEntityId))]
        [InverseProperty("Vendor")]
        public virtual BusinessEntity BusinessEntity { get; set; }
        [InverseProperty(nameof(ProductVendor.BusinessEntity))]
        public virtual ICollection<ProductVendor> ProductVendors { get; set; }
        [InverseProperty(nameof(PurchaseOrderHeader.Vendor))]
        public virtual ICollection<PurchaseOrderHeader> PurchaseOrderHeaders { get; set; }
    }
}
