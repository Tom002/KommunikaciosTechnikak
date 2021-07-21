using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("Store", Schema = "Sales")]
    [Index(nameof(Rowguid), Name = "AK_Store_rowguid", IsUnique = true)]
    [Index(nameof(SalesPersonId), Name = "IX_Store_SalesPersonID")]
    [Index(nameof(Demographics), Name = "PXML_Store_Demographics")]
    public partial class Store
    {
        public Store()
        {
            Customers = new HashSet<Customer>();
        }

        [Key]
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("SalesPersonID")]
        public int? SalesPersonId { get; set; }
        [Column(TypeName = "xml")]
        public string Demographics { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(BusinessEntityId))]
        [InverseProperty("Store")]
        public virtual BusinessEntity BusinessEntity { get; set; }
        [ForeignKey(nameof(SalesPersonId))]
        [InverseProperty("Stores")]
        public virtual SalesPerson SalesPerson { get; set; }
        [InverseProperty(nameof(Customer.Store))]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
