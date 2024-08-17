using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MessageDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessageController : ControllerBase
	{
		private readonly IMessageService _MessageService;

		public MessageController(IMessageService MessageService)
		{
			_MessageService = MessageService;
		}
		[HttpGet]
		public IActionResult MessageList()
		{
			var vv = _MessageService.TGetListAll();
			return Ok(vv);
		}
		[HttpPost]
		public IActionResult CreateMessage(CreateMessageDto createMessageDto)
		{
			Message Message = new Message()
			{
				Mail = createMessageDto.Mail,
				MessageContent = createMessageDto.MessageContent,
				MessageSendDate = DateTime.Now,
				NameSurname = createMessageDto.NameSurname,
				Phone=createMessageDto.Phone,
				Status = createMessageDto.Status,
				Subject = createMessageDto.Subject,
			};
			_MessageService.TAdd(Message);
			return Ok();
		}
		[HttpDelete]
		public IActionResult DeleteMessage(int id)
		{
			var xx = _MessageService.TGetById(id);
			_MessageService.TDelete(xx);
			return Ok("Silindi");
		}
		[HttpPut]
		public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
		{
			Message Message = new Message()
			{
				MessageID = updateMessageDto.MessageID,
				MessageSendDate= updateMessageDto.MessageSendDate,
				Mail = updateMessageDto.Mail,
				MessageContent= updateMessageDto.MessageContent,
				NameSurname= updateMessageDto.NameSurname,
				Phone = updateMessageDto.Phone,
				Status= updateMessageDto.Status,
				Subject= updateMessageDto.Subject,
			};
			_MessageService.TUpdate(Message);
			return Ok("Güncellendi");
		}
		[HttpGet("GetMessage")]
		public IActionResult GetMessage(int id)
		{
			var xx = _MessageService.TGetById(id);
			return Ok(xx);
		}
	}
}
