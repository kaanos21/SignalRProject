using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISocialMediaService _SocialMediaService;

        public SocialMediaController(IMapper mapper, ISocialMediaService SocialMediaService)
        {
            _mapper = mapper;
            _SocialMediaService = SocialMediaService;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var value = _mapper.Map<List<ResultSocialMediaDto>>(_SocialMediaService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto SocialMediaDto)
        {
            _SocialMediaService.TAdd(new SocialMedia()
            {
                Icon=SocialMediaDto.Icon,
                Title=SocialMediaDto.Title,
                Url=SocialMediaDto.Url,
            });
            return Ok("Eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteSocialMedia(int id)
        {

            var vv = _SocialMediaService.TGetById(id);
            _SocialMediaService.TDelete(vv);
            return Ok("Silindi");
        }
        [HttpGet("GetSocialMedia")]
        public IActionResult GetSocialMedia(int id)
        {
            var vv = _SocialMediaService.TGetById(id);
            return Ok(vv);
        }
        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto SocialMediaDto)
        {
            _SocialMediaService.TUpdate(new SocialMedia()
            {
                SocialMediaID=SocialMediaDto.SocialMediaID,
                Icon = SocialMediaDto.Icon,
                Title = SocialMediaDto.Title,
                Url = SocialMediaDto.Url,
            });
            return Ok("Güncellendi");
        }
    }
}
