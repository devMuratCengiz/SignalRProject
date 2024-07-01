using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;
using SignalR.DTO.Dtos.DiscountDtos;
using SignalR.Entity.Entities;
using System.Runtime;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _service;
        private readonly IMapper _mapper;

        public DiscountsController(IDiscountService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult DiscountList()
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
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            var values = _mapper.Map<Discount>(createDiscountDto);
            _service.TAdd(values);
            return Ok("Added");
        }
		[HttpDelete("{id}")]
		public IActionResult DeleteDiscount(int id)
        {
            var value = _service.TGetById(id);
            _service.TDelete(value);
            return Ok("Deleted");
        }
        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            var value = _mapper.Map<Discount>(updateDiscountDto);
            _service.TUpdate(value);
            return Ok("Updated");
        }
    }
}
