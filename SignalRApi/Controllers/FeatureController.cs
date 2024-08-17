using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFeatureService _FeatureService;

        public FeatureController(IMapper mapper, IFeatureService FeatureService)
        {
            _mapper = mapper;
            _FeatureService = FeatureService;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var value = _mapper.Map<List<ResultFeatureDto>>(_FeatureService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto FeatureDto)
        {
            _FeatureService.TAdd(new Feature()
            {
                Description1 = FeatureDto.Description1,
                Description2 = FeatureDto.Description2,
                Description3 = FeatureDto.Description3,
                Title1 = FeatureDto.Title1,
                Title2 = FeatureDto.Title2,
                Title3 = FeatureDto.Title3,
            });
            return Ok("Eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {

            var vv = _FeatureService.TGetById(id);
            _FeatureService.TDelete(vv);
            return Ok("Silindi");
        }
        [HttpGet("GetFeature")]
        public IActionResult GetFeature(int id)
        {
            var vv = _FeatureService.TGetById(id);
            return Ok(vv);
        }
        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto FeatureDto)
        {
            _FeatureService.TUpdate(new Feature()
            {
                FeatureID = FeatureDto.FeatureID,
                Description1 = FeatureDto.Description1,
                Description2 = FeatureDto.Description2,
                Description3 = FeatureDto.Description3,
                Title1 = FeatureDto.Title1,
                Title2 = FeatureDto.Title2,
                Title3 = FeatureDto.Title3,
            });
            return Ok("Güncellendi");
        }
    }
}
