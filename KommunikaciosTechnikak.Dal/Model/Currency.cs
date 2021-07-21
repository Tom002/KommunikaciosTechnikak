using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("Currency", Schema = "Sales")]
    [Index(nameof(Name), Name = "AK_Currency_Name", IsUnique = true)]
    public partial class Currency
    {
        public Currency()
        {
            CountryRegionCurrencies = new HashSet<CountryRegionCurrency>();
            CurrencyRateFromCurrencyCodeNavigations = new HashSet<CurrencyRate>();
            CurrencyRateToCurrencyCodeNavigations = new HashSet<CurrencyRate>();
        }

        [Key]
        [StringLength(3)]
        public string CurrencyCode { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty(nameof(CountryRegionCurrency.CurrencyCodeNavigation))]
        public virtual ICollection<CountryRegionCurrency> CountryRegionCurrencies { get; set; }
        [InverseProperty(nameof(CurrencyRate.FromCurrencyCodeNavigation))]
        public virtual ICollection<CurrencyRate> CurrencyRateFromCurrencyCodeNavigations { get; set; }
        [InverseProperty(nameof(CurrencyRate.ToCurrencyCodeNavigation))]
        public virtual ICollection<CurrencyRate> CurrencyRateToCurrencyCodeNavigations { get; set; }
    }
}
