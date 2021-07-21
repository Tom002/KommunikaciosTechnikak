using KommunikaciosTechnikak.Dal.Model;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KommunikaciosTechnikak.OData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductInventoryController : ODataController
    {
        private readonly AdventureWorks2019Context _context;

        public ProductInventoryController(AdventureWorks2019Context context)
        {
            _context = context;
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {
            var products = _context.ProductInventories.AsQueryable();
            return Ok(products);
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult Get(
            [FromODataUri] int keyProductId,
            [FromODataUri] short keyLocationId)
        {
            var productInventory = _context.ProductInventories
                .FirstOrDefault(p => p.ProductId == keyProductId &&
                                     p.LocationId == keyLocationId);
            if (productInventory is ProductInventory)
            {
                return Ok(productInventory);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductInventory productInventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProductInventories.Add(productInventory);
            _context.SaveChanges();

            return Created(productInventory);
        }

        public IActionResult Put(
            [FromODataUri] int keyProductId,
            [FromODataUri] short keyLocationId,
            [FromBody] ProductInventory productInventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productInventoryToUpdate = _context.ProductInventories
                .FirstOrDefault(p => p.ProductId == keyProductId &&
                                     p.LocationId == keyLocationId);
            if (productInventoryToUpdate is ProductInventory)
            {
                // Az url-ben megadott id érték a mérvadó
                productInventory.ProductId = keyProductId;
                productInventory.LocationId = keyLocationId;

                // Ezeket a mezőket nem lehet manuálisan update-elni
                productInventory.Rowguid = productInventoryToUpdate.Rowguid;
                productInventory.ModifiedDate = productInventoryToUpdate.ModifiedDate;

                _context.Entry(productInventoryToUpdate).CurrentValues.SetValues(productInventory);
                _context.SaveChanges();

                return NoContent();
            }
            return NotFound();
        }

        public IActionResult Patch(
            [FromODataUri] int keyProductId,
            [FromODataUri] short keyLocationId,
            [FromBody] Delta<ProductInventory> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productInventoryToUpdate = _context.ProductInventories
                .FirstOrDefault(p => p.ProductId == keyProductId &&
                                     p.LocationId == keyLocationId);
            if (productInventoryToUpdate is ProductInventory)
            {
                patch.Patch(productInventoryToUpdate);
                _context.SaveChanges();

                return NoContent();
            }
            return NotFound();
        }

        public IActionResult Delete(
            [FromODataUri] int keyProductId,
            [FromODataUri] short keyLocationId)
        {
            var productInventoryToDelete = _context.ProductInventories
                .FirstOrDefault(p => p.ProductId == keyProductId &&
                                     p.LocationId == keyLocationId);
            if (productInventoryToDelete is ProductInventory)
            {
                _context.ProductInventories.Remove(productInventoryToDelete);
                _context.SaveChanges();

                return NoContent();
            }
            return NotFound();
        }
    }
}
