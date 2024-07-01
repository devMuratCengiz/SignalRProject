using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;
using SignalR.DTO.Dtos.SocialMediaDtos;
using SignalR.Entity.Entities;
using System.Runtime;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        private readonly ISocialMediaService _service;
        private readonly IMapper _mapper;

        public SocialMediasController(ISocialMediaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult SocialMediaList()
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
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            var values = _mapper.Map<SocialMedia>(createSocialMediaDto);
            _service.TAdd(values);
            return Ok("Added");
        }
		[HttpDelete("{id}")]
		public IActionResult DeleteSocialMedia(int id)
        {
            var value = _service.TGetById(id);
            _service.TDelete(value);
            return Ok("Deleted");
        }
        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var value = _mapper.Map<SocialMedia>(updateSocialMediaDto);
            _service.TUpdate(value);
            return Ok("Updated");
        }
    }
}
