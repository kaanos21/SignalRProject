using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public CategoryController(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }
        [HttpGet("CategoryCount")]

        public IActionResult CategoryCount()
        {
            return Ok(_categoryService.TCategoryCount());
        }
		[HttpGet("ActiveCategoryCount")]

		public IActionResult ActiveCategoryCount()
		{
			return Ok(_categoryService.TActiveCategoryCount());
		}
		[HttpGet("PassiveCategoryCount")]

		public IActionResult PassiveCategoryCount()
		{
			return Ok(_categoryService.TPassiveCategoryCount());
		}
		[HttpGet]
        public IActionResult CategoryList()
        {
            var value = _mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto categoryDto)
        {
            _categoryService.TAdd(new Category()
            {
                CategoryName = categoryDto.CategoryName,
                Status = true,
            });
            return Ok("Eklendi");
        }
        [HttpPost("dşkfjgndfgkh")]
        public IActionResult CreateCathegory(CreateCategoryDto categoryDto)
        {
            _categoryService.TAdd(new Category()
            {
                CategoryName = categoryDto.CategoryName,
                Status = true,
            });
            return Ok("Eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {

            var vv=_categoryService.TGetById(id);
            _categoryService.TDelete(vv);
            return Ok("Silindi");
        }
        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id)
        {
            var vv=_categoryService.TGetById(id);
            return Ok(vv);
        }
        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto categoryDto)
        {
            _categoryService.TUpdate(new Category()
            {
                CategoryName = categoryDto.CategoryName,
                Status = categoryDto.Status,
                CategoryID = categoryDto.CategoryId,
            });
            return Ok("Güncellendi");
        }
    }
}
