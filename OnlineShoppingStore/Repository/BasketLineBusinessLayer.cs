using AutoMapper;
using OnlineShoppingStore.App_Start;
using OnlineShoppingStore.DatabasesModel;
using OnlineShoppingStore.Models.EntitesModel;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OnlineShoppingStore.Repository
{
    public class BasketLineBusinessLayer
    {
        dbMyOnlineShoppingEntities db = new dbMyOnlineShoppingEntities();
         
        IMapper Mapper;
        string UserID;

        public  BasketLineBusinessLayer(string userId) 
        {
            UserID = userId;
            Mapper = AutoMapperConfig.Mapper;
        }

        public void AddToBasket( int ProductId, int Quantity) 
        {
            BasketLineModel basketModel = new BasketLineModel();

           var basket = db.Tbl_BasketLine.FirstOrDefault(b=>b.ProductId == ProductId &&  b.MemberId == UserID);
            if(basket==null)
            {
                basketModel.ProductId = ProductId;
                basketModel.Quantity = Quantity;
                basketModel.MemberId = UserID;

                Tbl_BasketLine tbl_BasketLine = new Tbl_BasketLine();
                tbl_BasketLine = Mapper.Map<Tbl_BasketLine>(basketModel);
                tbl_BasketLine.Tbl_Product = null;
                tbl_BasketLine.AspNetUser = null;
                db.Tbl_BasketLine.Add(tbl_BasketLine);
                db.SaveChanges();

            }
            else
            {
                basket.Quantity += Quantity;
                db.Tbl_BasketLine.Attach(basket);
                db.Entry(basket).State= EntityState.Modified;
                db.SaveChanges();


            }

        }

        public void DeleteBasket(int cartId)         
        {
            var basket = db.Tbl_BasketLine.FirstOrDefault(b => b.CartId == cartId && b.MemberId == UserID);

            if (basket != null)
            {
                db.Tbl_BasketLine.Remove(basket);
            }
            db.SaveChanges();

        }
        public void UpdateBasket(List<BasketLineModel> basketLineModels)
        {

            foreach(BasketLineModel bas in basketLineModels)
            {
                if(bas.Quantity==0)
                {

                    DeleteBasket(bas.CartId);
                }
                else
                {
                    AddToBasket(bas.ProductId,bas.Quantity);
                }
            }
           
        }

        public List<BasketLineModel> GetBaskets() 
        {

            var baskets = db.Tbl_BasketLine.Where(bas => bas.MemberId == UserID).ToList();
            var basketsModel = Mapper.Map<List<BasketLineModel>>(baskets);
            return basketsModel;

        }

        public decimal TotalPrice()
        {

            var Allbaskets = GetBaskets();
           var price = Allbaskets.Sum(basket=>basket.ProductModel.Price * basket.Quantity);
            return price.Value;

        }

        
    }
}