using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IContactService _ContactService;

        public ContactController(IMapper mapper, IContactService ContactService)
        {
            _mapper = mapper;
            _ContactService = ContactService;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var value = _mapper.Map<List<ResultContactDto>>(_ContactService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto ContactDto)
        {
            _ContactService.TAdd(new Contact()
            {
                FooterDescription= ContactDto.FooterDescription,
                Location= ContactDto.Location,
                Mail= ContactDto.Mail,
                Phone= ContactDto.Phone,
            });
            return Ok("Eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {

            var vv = _ContactService.TGetById(id);
            _ContactService.TDelete(vv);
            return Ok("Silindi");
        }
        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {
            var vv = _ContactService.TGetById(id);
            return Ok(vv);
        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto ContactDto)
        {
            _ContactService.TUpdate(new Contact()
            {
                ContactID = ContactDto.ContactID,
                FooterDescription = ContactDto.FooterDescription,
                Location = ContactDto.Location,
                Mail = ContactDto.Mail,
                Phone = ContactDto.Phone,
            });
            return Ok("Güncellendi");
        }
    }
}
