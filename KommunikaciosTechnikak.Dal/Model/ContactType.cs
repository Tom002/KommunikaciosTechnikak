using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("ContactType", Schema = "Person")]
    [Index(nameof(Name), Name = "AK_ContactType_Name", IsUnique = true)]
    public partial class ContactType
    {
        public ContactType()
        {
            BusinessEntityContacts = new HashSet<BusinessEntityContact>();
        }

        [Key]
        [Column("ContactTypeID")]
        public int ContactTypeId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty(nameof(BusinessEntityContact.ContactType))]
        public virtual ICollection<BusinessEntityContact> BusinessEntityContacts { get; set; }
    }
}
