using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("StateProvince", Schema = "Person")]
    [Index(nameof(Name), Name = "AK_StateProvince_Name", IsUnique = true)]
    [Index(nameof(StateProvinceCode), nameof(CountryRegionCode), Name = "AK_StateProvince_StateProvinceCode_CountryRegionCode", IsUnique = true)]
    [Index(nameof(Rowguid), Name = "AK_StateProvince_rowguid", IsUnique = true)]
    public partial class StateProvince
    {
        public StateProvince()
        {
            Addresses = new HashSet<Address>();
            SalesTaxRates = new HashSet<SalesTaxRate>();
        }

        [Key]
        [Column("StateProvinceID")]
        public int StateProvinceId { get; set; }
        [Required]
        [StringLength(3)]
        public string StateProvinceCode { get; set; }
        [Required]
        [StringLength(3)]
        public string CountryRegionCode { get; set; }
        [Required]
        public bool? IsOnlyStateProvinceFlag { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("TerritoryID")]
        public int TerritoryId { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(CountryRegionCode))]
        [InverseProperty(nameof(CountryRegion.StateProvinces))]
        public virtual CountryRegion CountryRegionCodeNavigation { get; set; }
        [ForeignKey(nameof(TerritoryId))]
        [InverseProperty(nameof(SalesTerritory.StateProvinces))]
        public virtual SalesTerritory Territory { get; set; }
        [InverseProperty(nameof(Address.StateProvince))]
        public virtual ICollection<Address> Addresses { get; set; }
        [InverseProperty(nameof(SalesTaxRate.StateProvince))]
        public virtual ICollection<SalesTaxRate> SalesTaxRates { get; set; }
    }
}
