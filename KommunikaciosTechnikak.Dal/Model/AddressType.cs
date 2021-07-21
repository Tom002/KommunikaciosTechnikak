using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("AddressType", Schema = "Person")]
    [Index(nameof(Name), Name = "AK_AddressType_Name", IsUnique = true)]
    [Index(nameof(Rowguid), Name = "AK_AddressType_rowguid", IsUnique = true)]
    public partial class AddressType
    {
        public AddressType()
        {
            BusinessEntityAddresses = new HashSet<BusinessEntityAddress>();
        }

        [Key]
        [Column("AddressTypeID")]
        public int AddressTypeId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty(nameof(BusinessEntityAddress.AddressType))]
        public virtual ICollection<BusinessEntityAddress> BusinessEntityAddresses { get; set; }
    }
}
