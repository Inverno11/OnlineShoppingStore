using AutoMapper;
using OnlineShoppingStore.App_Start;
using OnlineShoppingStore.DatabasesModel;
using OnlineShoppingStore.Models.EntitesModel;
using OnlineShoppingStore.Repository;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineShoppingStore.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category

        GenericUnitOfWork unitOfWork;
        IMapper Mapper;

        public CategoryController()
        {

            unitOfWork = new GenericUnitOfWork();
            Mapper = AutoMapperConfig.Mapper;

        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CategoryModel model)
        {
            var Category = Mapper.Map<Tbl_Category>(model);
            unitOfWork.GetRepositoryInstance<Tbl_Category>().Add(Category);

            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {

            var listOfCategory = unitOfWork.GetRepositoryInstance<Tbl_Category>().GetAllRecordes();

            var ListOfCategoryModels = Mapper.Map<List<CategoryModel>>(listOfCategory);
           


            return View(ListOfCategoryModels);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var CategoryWillEdited = unitOfWork.GetRepositoryInstance<Tbl_Category>().GetFirstorDefault(id);
            var CategoryWillEditedModel = Mapper.Map<CategoryModel>(CategoryWillEdited);
            return View(CategoryWillEditedModel);
        }

        [HttpPost]
        public ActionResult Edit(CategoryModel categoryModel)
        {

            var modelAfterEdit = Mapper.Map<Tbl_Category>(categoryModel);
             unitOfWork.GetRepositoryInstance<Tbl_Category>().Update(modelAfterEdit);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id) 
        {
            var CategoryDetails= unitOfWork.GetRepositoryInstance<Tbl_Category>().GetFirstorDefault(id);
            var CategoryModelsDetails = Mapper.Map<CategoryModel>(CategoryDetails);
            return View(CategoryModelsDetails);

        }





    }
}