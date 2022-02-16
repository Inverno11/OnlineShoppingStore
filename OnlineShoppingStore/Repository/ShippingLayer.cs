using AutoMapper;
using OnlineShoppingStore.App_Start;
using OnlineShoppingStore.DatabasesModel;
using OnlineShoppingStore.Models.EntitesModel;

namespace OnlineShoppingStore.Repository
{
    public class ShippingLayer
    {
        dbMyOnlineShoppingEntities db = new dbMyOnlineShoppingEntities();

        IMapper Mapper;
        string UserID;
        BasketLineBusinessLayer BasketLayer;
        public ShippingLayer(string userId)
        {
            Mapper = AutoMapperConfig.Mapper;
            UserID = userId;
            BasketLayer = new BasketLineBusinessLayer(userId);

        }

        public void AddToShipping(ShippingModel model) 
        {
            model.MemberId = UserID;
            model.DeliverdOn = System.DateTime.Now.AddDays(7);
            model.AmountPaid = BasketLayer.TotalPrice();
            var shipping = Mapper.Map<Tbl_ShippingDetails>(model);
            db.Tbl_ShippingDetails.Add(shipping);
            db.SaveChanges();

        }





    }
}