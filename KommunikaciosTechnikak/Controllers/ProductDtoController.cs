using AutoMapper;
using AutoMapper.QueryableExtensions;
using KommunikaciosTechnikak.Dal.Model;
using KommunikaciosTechnikak.OData.Dto;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;

namespace KommunikaciosTechnikak.OData.Controllers
{
    public class ProductDtoController : ODataController
    {
        private readonly AdventureWorks2019Context _context;
        private readonly IMapper _mapper;

        public ProductDtoController(
            AdventureWorks2019Context context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [EnableQuery(MaxExpansionDepth = 3, PageSize = 5)]
        public IActionResult Get()
        {
            var products = _context.Products.ProjectTo<ProductDto>(_mapper.ConfigurationProvider);
            return Ok(products);
        }
    }
}
