using AutoMapper;
using OnlineShoppingStore.App_Start;
using OnlineShoppingStore.DatabasesModel;
using OnlineShoppingStore.Models.EntitesModel;
using OnlineShoppingStore.Repository;
using PagedList;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace OnlineShoppingStore.Models
{

    public class HomeIndexViewModel
    {
        public GenericUnitOfWork unitOfWork;
        IMapper Mapper;
        dbMyOnlineShoppingEntities db;
        public IPagedList<ProductModel> ListOfProducts { get; set; }

        public HomeIndexViewModel()
        {


            unitOfWork = new GenericUnitOfWork();
            Mapper = AutoMapperConfig.Mapper;
            db = new dbMyOnlineShoppingEntities();

        }

        public HomeIndexViewModel CreateModel(string search, int pageSize, int? page) 
        {

            SqlParameter[] parametes = new SqlParameter[] { new SqlParameter("@search", search)
                };


            var tbl_Products = db.Database.SqlQuery<Tbl_Product>("GetBySearch @search", parametes).ToList();

            var list = Mapper.Map<IEnumerable<ProductModel>>(tbl_Products);
            ListOfProducts = list.ToPagedList(page ?? 1, pageSize); ;


            return new HomeIndexViewModel { ListOfProducts = ListOfProducts };




        }



    }
}