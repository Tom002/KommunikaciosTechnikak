using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("BusinessEntityAddress", Schema = "Person")]
    [Index(nameof(Rowguid), Name = "AK_BusinessEntityAddress_rowguid", IsUnique = true)]
    [Index(nameof(AddressId), Name = "IX_BusinessEntityAddress_AddressID")]
    [Index(nameof(AddressTypeId), Name = "IX_BusinessEntityAddress_AddressTypeID")]
    public partial class BusinessEntityAddress
    {
        [Key]
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        [Key]
        [Column("AddressID")]
        public int AddressId { get; set; }
        [Key]
        [Column("AddressTypeID")]
        public int AddressTypeId { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(AddressId))]
        [InverseProperty("BusinessEntityAddresses")]
        public virtual Address Address { get; set; }
        [ForeignKey(nameof(AddressTypeId))]
        [InverseProperty("BusinessEntityAddresses")]
        public virtual AddressType AddressType { get; set; }
        [ForeignKey(nameof(BusinessEntityId))]
        [InverseProperty("BusinessEntityAddresses")]
        public virtual BusinessEntity BusinessEntity { get; set; }
    }
}
