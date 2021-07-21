using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("CountryRegion", Schema = "Person")]
    [Index(nameof(Name), Name = "AK_CountryRegion_Name", IsUnique = true)]
    public partial class CountryRegion
    {
        public CountryRegion()
        {
            CountryRegionCurrencies = new HashSet<CountryRegionCurrency>();
            SalesTerritories = new HashSet<SalesTerritory>();
            StateProvinces = new HashSet<StateProvince>();
        }

        [Key]
        [StringLength(3)]
        public string CountryRegionCode { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty(nameof(CountryRegionCurrency.CountryRegionCodeNavigation))]
        public virtual ICollection<CountryRegionCurrency> CountryRegionCurrencies { get; set; }
        [InverseProperty(nameof(SalesTerritory.CountryRegionCodeNavigation))]
        public virtual ICollection<SalesTerritory> SalesTerritories { get; set; }
        [InverseProperty(nameof(StateProvince.CountryRegionCodeNavigation))]
        public virtual ICollection<StateProvince> StateProvinces { get; set; }
    }
}
