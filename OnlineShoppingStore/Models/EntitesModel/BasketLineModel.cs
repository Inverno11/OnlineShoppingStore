using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore.Models.EntitesModel
{
    public class BasketLineModel
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public string MemberId { get; set; }
        public int Quantity { get; set; }

        public decimal TotalPrice { set; get; }
        public ProductModel ProductModel { set; get; }


    }
}