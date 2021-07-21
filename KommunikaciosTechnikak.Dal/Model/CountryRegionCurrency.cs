using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("CountryRegionCurrency", Schema = "Sales")]
    [Index(nameof(CurrencyCode), Name = "IX_CountryRegionCurrency_CurrencyCode")]
    public partial class CountryRegionCurrency
    {
        [Key]
        [StringLength(3)]
        public string CountryRegionCode { get; set; }
        [Key]
        [StringLength(3)]
        public string CurrencyCode { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(CountryRegionCode))]
        [InverseProperty(nameof(CountryRegion.CountryRegionCurrencies))]
        public virtual CountryRegion CountryRegionCodeNavigation { get; set; }
        [ForeignKey(nameof(CurrencyCode))]
        [InverseProperty(nameof(Currency.CountryRegionCurrencies))]
        public virtual Currency CurrencyCodeNavigation { get; set; }
    }
}
