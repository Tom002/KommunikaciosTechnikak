using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("Customer", Schema = "Sales")]
    [Index(nameof(AccountNumber), Name = "AK_Customer_AccountNumber", IsUnique = true)]
    [Index(nameof(Rowguid), Name = "AK_Customer_rowguid", IsUnique = true)]
    [Index(nameof(TerritoryId), Name = "IX_Customer_TerritoryID")]
    public partial class Customer
    {
        public Customer()
        {
            SalesOrderHeaders = new HashSet<SalesOrderHeader>();
        }

        [Key]
        [Column("CustomerID")]
        public int CustomerId { get; set; }
        [Column("PersonID")]
        public int? PersonId { get; set; }
        [Column("StoreID")]
        public int? StoreId { get; set; }
        [Column("TerritoryID")]
        public int? TerritoryId { get; set; }
        [Required]
        [StringLength(10)]
        public string AccountNumber { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(PersonId))]
        [InverseProperty("Customers")]
        public virtual Person Person { get; set; }
        [ForeignKey(nameof(StoreId))]
        [InverseProperty("Customers")]
        public virtual Store Store { get; set; }
        [ForeignKey(nameof(TerritoryId))]
        [InverseProperty(nameof(SalesTerritory.Customers))]
        public virtual SalesTerritory Territory { get; set; }
        [InverseProperty(nameof(SalesOrderHeader.Customer))]
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; }
    }
}
