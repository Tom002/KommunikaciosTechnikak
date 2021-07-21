using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KommunikaciosTechnikak.Dal.Model
{
    [Table("ProductPhoto", Schema = "Production")]
    public partial class ProductPhoto
    {
        public ProductPhoto()
        {
            ProductProductPhotos = new HashSet<ProductProductPhoto>();
        }

        [Key]
        [Column("ProductPhotoID")]
        public int ProductPhotoId { get; set; }
        public byte[] ThumbNailPhoto { get; set; }
        [StringLength(50)]
        public string ThumbnailPhotoFileName { get; set; }
        public byte[] LargePhoto { get; set; }
        [StringLength(50)]
        public string LargePhotoFileName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty(nameof(ProductProductPhoto.ProductPhoto))]
        public virtual ICollection<ProductProductPhoto> ProductProductPhotos { get; set; }
    }
}
