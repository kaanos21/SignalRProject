using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccesLayer.Concrete;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _ProductService;

        public ProductController(IMapper mapper, IProductService ProductService)
        {
            _mapper = mapper;
            _ProductService = ProductService;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var value = _mapper.Map<List<ResultProductDto>>(_ProductService.TGetListAll());
            return Ok(value);
        }
        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var context = new SignalRContext();
            var values = context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategory
            {
                Description = y.Description,
                ImageUrl = y.ImageUrl,
                Price = y.Price,
                ProductID = y.ProductID,
                ProductName = y.ProductName,
                ProductStatus = y.ProductStatus,
                CategoryName = y.Category.CategoryName,
                
            }).ToList();
            return Ok(values);
        }
        [HttpGet("ProductNameByMaxPrice")]
        public IActionResult ProductNameByMaxPrice()
        {
            return Ok(_ProductService.TProductNameByMaxPrice());
        }
        [HttpGet("ProductAvgPriceByHamburger")]
        public IActionResult ProductAvgPriceByHamburger()
        {
            return Ok(_ProductService.TProductAvgPriceByHamburger());
        }
		[HttpGet("ProductNameByMinPrice")]
		public IActionResult ProductNameByMinPrice()
		{
			return Ok(_ProductService.TProductNameByMinPrice());
		}
		[HttpGet("ProductCountByHamburger")]
		public IActionResult ProductCountByHamburger()
		{
			return Ok(_ProductService.TProductCountByCategoryNameHamburger());
		}
		[HttpGet("ProductCountByDrink")]
		public IActionResult ProductCountByDrink()
		{
			return Ok(_ProductService.TProductCountByCategoryNameDrink());
		}
		[HttpGet("ProductPriceAvg")]
		public IActionResult ProductPriceAvg()
		{
			return Ok(_ProductService.TProductPriveAvg());
		}
		[HttpPost]
        public IActionResult CreateProduct(CreateProductDto ProductDto)
        {
            _ProductService.TAdd(new Product()
            {
                ProductName = ProductDto.ProductName,
                Description=ProductDto.Description,
                ImageUrl = ProductDto.ImageUrl,
                Price = ProductDto.Price,
                ProductStatus=true,
                CategoryID=ProductDto.CategoryID,
            });
            return Ok("Eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {

            var vv = _ProductService.TGetById(id);
            _ProductService.TDelete(vv);
            return Ok("Silindi");
        }
        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var vv = _ProductService.TGetById(id);
            return Ok(vv);
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto ProductDto)
        {
            _ProductService.TUpdate(new Product()
            {
                ProductID=ProductDto.ProductID,
                ProductName = ProductDto.ProductName,
                Description = ProductDto.Description,
                ImageUrl = ProductDto.ImageUrl,
                Price = ProductDto.Price,
                ProductStatus = ProductDto.ProductStatus,
                CategoryID=ProductDto.CategoryId,
            });
            return Ok("Güncellendi");
        }
    }
}
