using AutoMapper;
using OnlineShoppingStore.App_Start;
using OnlineShoppingStore.DatabasesModel;
using OnlineShoppingStore.Models.EntitesModel;
using OnlineShoppingStore.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using OnlineShoppingStore.Models;

namespace OnlineShoppingStore.Controllers
{
    public class HomeController : Controller
    {
        public GenericUnitOfWork unitOfWork;
        IMapper Mapper;
        dbMyOnlineShoppingEntities db;
        public HomeController()
        {
            unitOfWork = new GenericUnitOfWork();
            Mapper = AutoMapperConfig.Mapper;
            db = new dbMyOnlineShoppingEntities();

        }
        public ActionResult Index(int? page, string search = "")
        {
            HomeIndexViewModel model = new HomeIndexViewModel();

            return View(model.CreateModel(search, 12, page));
        }
        public ActionResult ProductList(int? page, string search = "")

        {
            HomeIndexViewModel model = new HomeIndexViewModel();
            return PartialView("ProductList", model.CreateModel(search, 12, page));

        }
       
        public ActionResult ProductDetails(int id)
        {

            var proudct = unitOfWork.GetRepositoryInstance<Tbl_Product>().GetFirstorDefault(id);
            var proudctModel = Mapper.Map<ProductModel>(proudct);
            return View(proudctModel);

        }





        
    }
}