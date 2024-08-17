using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITestimonialService _TestimonialService;

        public TestimonialController(IMapper mapper, ITestimonialService TestimonialService)
        {
            _mapper = mapper;
            _TestimonialService = TestimonialService;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var value = _mapper.Map<List<ResultTestimonialDto>>(_TestimonialService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto TestimonialDto)
        {
            _TestimonialService.TAdd(new Testimonial()
            {
                Comment=TestimonialDto.Comment,
                ImageUrl=TestimonialDto.ImageUrl,
                Name=TestimonialDto.Name,
                Status=true,
                Title=TestimonialDto.Title,
            });
            return Ok("Eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {

            var vv = _TestimonialService.TGetById(id);
            _TestimonialService.TDelete(vv);
            return Ok("Silindi");
        }
        [HttpGet("GetTestimonial")]
        public IActionResult GetTestimonial(int id)
        {
            var vv = _TestimonialService.TGetById(id);
            return Ok(vv);
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto TestimonialDto)
        {
            _TestimonialService.TUpdate(new Testimonial()
            {
                TestimonialID = TestimonialDto.TestimonialID,
                Comment = TestimonialDto.Comment,
                ImageUrl = TestimonialDto.ImageUrl,
                Name = TestimonialDto.Name,
                Status = true,
                Title = TestimonialDto.Title,
            });
            return Ok("Güncellendi");
        }
    }
}
