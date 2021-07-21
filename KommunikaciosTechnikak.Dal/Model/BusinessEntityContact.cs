using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("BusinessEntityContact", Schema = "Person")]
    [Index(nameof(Rowguid), Name = "AK_BusinessEntityContact_rowguid", IsUnique = true)]
    [Index(nameof(ContactTypeId), Name = "IX_BusinessEntityContact_ContactTypeID")]
    [Index(nameof(PersonId), Name = "IX_BusinessEntityContact_PersonID")]
    public partial class BusinessEntityContact
    {
        [Key]
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        [Key]
        [Column("PersonID")]
        public int PersonId { get; set; }
        [Key]
        [Column("ContactTypeID")]
        public int ContactTypeId { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(BusinessEntityId))]
        [InverseProperty("BusinessEntityContacts")]
        public virtual BusinessEntity BusinessEntity { get; set; }
        [ForeignKey(nameof(ContactTypeId))]
        [InverseProperty("BusinessEntityContacts")]
        public virtual ContactType ContactType { get; set; }
        [ForeignKey(nameof(PersonId))]
        [InverseProperty("BusinessEntityContacts")]
        public virtual Person Person { get; set; }
    }
}
