using AutoMapper;
using KommunikaciosTechnikak.Dal.Model;
using KommunikaciosTechnikak.OData.Dto;
using KommunikaciosTechnikak.OData.Helpers;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace KommunikaciosTechnikak.OData.Controllers
{
    public class ProductsController : ODataController
    {
        private readonly AdventureWorks2019Context _context;
        private readonly IMapper _mapper;

        public ProductsController(
            AdventureWorks2019Context context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [EnableQuery(
            // Kapcsolódó entitások lekérdezése esetén a maximális mélység
            MaxExpansionDepth = 3,
            // Maximális oldalméret, ennél nagyobbat kliens nem kérhet
            PageSize = 5,
            // Érdemes lehet a orderby-t csak olyan mezőkre korlátozni amire van index
            AllowedOrderByProperties = "ProductId,Name,ListPrice",
            // Filter kifejezésben szereplő node-ok max száma
            MaxNodeCount = 20,
            // Az all és any függvények letiltása
            AllowedFunctions = AllowedFunctions.AllFunctions &
                               ~AllowedFunctions.All & 
                               ~AllowedFunctions.Any &
            // String függvények letiltása
                               ~AllowedFunctions.AllStringFunctions)]
        public IActionResult Get()
        {
            var products = _context.Products.AsQueryable();
            return Ok(products);
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult Get([FromODataUri] int key)
        {
            var productQuery = _context.Products.Where(p => p.ProductId == key);
            if (productQuery.Any())
            {
                return Ok(SingleResult.Create(productQuery));
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Products.Add(product);
            _context.SaveChanges();

            return Created(product);
        }

        public IActionResult Put(
            [FromODataUri] int key,
            [FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productToUpdate = _context.Products.FirstOrDefault(p => p.ProductId == key);
            if(productToUpdate is Product)
            {
                // Az url-ben megadott id érték a mérvadó
                product.ProductId = key;

                // Ezeket a mezőket nem lehet manuálisan update-elni
                product.Rowguid = productToUpdate.Rowguid;
                product.ModifiedDate = productToUpdate.ModifiedDate;

                _context.Entry(productToUpdate).CurrentValues.SetValues(product);
                _context.SaveChanges();

                return NoContent();
            }
            return NotFound();
        }

        public IActionResult Patch(
            [FromODataUri] int key,
            [FromBody] Delta<Product> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productToUpdate = _context.Products.FirstOrDefault(p => p.ProductId == key);
            if (productToUpdate is Product)
            {
                patch.Patch(productToUpdate);
                _context.SaveChanges();

                return NoContent();
            }
            return NotFound();
        }

        public IActionResult Delete([FromODataUri] int key)
        {
            var productToDelete = _context.Products.FirstOrDefault(p => p.ProductId == key);
            if (productToDelete is Product)
            {
                var productInventoriesToDelete = _context.ProductInventories
                    .Where(p => p.ProductId == key)
                    .ToList();

                foreach (var productInventory in productInventoriesToDelete)
                {
                    _context.ProductInventories.Remove(productInventory);
                }

                _context.Products.Remove(productToDelete);
                _context.SaveChanges();

                return NoContent();
            }
            return NotFound();
        }

        [HttpGet]
        [ODataRoute("Products({key})/Name")]
        [ODataRoute("Products({key})/ProductNumber")]
        [ODataRoute("Products({key})/MakeFlag")]
        [ODataRoute("Products({key})/FinishedGoodsFlag")]
        [ODataRoute("Products({key})/Color")]
        [ODataRoute("Products({key})/SafetyStockLevel")]
        [ODataRoute("Products({key})/ReorderPoint")]
        [ODataRoute("Products({key})/StandardCost")]
        [ODataRoute("Products({key})/ListPrice")]
        [ODataRoute("Products({key})/Size")]
        [ODataRoute("Products({key})/SizeUnitMeasureCode")]
        [ODataRoute("Products({key})/WeightUnitMeasureCode")]
        [ODataRoute("Products({key})/Weight")]
        [ODataRoute("Products({key})/DaysToManufacture")]
        [ODataRoute("Products({key})/ProductLine")]
        [ODataRoute("Products({key})/Class")]
        [ODataRoute("Products({key})/Style")]
        [ODataRoute("Products({key})/ProductSubcategoryId")]
        [ODataRoute("Products({key})/ProductModelId")]
        [ODataRoute("Products({key})/SellStartDate")]
        [ODataRoute("Products({key})/SellEndDate")]
        [ODataRoute("Products({key})/DiscontinuedDate")]
        public IActionResult GetProductProperty([FromODataUri] int key)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == key);
            if (product is Product)
            {
                var propertyToGet = Request.Path.Value.Split('/').Last();

                if (!product.HasProperty(propertyToGet))
                {
                    return NotFound();
                }

                var propertyValue = product.GetValue(propertyToGet);
                if (propertyValue == null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(propertyValue);
                }
            }
            return NotFound();
        }
    }
}
