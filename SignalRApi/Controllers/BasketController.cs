﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccesLayer.Concrete;
using SignalR.EntityLayer.Entities;
using SignalR.DtoLayer.BasketDto;
using SignalRApi.Model;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }
        [HttpGet]
        public IActionResult Get(int id)
        {
            var values=_basketService.TGetBasketByMenuTableNumber(id);
            return Ok(values);
        }
        [HttpGet("BasketListByMenuTableWithProductName")]
        public IActionResult BasketListByMenuTableWithProductName(int id)
        {
            using var context=new SignalRContext();
            var values=context.Baskets.Include(x=>x.Product).Where(y=>y.MenuTableID==id).Select(z=> new ResultBasketListWithProducts
            {
                BasketID=z.BasketID,
                Count=z.Count,
                MenuTableID=z.MenuTableID,
                Price=z.Price,
                ProductID=z.ProductID,
                TotalPrice=z.TotalPrice,
                ProductName=z.Product.ProductName,
            }).ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            using var context=new SignalRContext();
            _basketService.TAdd(new Basket()
            {
                ProductID=createBasketDto.ProductID,
                Count = 1,
                MenuTableID = 1,
                Price = (int)context.Products.Where(x => x.ProductID == createBasketDto.ProductID).Select(y => y.Price).FirstOrDefault(),
                TotalPrice=0,
            });
            return Ok("Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var xx = _basketService.TGetById(id);
            _basketService.TDelete(xx);
            return Ok("Silindi");
        }
    }
}
