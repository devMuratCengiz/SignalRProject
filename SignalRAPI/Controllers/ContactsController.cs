using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;
using SignalR.DTO.Dtos.ContactDtos;
using SignalR.Entity.Entities;
using System.Runtime;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _service;
        private readonly IMapper _mapper;

        public ContactsController(IContactService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ContactList()
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
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            var values = _mapper.Map<Contact>(createContactDto);
            _service.TAdd(values);
            return Ok("Added");
        }
		[HttpDelete("{id}")]
		public IActionResult DeleteContact(int id)
        {
            var value = _service.TGetById(id);
            _service.TDelete(value);
            return Ok("Deleted");
        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            var value = _mapper.Map<Contact>(updateContactDto);
            _service.TUpdate(value);
            return Ok("Updated");
        }
    }
}
