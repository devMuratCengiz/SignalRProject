using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;
using SignalR.DTO.Dtos.CategoryDtos;
using SignalR.Entity.Entities;
using System.Runtime;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorysController : ControllerBase
    {
        private readonly ICategoryService _service;
        private readonly IMapper _mapper;

        public CategorysController(ICategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult CategoryList()
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
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var values = _mapper.Map<Category>(createCategoryDto);
            _service.TAdd(values);
            return Ok("Added");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var value = _service.TGetById(id);
            _service.TDelete(value);
            return Ok("Deleted");
        }
        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var value = _mapper.Map<Category>(updateCategoryDto);
            _service.TUpdate(value);
            return Ok("Updated");
        }
    }
}
