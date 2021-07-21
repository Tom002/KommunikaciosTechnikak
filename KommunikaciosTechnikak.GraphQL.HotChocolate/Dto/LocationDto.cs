using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Dto
{
    public class LocationDto
    {
        [Key]
        public short LocationId { get; set; }
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }
        public decimal CostRate { get; set; }
        public decimal Availability { get; set; }
        public DateTime ModifiedDate { get; set; }

        public ICollection<ProductInventoryDto> ProductInventories { get; set; }
            = new List<ProductInventoryDto>();
    }
}
