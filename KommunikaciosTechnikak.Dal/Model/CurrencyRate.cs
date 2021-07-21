using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("CurrencyRate", Schema = "Sales")]
    [Index(nameof(CurrencyRateDate), nameof(FromCurrencyCode), nameof(ToCurrencyCode), Name = "AK_CurrencyRate_CurrencyRateDate_FromCurrencyCode_ToCurrencyCode", IsUnique = true)]
    public partial class CurrencyRate
    {
        public CurrencyRate()
        {
            SalesOrderHeaders = new HashSet<SalesOrderHeader>();
        }

        [Key]
        [Column("CurrencyRateID")]
        public int CurrencyRateId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CurrencyRateDate { get; set; }
        [Required]
        [StringLength(3)]
        public string FromCurrencyCode { get; set; }
        [Required]
        [StringLength(3)]
        public string ToCurrencyCode { get; set; }
        [Column(TypeName = "money")]
        public decimal AverageRate { get; set; }
        [Column(TypeName = "money")]
        public decimal EndOfDayRate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(FromCurrencyCode))]
        [InverseProperty(nameof(Currency.CurrencyRateFromCurrencyCodeNavigations))]
        public virtual Currency FromCurrencyCodeNavigation { get; set; }
        [ForeignKey(nameof(ToCurrencyCode))]
        [InverseProperty(nameof(Currency.CurrencyRateToCurrencyCodeNavigations))]
        public virtual Currency ToCurrencyCodeNavigation { get; set; }
        [InverseProperty(nameof(SalesOrderHeader.CurrencyRate))]
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; }
    }
}
