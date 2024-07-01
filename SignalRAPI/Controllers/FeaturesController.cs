using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;
using SignalR.DTO.Dtos.FeatureDtos;
using SignalR.Entity.Entities;
using System.Runtime;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeatureService _service;
        private readonly IMapper _mapper;

        public FeaturesController(IFeatureService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult FeatureList()
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
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var values = _mapper.Map<Feature>(createFeatureDto);
            _service.TAdd(values);
            return Ok("Added");
        }
		[HttpDelete("{id}")]
		public IActionResult DeleteFeature(int id)
        {
            var value = _service.TGetById(id);
            _service.TDelete(value);
            return Ok("Deleted");
        }
        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var value = _mapper.Map<Feature>(updateFeatureDto);
            _service.TUpdate(value);
            return Ok("Updated");
        }
    }
}
