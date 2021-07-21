using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("SalesPerson", Schema = "Sales")]
    [Index(nameof(Rowguid), Name = "AK_SalesPerson_rowguid", IsUnique = true)]
    public partial class SalesPerson
    {
        public SalesPerson()
        {
            SalesOrderHeaders = new HashSet<SalesOrderHeader>();
            SalesPersonQuotaHistories = new HashSet<SalesPersonQuotaHistory>();
            SalesTerritoryHistories = new HashSet<SalesTerritoryHistory>();
            Stores = new HashSet<Store>();
        }

        [Key]
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        [Column("TerritoryID")]
        public int? TerritoryId { get; set; }
        [Column(TypeName = "money")]
        public decimal? SalesQuota { get; set; }
        [Column(TypeName = "money")]
        public decimal Bonus { get; set; }
        [Column(TypeName = "smallmoney")]
        public decimal CommissionPct { get; set; }
        [Column("SalesYTD", TypeName = "money")]
        public decimal SalesYtd { get; set; }
        [Column(TypeName = "money")]
        public decimal SalesLastYear { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(BusinessEntityId))]
        [InverseProperty(nameof(Employee.SalesPerson))]
        public virtual Employee BusinessEntity { get; set; }
        [ForeignKey(nameof(TerritoryId))]
        [InverseProperty(nameof(SalesTerritory.SalesPeople))]
        public virtual SalesTerritory Territory { get; set; }
        [InverseProperty(nameof(SalesOrderHeader.SalesPerson))]
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; }
        [InverseProperty(nameof(SalesPersonQuotaHistory.BusinessEntity))]
        public virtual ICollection<SalesPersonQuotaHistory> SalesPersonQuotaHistories { get; set; }
        [InverseProperty(nameof(SalesTerritoryHistory.BusinessEntity))]
        public virtual ICollection<SalesTerritoryHistory> SalesTerritoryHistories { get; set; }
        [InverseProperty(nameof(Store.SalesPerson))]
        public virtual ICollection<Store> Stores { get; set; }
    }
}
