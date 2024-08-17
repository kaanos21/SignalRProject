using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTablesController : ControllerBase
    {
        private readonly IMenuTableService _menuTableService;

		public MenuTablesController(IMenuTableService menuTableService)
		{
			_menuTableService = menuTableService;
		}

		[HttpGet("MenuTableCount")]
        public IActionResult MenuTableCount()
        {
            return Ok(_menuTableService.TMenuTableCount());
        }


		[HttpGet]
		public IActionResult MenuTableList()
		{
			var vv = _menuTableService.TGetListAll();
			return Ok(vv);
		}
		[HttpPost]
		public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTableDto)
		{
			MenuTable MenuTable = new MenuTable()
			{
				Name = createMenuTableDto.Name,
				Status = createMenuTableDto.Status,
			};
			_menuTableService.TAdd(MenuTable);
			return Ok();
		}
		[HttpDelete]
		public IActionResult DeleteMenuTable(int id)
		{
			var xx = _menuTableService.TGetById(id);
			_menuTableService.TDelete(xx);
			return Ok("Silindi");
		}
		[HttpPut]
		public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
		{
			MenuTable MenuTable = new MenuTable()
			{
				MenuTableID = updateMenuTableDto.MenuTableID,
				Name = updateMenuTableDto.Name,
				Status=updateMenuTableDto.Status,
			};
			_menuTableService.TUpdate(MenuTable);
			return Ok("Güncellendi");
		}
		[HttpGet("GetMenuTable")]
		public IActionResult GetMenuTable(int id)
		{
			var xx = _menuTableService.TGetById(id);
			return Ok(xx);
		}
	}
}
