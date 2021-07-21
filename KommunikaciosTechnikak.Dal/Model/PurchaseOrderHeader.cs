using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("PurchaseOrderHeader", Schema = "Purchasing")]
    [Index(nameof(EmployeeId), Name = "IX_PurchaseOrderHeader_EmployeeID")]
    [Index(nameof(VendorId), Name = "IX_PurchaseOrderHeader_VendorID")]
    public partial class PurchaseOrderHeader
    {
        public PurchaseOrderHeader()
        {
            PurchaseOrderDetails = new HashSet<PurchaseOrderDetail>();
        }

        [Key]
        [Column("PurchaseOrderID")]
        public int PurchaseOrderId { get; set; }
        public byte RevisionNumber { get; set; }
        public byte Status { get; set; }
        [Column("EmployeeID")]
        public int EmployeeId { get; set; }
        [Column("VendorID")]
        public int VendorId { get; set; }
        [Column("ShipMethodID")]
        public int ShipMethodId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime OrderDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ShipDate { get; set; }
        [Column(TypeName = "money")]
        public decimal SubTotal { get; set; }
        [Column(TypeName = "money")]
        public decimal TaxAmt { get; set; }
        [Column(TypeName = "money")]
        public decimal Freight { get; set; }
        [Column(TypeName = "money")]
        public decimal TotalDue { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty("PurchaseOrderHeaders")]
        public virtual Employee Employee { get; set; }
        [ForeignKey(nameof(ShipMethodId))]
        [InverseProperty("PurchaseOrderHeaders")]
        public virtual ShipMethod ShipMethod { get; set; }
        [ForeignKey(nameof(VendorId))]
        [InverseProperty("PurchaseOrderHeaders")]
        public virtual Vendor Vendor { get; set; }
        [InverseProperty(nameof(PurchaseOrderDetail.PurchaseOrder))]
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
    }
}
