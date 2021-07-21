using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("Person", Schema = "Person")]
    [Index(nameof(Rowguid), Name = "AK_Person_rowguid", IsUnique = true)]
    [Index(nameof(LastName), nameof(FirstName), nameof(MiddleName), Name = "IX_Person_LastName_FirstName_MiddleName")]
    [Index(nameof(AdditionalContactInfo), Name = "PXML_Person_AddContact")]
    [Index(nameof(Demographics), Name = "PXML_Person_Demographics")]
    [Index(nameof(Demographics), Name = "XMLPATH_Person_Demographics")]
    [Index(nameof(Demographics), Name = "XMLPROPERTY_Person_Demographics")]
    [Index(nameof(Demographics), Name = "XMLVALUE_Person_Demographics")]
    public partial class Person
    {
        public Person()
        {
            BusinessEntityContacts = new HashSet<BusinessEntityContact>();
            Customers = new HashSet<Customer>();
            EmailAddresses = new HashSet<EmailAddress>();
            PersonCreditCards = new HashSet<PersonCreditCard>();
            PersonPhones = new HashSet<PersonPhone>();
        }

        [Key]
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        [Required]
        [StringLength(2)]
        public string PersonType { get; set; }
        public bool NameStyle { get; set; }
        [StringLength(8)]
        public string Title { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(10)]
        public string Suffix { get; set; }
        public int EmailPromotion { get; set; }
        [Column(TypeName = "xml")]
        public string AdditionalContactInfo { get; set; }
        [Column(TypeName = "xml")]
        public string Demographics { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(BusinessEntityId))]
        [InverseProperty("Person")]
        public virtual BusinessEntity BusinessEntity { get; set; }
        [InverseProperty("BusinessEntity")]
        public virtual Employee Employee { get; set; }
        [InverseProperty("BusinessEntity")]
        public virtual Password Password { get; set; }
        [InverseProperty(nameof(BusinessEntityContact.Person))]
        public virtual ICollection<BusinessEntityContact> BusinessEntityContacts { get; set; }
        [InverseProperty(nameof(Customer.Person))]
        public virtual ICollection<Customer> Customers { get; set; }
        [InverseProperty(nameof(EmailAddress.BusinessEntity))]
        public virtual ICollection<EmailAddress> EmailAddresses { get; set; }
        [InverseProperty(nameof(PersonCreditCard.BusinessEntity))]
        public virtual ICollection<PersonCreditCard> PersonCreditCards { get; set; }
        [InverseProperty(nameof(PersonPhone.BusinessEntity))]
        public virtual ICollection<PersonPhone> PersonPhones { get; set; }
    }
}
