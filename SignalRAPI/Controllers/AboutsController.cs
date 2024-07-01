using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;
using SignalR.DTO.Dtos.AboutDtos;
using SignalR.Entity.Entities;
using System.Runtime;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IAboutService _service;
        private readonly IMapper _mapper;

        public AboutsController(IAboutService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult AboutList()
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
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            var values = _mapper.Map<About>(createAboutDto);
            _service.TAdd(values);
            return Ok("Added");
        }
		[HttpDelete("{id}")]
		public IActionResult DeleteAbout(int id)
        {
            var value = _service.TGetById(id);
            _service.TDelete(value);
            return Ok("Deleted");
        }
        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var value = _mapper.Map<About>(updateAboutDto);
            _service.TUpdate(value);
            return Ok("Updated");
        }
    }
}
