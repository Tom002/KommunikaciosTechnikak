using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("SalesOrderHeader", Schema = "Sales")]
    [Index(nameof(SalesOrderNumber), Name = "AK_SalesOrderHeader_SalesOrderNumber", IsUnique = true)]
    [Index(nameof(Rowguid), Name = "AK_SalesOrderHeader_rowguid", IsUnique = true)]
    [Index(nameof(CustomerId), Name = "IX_SalesOrderHeader_CustomerID")]
    [Index(nameof(SalesPersonId), Name = "IX_SalesOrderHeader_SalesPersonID")]
    public partial class SalesOrderHeader
    {
        public SalesOrderHeader()
        {
            SalesOrderDetails = new HashSet<SalesOrderDetail>();
            SalesOrderHeaderSalesReasons = new HashSet<SalesOrderHeaderSalesReason>();
        }

        [Key]
        [Column("SalesOrderID")]
        public int SalesOrderId { get; set; }
        public byte RevisionNumber { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime OrderDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DueDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ShipDate { get; set; }
        public byte Status { get; set; }
        [Required]
        public bool? OnlineOrderFlag { get; set; }
        [Required]
        [StringLength(25)]
        public string SalesOrderNumber { get; set; }
        [StringLength(25)]
        public string PurchaseOrderNumber { get; set; }
        [StringLength(15)]
        public string AccountNumber { get; set; }
        [Column("CustomerID")]
        public int CustomerId { get; set; }
        [Column("SalesPersonID")]
        public int? SalesPersonId { get; set; }
        [Column("TerritoryID")]
        public int? TerritoryId { get; set; }
        [Column("BillToAddressID")]
        public int BillToAddressId { get; set; }
        [Column("ShipToAddressID")]
        public int ShipToAddressId { get; set; }
        [Column("ShipMethodID")]
        public int ShipMethodId { get; set; }
        [Column("CreditCardID")]
        public int? CreditCardId { get; set; }
        [StringLength(15)]
        public string CreditCardApprovalCode { get; set; }
        [Column("CurrencyRateID")]
        public int? CurrencyRateId { get; set; }
        [Column(TypeName = "money")]
        public decimal SubTotal { get; set; }
        [Column(TypeName = "money")]
        public decimal TaxAmt { get; set; }
        [Column(TypeName = "money")]
        public decimal Freight { get; set; }
        [Column(TypeName = "money")]
        public decimal TotalDue { get; set; }
        [StringLength(128)]
        public string Comment { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(BillToAddressId))]
        [InverseProperty(nameof(Address.SalesOrderHeaderBillToAddresses))]
        public virtual Address BillToAddress { get; set; }
        [ForeignKey(nameof(CreditCardId))]
        [InverseProperty("SalesOrderHeaders")]
        public virtual CreditCard CreditCard { get; set; }
        [ForeignKey(nameof(CurrencyRateId))]
        [InverseProperty("SalesOrderHeaders")]
        public virtual CurrencyRate CurrencyRate { get; set; }
        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("SalesOrderHeaders")]
        public virtual Customer Customer { get; set; }
        [ForeignKey(nameof(SalesPersonId))]
        [InverseProperty("SalesOrderHeaders")]
        public virtual SalesPerson SalesPerson { get; set; }
        [ForeignKey(nameof(ShipMethodId))]
        [InverseProperty("SalesOrderHeaders")]
        public virtual ShipMethod ShipMethod { get; set; }
        [ForeignKey(nameof(ShipToAddressId))]
        [InverseProperty(nameof(Address.SalesOrderHeaderShipToAddresses))]
        public virtual Address ShipToAddress { get; set; }
        [ForeignKey(nameof(TerritoryId))]
        [InverseProperty(nameof(SalesTerritory.SalesOrderHeaders))]
        public virtual SalesTerritory Territory { get; set; }
        [InverseProperty(nameof(SalesOrderDetail.SalesOrder))]
        public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; }
        [InverseProperty(nameof(SalesOrderHeaderSalesReason.SalesOrder))]
        public virtual ICollection<SalesOrderHeaderSalesReason> SalesOrderHeaderSalesReasons { get; set; }
    }
}
