using Microsoft.AspNet.Identity;
using OnlineShoppingStore.DatabasesModel;
using OnlineShoppingStore.Models.EntitesModel;
using OnlineShoppingStore.Repository;
using System.Web.Mvc;

namespace OnlineShoppingStore.Controllers
{
    [Authorize]
    public class BasketLineController : Controller
    {

        BasketLineBusinessLayer layer;
        dbMyOnlineShoppingEntities db;
       public string userId;

        // GET: BasketLine
        
        public BasketLineController()
        {

        }
        [Authorize]
        public ActionResult Index()
        {
            BasketCartView cartView = new BasketCartView();
            userId = User.Identity.GetUserId();
            layer = new BasketLineBusinessLayer(userId);
            cartView.Baskets = layer.GetBaskets();
            cartView.TotalPrice = layer.TotalPrice();
            return View(cartView);

        }

        [HttpPost]
        public ActionResult Add(ProductModel model , int quantity)
        {
            userId = User.Identity.GetUserId();
            layer = new BasketLineBusinessLayer(userId);
            layer.AddToBasket(model.ProductId, quantity);
            return RedirectToAction("Index","Home");
        }


        public ActionResult Delete(int? deletedId) 
        {
            if(deletedId!=null)
            {
                userId = User.Identity.GetUserId();
                layer = new BasketLineBusinessLayer(userId);
                layer.DeleteBasket(deletedId.Value);
            }
            return RedirectToAction("Index");
            
        
        }

        [HttpGet]
        public ActionResult Update(BasketCartView model)
        {
            if (model != null)
            {
                userId = User.Identity.GetUserId();
                layer = new BasketLineBusinessLayer(userId);
                layer.UpdateBasket(model.Baskets);
            }
            return RedirectToAction("Index");
        }

    }
}