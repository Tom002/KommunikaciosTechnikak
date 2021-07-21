using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("SalesTerritory", Schema = "Sales")]
    [Index(nameof(Name), Name = "AK_SalesTerritory_Name", IsUnique = true)]
    [Index(nameof(Rowguid), Name = "AK_SalesTerritory_rowguid", IsUnique = true)]
    public partial class SalesTerritory
    {
        public SalesTerritory()
        {
            Customers = new HashSet<Customer>();
            SalesOrderHeaders = new HashSet<SalesOrderHeader>();
            SalesPeople = new HashSet<SalesPerson>();
            SalesTerritoryHistories = new HashSet<SalesTerritoryHistory>();
            StateProvinces = new HashSet<StateProvince>();
        }

        [Key]
        [Column("TerritoryID")]
        public int TerritoryId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(3)]
        public string CountryRegionCode { get; set; }
        [Required]
        [StringLength(50)]
        public string Group { get; set; }
        [Column("SalesYTD", TypeName = "money")]
        public decimal SalesYtd { get; set; }
        [Column(TypeName = "money")]
        public decimal SalesLastYear { get; set; }
        [Column("CostYTD", TypeName = "money")]
        public decimal CostYtd { get; set; }
        [Column(TypeName = "money")]
        public decimal CostLastYear { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(CountryRegionCode))]
        [InverseProperty(nameof(CountryRegion.SalesTerritories))]
        public virtual CountryRegion CountryRegionCodeNavigation { get; set; }
        [InverseProperty(nameof(Customer.Territory))]
        public virtual ICollection<Customer> Customers { get; set; }
        [InverseProperty(nameof(SalesOrderHeader.Territory))]
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; }
        [InverseProperty(nameof(SalesPerson.Territory))]
        public virtual ICollection<SalesPerson> SalesPeople { get; set; }
        [InverseProperty(nameof(SalesTerritoryHistory.Territory))]
        public virtual ICollection<SalesTerritoryHistory> SalesTerritoryHistories { get; set; }
        [InverseProperty(nameof(StateProvince.Territory))]
        public virtual ICollection<StateProvince> StateProvinces { get; set; }
    }
}
