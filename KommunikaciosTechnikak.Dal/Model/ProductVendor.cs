using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("ProductVendor", Schema = "Purchasing")]
    [Index(nameof(BusinessEntityId), Name = "IX_ProductVendor_BusinessEntityID")]
    [Index(nameof(UnitMeasureCode), Name = "IX_ProductVendor_UnitMeasureCode")]
    public partial class ProductVendor
    {
        [Key]
        [Column("ProductID")]
        public int ProductId { get; set; }
        [Key]
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        public int AverageLeadTime { get; set; }
        [Column(TypeName = "money")]
        public decimal StandardPrice { get; set; }
        [Column(TypeName = "money")]
        public decimal? LastReceiptCost { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastReceiptDate { get; set; }
        public int MinOrderQty { get; set; }
        public int MaxOrderQty { get; set; }
        public int? OnOrderQty { get; set; }
        [Required]
        [StringLength(3)]
        public string UnitMeasureCode { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(BusinessEntityId))]
        [InverseProperty(nameof(Vendor.ProductVendors))]
        public virtual Vendor BusinessEntity { get; set; }
        [ForeignKey(nameof(ProductId))]
        [InverseProperty("ProductVendors")]
        public virtual Product Product { get; set; }
        [ForeignKey(nameof(UnitMeasureCode))]
        [InverseProperty(nameof(UnitMeasure.ProductVendors))]
        public virtual UnitMeasure UnitMeasureCodeNavigation { get; set; }
    }
}
