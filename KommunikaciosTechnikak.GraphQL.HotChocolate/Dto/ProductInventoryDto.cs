using System;
using System.ComponentModel.DataAnnotations;

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Dto
{
    public class ProductInventoryDto
    {
        [Key]
        public int ProductId { get; set; }
        [Key]
        public short LocationId { get; set; }
        [Required]
        [StringLength(10)]
        public string Shelf { get; set; } = default!;
        public byte Bin { get; set; }
        public short Quantity { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public ProductDto? Product { get; set; }

        public LocationDto? Location { get; set; }
    }
}
