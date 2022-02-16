using AutoMapper;
using OnlineShoppingStore.App_Start;
using OnlineShoppingStore.DatabasesModel;
using OnlineShoppingStore.Models.EntitesModel;
using OnlineShoppingStore.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMapper Mapper;
        private readonly GenericUnitOfWork unitOfWork;
       public ProductController()
        {
            Mapper = AutoMapperConfig.Mapper;
            unitOfWork = new GenericUnitOfWork();
        }

        // GET: Admin/Product
        public ActionResult Index()
        {

            var products = unitOfWork.GetRepositoryInstance<Tbl_Product>().GetAllRecordes();
            var productsModel = Mapper.Map<List<ProductModel>>(products);
            return View(productsModel);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var productModel = new ProductModel();
            InitalizeList( ref productModel);
            return View(productModel);
        }
        [HttpPost]
        public ActionResult Create(ProductModel model)
        {
            InitalizeList(ref model);

            if (ModelState.IsValid)
            {
                var product = Mapper.Map<Tbl_Product>(model);
                product.ProductImage = SaveImage(model.ImageFile, null);
                product.CreatedDate = DateTime.Now;
                product.Tbl_BasketLine = null;
                product.Tbl_Category = null;

                unitOfWork.GetRepositoryInstance<Tbl_Product>().Add(product);
                return RedirectToAction("Index");

            }
            return View();
        }
        public ActionResult Edit( int id)
        {
            var products = unitOfWork.GetRepositoryInstance<Tbl_Product>().GetFirstorDefault(id);
            var productsModel = Mapper.Map<ProductModel>(products);
            InitalizeList(ref productsModel);
            return View(productsModel);
        }
        [HttpPost]
        public ActionResult Edit(ProductModel model)
        {
            InitalizeList(ref model);
            if (ModelState.IsValid)
            {
                var product = Mapper.Map<Tbl_Product>(model);
                product.ModifiedDate = DateTime.Now;
                product.ProductImage = SaveImage(model.ImageFile , model.ProductImage);
                product.Tbl_Category = null;
                product.Tbl_BasketLine = null;
                unitOfWork.GetRepositoryInstance<Tbl_Product>().Update(product);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var products = unitOfWork.GetRepositoryInstance<Tbl_Product>().GetFirstorDefault(id);
            var productsModel = Mapper.Map<ProductModel>(products);
            return View(productsModel);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var products = unitOfWork.GetRepositoryInstance<Tbl_Product>().GetFirstorDefault(id);
            var productsModel = Mapper.Map<ProductModel>(products);
            return View(productsModel);
        }

        [HttpPost]
        public ActionResult DeletedConfirm(int id)
        {

           var result =  unitOfWork.GetRepositoryInstance<Tbl_Product>().Remove(id);
            if (result == true)
            { return RedirectToAction("Index" ); }
            else
                return View();
        }

        public string SaveImage(HttpPostedFileBase httpPostedFileBase, string currentImage = "")
        {
            if (httpPostedFileBase != null)
            {
                var fileExtenction = Path.GetExtension(httpPostedFileBase.FileName);
                var imageGuid = Guid.NewGuid().ToString();
                var GuidFullPath = imageGuid + fileExtenction;
                var imageFullPath = Server.MapPath($"~/Uploads/Images/{GuidFullPath}");
                httpPostedFileBase.SaveAs(imageFullPath);
                if (!string.IsNullOrEmpty(currentImage))
                {
                    var currentImageMapped = Server.MapPath($"~/Uploads/Images/{currentImage}");
                    System.IO.File.Delete(currentImageMapped);

                }

                return GuidFullPath;
            }
            return currentImage;
        }

        public void InitalizeList(ref ProductModel model) 
        {
            // initialize all Categories DropDownist for Create 
            var ListOfCategories = unitOfWork.GetRepositoryInstance<Tbl_Category>().GetAllRecordes();
            SelectList Categories = new SelectList(ListOfCategories, "CategoryId","CategoryName");
            model.Categories = Categories;

            SelectList selectListsForChoices = new SelectList(new List<SelectListItem> {
             new SelectListItem{ Text="--Select Option--" , Value = ((bool)false).ToString() , Selected=true },
            new SelectListItem{ Text="Yes" , Value = ((bool)true).ToString() },
               new SelectListItem{ Text="No" , Value = ((bool)false).ToString() }

            }, "Value" , "Text");

            model.Chooices = selectListsForChoices;

        }





    }
}