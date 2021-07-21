using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("SalesTerritoryHistory", Schema = "Sales")]
    [Index(nameof(Rowguid), Name = "AK_SalesTerritoryHistory_rowguid", IsUnique = true)]
    public partial class SalesTerritoryHistory
    {
        [Key]
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        [Key]
        [Column("TerritoryID")]
        public int TerritoryId { get; set; }
        [Key]
        [Column(TypeName = "datetime")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndDate { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(BusinessEntityId))]
        [InverseProperty(nameof(SalesPerson.SalesTerritoryHistories))]
        public virtual SalesPerson BusinessEntity { get; set; }
        [ForeignKey(nameof(TerritoryId))]
        [InverseProperty(nameof(SalesTerritory.SalesTerritoryHistories))]
        public virtual SalesTerritory Territory { get; set; }
    }
}
