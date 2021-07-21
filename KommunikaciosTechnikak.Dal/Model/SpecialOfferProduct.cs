using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("SpecialOfferProduct", Schema = "Sales")]
    [Index(nameof(Rowguid), Name = "AK_SpecialOfferProduct_rowguid", IsUnique = true)]
    [Index(nameof(ProductId), Name = "IX_SpecialOfferProduct_ProductID")]
    public partial class SpecialOfferProduct
    {
        public SpecialOfferProduct()
        {
            SalesOrderDetails = new HashSet<SalesOrderDetail>();
        }

        [Key]
        [Column("SpecialOfferID")]
        public int SpecialOfferId { get; set; }
        [Key]
        [Column("ProductID")]
        public int ProductId { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(ProductId))]
        [InverseProperty("SpecialOfferProducts")]
        public virtual Product Product { get; set; }
        [ForeignKey(nameof(SpecialOfferId))]
        [InverseProperty("SpecialOfferProducts")]
        public virtual SpecialOffer SpecialOffer { get; set; }
        [InverseProperty(nameof(SalesOrderDetail.SpecialOfferProduct))]
        public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; }
    }
}
