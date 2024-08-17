using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _BookingService;

        public BookingController(IBookingService BookingService)
        {
            _BookingService = BookingService;
        }
        [HttpGet]
        public IActionResult BookingList()
        {
            var vv = _BookingService.TGetListAll();
            return Ok(vv);
        }
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            Booking Booking = new Booking()
            {
                Mail = createBookingDto.Mail,
                Date = DateTime.Now,
                Name = createBookingDto.Name,
                PersonCount = createBookingDto.PersonCount,
                Phone = createBookingDto.Phone,
                Description=createBookingDto.Description,
            };
            _BookingService.TAdd(Booking);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteBooking(int id)
        {
            var xx = _BookingService.TGetById(id);
            _BookingService.TDelete(xx);
            return Ok("Silindi");
        }
        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            Booking Booking = new Booking()
            {
                BookingID= updateBookingDto.BookingID,
                Mail = updateBookingDto.Mail,
                Date = updateBookingDto.Date,
                Name = updateBookingDto.Name,
                PersonCount = updateBookingDto.PersonCount,
                Phone = updateBookingDto.Phone,
                Description = updateBookingDto.Description,
            };
            _BookingService.TUpdate(Booking);
            return Ok("Güncellendi");
        }
        [HttpGet("GetBooking")]
        public IActionResult GetBooking(int id)
        {
            var xx = _BookingService.TGetById(id);
            return Ok(xx);
        }
        [HttpGet("BookingStatusApproved")]
        public IActionResult BookingStatusApproved(int id)
        {
            _BookingService.TBookingStatusApproved(id);
            return Ok("Rezervasyon Onaylandı");
        }
		[HttpGet("BookingStatusCancelled")]
		public IActionResult BookingStatusCancelled(int id)
		{
			_BookingService.TBookingStatusCancelled(id);
			return Ok("Rezervasyon İptal Edildi");
		}

	}
}
