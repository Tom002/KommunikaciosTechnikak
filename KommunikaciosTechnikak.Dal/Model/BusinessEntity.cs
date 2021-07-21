using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("BusinessEntity", Schema = "Person")]
    [Index(nameof(Rowguid), Name = "AK_BusinessEntity_rowguid", IsUnique = true)]
    public partial class BusinessEntity
    {
        public BusinessEntity()
        {
            BusinessEntityAddresses = new HashSet<BusinessEntityAddress>();
            BusinessEntityContacts = new HashSet<BusinessEntityContact>();
        }

        [Key]
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty("BusinessEntity")]
        public virtual Person Person { get; set; }
        [InverseProperty("BusinessEntity")]
        public virtual Store Store { get; set; }
        [InverseProperty("BusinessEntity")]
        public virtual Vendor Vendor { get; set; }
        [InverseProperty(nameof(BusinessEntityAddress.BusinessEntity))]
        public virtual ICollection<BusinessEntityAddress> BusinessEntityAddresses { get; set; }
        [InverseProperty(nameof(BusinessEntityContact.BusinessEntity))]
        public virtual ICollection<BusinessEntityContact> BusinessEntityContacts { get; set; }
    }
}
