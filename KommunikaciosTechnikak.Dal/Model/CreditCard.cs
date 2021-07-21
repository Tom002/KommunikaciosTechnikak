using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("CreditCard", Schema = "Sales")]
    [Index(nameof(CardNumber), Name = "AK_CreditCard_CardNumber", IsUnique = true)]
    public partial class CreditCard
    {
        public CreditCard()
        {
            PersonCreditCards = new HashSet<PersonCreditCard>();
            SalesOrderHeaders = new HashSet<SalesOrderHeader>();
        }

        [Key]
        [Column("CreditCardID")]
        public int CreditCardId { get; set; }
        [Required]
        [StringLength(50)]
        public string CardType { get; set; }
        [Required]
        [StringLength(25)]
        public string CardNumber { get; set; }
        public byte ExpMonth { get; set; }
        public short ExpYear { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty(nameof(PersonCreditCard.CreditCard))]
        public virtual ICollection<PersonCreditCard> PersonCreditCards { get; set; }
        [InverseProperty(nameof(SalesOrderHeader.CreditCard))]
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; }
    }
}
