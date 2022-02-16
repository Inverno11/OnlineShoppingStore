using AutoMapper;
using Microsoft.AspNet.Identity;
using OnlineShoppingStore.App_Start;
using OnlineShoppingStore.DatabasesModel;
using OnlineShoppingStore.Models.EntitesModel;
using OnlineShoppingStore.Repository;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineShoppingStore.Controllers
{
    public class ShippingController : Controller
    {

        IMapper Mapper;
        GenericUnitOfWork unit;
        BasketLineBusinessLayer basketLineBusinessLayer;
        string memberId;
        public ShippingController()
        {
            Mapper = AutoMapperConfig.Mapper;
            unit = new GenericUnitOfWork();

        }
        // GET: Shipping
        [HttpGet]
        public ActionResult Create()
        {
            memberId = User.Identity.GetUserId();
            basketLineBusinessLayer = new BasketLineBusinessLayer(memberId);

            return View();
        }
        [HttpPost]
        public ActionResult Create(ShippingModel model)
        {

            model.MemberId = User.Identity.GetUserId();
            BasketLineBusinessLayer newbasketLineBusinessLayer = new BasketLineBusinessLayer(model.MemberId);

            model.AmountPaid = newbasketLineBusinessLayer.TotalPrice();
            model.CreationDate = System.DateTime.Now;
            model.DeliverdOn = model.CreationDate.Value.AddDays(8).AddHours(12);

            var shippingDetails = Mapper.Map<Tbl_ShippingDetails>(model);

            unit.GetRepositoryInstance<Tbl_ShippingDetails>().Add(shippingDetails);

            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Index()
        {
           string userId = User.Identity.GetUserId();
            var ShippingList = unit.GetRepositoryInstance<Tbl_ShippingDetails>().GetAllRecordesIQueryable(e=>e.MemberId== userId);
            var ShippingListModel = Mapper.Map<IEnumerable<ShippingModel>>(ShippingList);
            return View(ShippingListModel);
        }
    }
}