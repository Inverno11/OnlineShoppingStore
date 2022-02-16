using System.Collections.Generic;

namespace OnlineShoppingStore.Models.EntitesModel
{
    public class BasketCartView
    {
      public  List<BasketLineModel> Baskets { set; get; }
        public decimal TotalPrice  { set; get; }
}
}