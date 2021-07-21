using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("ShipMethod", Schema = "Purchasing")]
    [Index(nameof(Name), Name = "AK_ShipMethod_Name", IsUnique = true)]
    [Index(nameof(Rowguid), Name = "AK_ShipMethod_rowguid", IsUnique = true)]
    public partial class ShipMethod
    {
        public ShipMethod()
        {
            PurchaseOrderHeaders = new HashSet<PurchaseOrderHeader>();
            SalesOrderHeaders = new HashSet<SalesOrderHeader>();
        }

        [Key]
        [Column("ShipMethodID")]
        public int ShipMethodId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "money")]
        public decimal ShipBase { get; set; }
        [Column(TypeName = "money")]
        public decimal ShipRate { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty(nameof(PurchaseOrderHeader.ShipMethod))]
        public virtual ICollection<PurchaseOrderHeader> PurchaseOrderHeaders { get; set; }
        [InverseProperty(nameof(SalesOrderHeader.ShipMethod))]
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; }
    }
}
