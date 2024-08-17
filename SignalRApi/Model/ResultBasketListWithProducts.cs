﻿using SignalR.EntityLayer.Entities;

namespace SignalRApi.Model
{
    public class ResultBasketListWithProducts
    {
        public int BasketID { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductID { get; set; }
        public int MenuTableID { get; set; }
        public string ProductName { get; set; }
    }
}
