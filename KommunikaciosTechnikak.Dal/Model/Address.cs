using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("Address", Schema = "Person")]
    [Index(nameof(Rowguid), Name = "AK_Address_rowguid", IsUnique = true)]
    [Index(nameof(AddressLine1), nameof(AddressLine2), nameof(City), nameof(StateProvinceId), nameof(PostalCode), Name = "IX_Address_AddressLine1_AddressLine2_City_StateProvinceID_PostalCode", IsUnique = true)]
    [Index(nameof(StateProvinceId), Name = "IX_Address_StateProvinceID")]
    public partial class Address
    {
        public Address()
        {
            BusinessEntityAddresses = new HashSet<BusinessEntityAddress>();
            SalesOrderHeaderBillToAddresses = new HashSet<SalesOrderHeader>();
            SalesOrderHeaderShipToAddresses = new HashSet<SalesOrderHeader>();
        }

        [Key]
        [Column("AddressID")]
        public int AddressId { get; set; }
        [Required]
        [StringLength(60)]
        public string AddressLine1 { get; set; }
        [StringLength(60)]
        public string AddressLine2 { get; set; }
        [Required]
        [StringLength(30)]
        public string City { get; set; }
        [Column("StateProvinceID")]
        public int StateProvinceId { get; set; }
        [Required]
        [StringLength(15)]
        public string PostalCode { get; set; }
        public Geometry SpatialLocation { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(StateProvinceId))]
        [InverseProperty("Addresses")]
        public virtual StateProvince StateProvince { get; set; }
        [InverseProperty(nameof(BusinessEntityAddress.Address))]
        public virtual ICollection<BusinessEntityAddress> BusinessEntityAddresses { get; set; }
        [InverseProperty(nameof(SalesOrderHeader.BillToAddress))]
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaderBillToAddresses { get; set; }
        [InverseProperty(nameof(SalesOrderHeader.ShipToAddress))]
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaderShipToAddresses { get; set; }
    }
}
