using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("EmailAddress", Schema = "Person")]
    [Index(nameof(EmailAddress1), Name = "IX_EmailAddress_EmailAddress")]
    public partial class EmailAddress
    {
        [Key]
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        [Key]
        [Column("EmailAddressID")]
        public int EmailAddressId { get; set; }
        [Column("EmailAddress")]
        [StringLength(50)]
        public string EmailAddress1 { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(BusinessEntityId))]
        [InverseProperty(nameof(Person.EmailAddresses))]
        public virtual Person BusinessEntity { get; set; }
    }
}
