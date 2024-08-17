using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NotificationController : ControllerBase
	{
		private readonly INotificationService _notificationService;

		public NotificationController(INotificationService notificationService)
		{
			_notificationService = notificationService;
		}
		[HttpGet]
		public IActionResult NotificationList()
		{
			return Ok(_notificationService.TGetListAll());
		}
		[HttpGet("NotificationCountByStatusFalse")]
		public IActionResult NotificationCountByStatusFalse()
		{
			return Ok(_notificationService.TNotificationCountByStatusFalse());
		}
		[HttpGet("GetAllNotificationByFalse")]
		public IActionResult GetAllNotificationByFalse()
		{
			return Ok(_notificationService.TGetAllNotificationByFalse());
		}
		[HttpPost]
		public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
		{
			Notification notification = new Notification() {
				Description = createNotificationDto.Description,
				Icon = createNotificationDto.Icon,
				Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
				Status = false,
				Type = createNotificationDto.Type,
			};
			_notificationService.TAdd(notification);
			return Ok("Eklendi");
		}
		[HttpDelete("DeleteById")]
		public IActionResult DeleteNotification(int id)
		{
			var value=_notificationService.TGetById(id);
			_notificationService.TDelete(value);
			return Ok("Bildirim Silindi");
		}
		[HttpGet("GetById")]
		public IActionResult GetNotification(int id)
		{
			var xx = _notificationService.TGetById(id);
			return Ok(xx);
		}
		[HttpPut]
		public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
		{
			Notification notification = new Notification()
			{
				NotificationID = updateNotificationDto.NotificationID,
				Description = updateNotificationDto.Description,
				Icon = updateNotificationDto.Icon,
				Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
				Status = false,
				Type= updateNotificationDto.Type,
			};
			_notificationService.TUpdate(notification);
			return Ok("Eklendi");
		}
		[HttpGet("NotificationChangeToFalse")]
		public IActionResult NotificationChangeToFalse(int id)
		{
			_notificationService.TNotificationChangeToFalse(id);
			return Ok("False Yapıldı");
		}
        [HttpGet("NotificationChangeToTrue")]
        public IActionResult NotificationChangeToTrue(int id)
        {
            _notificationService.TNotificationChangeToTrue(id);
            return Ok("True Yapıldı");
        }

    }
}
