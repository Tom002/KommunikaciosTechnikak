using KommunikaciosTechnikak.Dal.Model;
using System.Collections.Generic;

namespace KommunikaciosTechnikak.OData.Dto
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public string Size { get; set; }
        public virtual ProductModel ProductModel { get; set; }
        public virtual ICollection<ProductInventory> ProductInventories { get; set; }
    }
}
