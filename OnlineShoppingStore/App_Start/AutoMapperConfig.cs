using AutoMapper;
using OnlineShoppingStore.DatabasesModel;
using OnlineShoppingStore.Models.EntitesModel;

namespace OnlineShoppingStore.App_Start
{
    public static class AutoMapperConfig 
    {

        public static IMapper Mapper { set; get; }

        public static void Init()
        {


            MapperConfiguration Config = new MapperConfiguration(config => { config.CreateMap<Tbl_Category, CategoryModel>().ReverseMap();
                config.CreateMap<Tbl_Product, ProductModel>().
                ForMember(dest => dest.CategoryName, src => src.MapFrom(s => s.Tbl_Category.CategoryName))
                .ReverseMap();
                config.CreateMap<Tbl_BasketLine, BasketLineModel>().ForMember(des => des.MemberId, src => src.MapFrom(s => s.AspNetUser.Id))
                .ForMember(des => des.ProductId, src => src.MapFrom(s => s.Tbl_Product.ProductId))
                .ForMember(des => des.ProductModel, src => src.MapFrom(s => s.Tbl_Product))
                .ReverseMap();
                config.CreateMap<Tbl_ShippingDetails, ShippingModel>().ReverseMap();
                                
                }

            
            );
               
                ;

            Mapper = Config.CreateMapper();

        }
    }
}