using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("SalesPersonQuotaHistory", Schema = "Sales")]
    [Index(nameof(Rowguid), Name = "AK_SalesPersonQuotaHistory_rowguid", IsUnique = true)]
    public partial class SalesPersonQuotaHistory
    {
        [Key]
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        [Key]
        [Column(TypeName = "datetime")]
        public DateTime QuotaDate { get; set; }
        [Column(TypeName = "money")]
        public decimal SalesQuota { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(BusinessEntityId))]
        [InverseProperty(nameof(SalesPerson.SalesPersonQuotaHistories))]
        public virtual SalesPerson BusinessEntity { get; set; }
    }
}
