using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.Business.Abstract;
using SignalR.DataAccess.Concrete;
using SignalR.DTO.Dtos.ProductDtos;
using SignalR.Entity.Entities;
using System.Runtime;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;
        private readonly SignalRContext _context;

        public ProductsController(IProductService service, IMapper mapper, SignalRContext context)
        {
            _service = service;
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _service.TGetListAll();
            return Ok(values);
        }
		[HttpGet("{id}")]
		public IActionResult GetById(int id)
        {
            var value = _service.TGetById(id);
            return Ok(value);
        }
        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var values = _context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategoryDto
            {
                Description = y.Description,
                ImageUrl = y.ImageUrl,
                Price = y.Price,
                Id = y.Id,
                Name = y.Name,
                Status = y.Status,
                CategoryName = y.Category.Name
            });
            return Ok(values.ToList());
        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            var values = _mapper.Map<Product>(createProductDto);
            _service.TAdd(values);
            return Ok("Added");
        }
		[HttpDelete("{id}")]
		public IActionResult DeleteProduct(int id)
        {
            var value = _service.TGetById(id);
            _service.TDelete(value);
            return Ok("Deleted");
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            var value = _mapper.Map<Product>(updateProductDto);
            _service.TUpdate(value);
            return Ok("Updated");
        }
    }
}
