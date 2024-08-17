using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDiscountService _DiscountService;

        public DiscountController(IMapper mapper, IDiscountService DiscountService)
        {
            _mapper = mapper;
            _DiscountService = DiscountService;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var value = _mapper.Map<List<ResultDiscountDto>>(_DiscountService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto DiscountDto)
        {
            _DiscountService.TAdd(new Discount()
            {
                Description= DiscountDto.Description,
                Amount=DiscountDto.Amount,
                ImageUrl=DiscountDto.ImageUrl,
                Title=DiscountDto.Title,
            });
            return Ok("Eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteDiscount(int id)
        {

            var vv = _DiscountService.TGetById(id);
            _DiscountService.TDelete(vv);
            return Ok("Silindi");
        }
        [HttpGet("GetDiscount")]
        public IActionResult GetDiscount(int id)
        {
            var vv = _DiscountService.TGetById(id);
            return Ok(vv);
        }
        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto DiscountDto)
        {
            _DiscountService.TUpdate(new Discount()
            {
                DiscountId=DiscountDto.DiscountId,
                Description = DiscountDto.Description,
                Amount = DiscountDto.Amount,
                ImageUrl = DiscountDto.ImageUrl,
                Title = DiscountDto.Title,
            });
            return Ok("Güncellendi");
        }
    }
}
