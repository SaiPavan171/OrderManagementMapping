using AutoMapper;
using OrderManagement.DataAccess.Entites;
using OrderManagement.Models.DTO;

namespace OrderManagement.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductPublicDto>()
                .ForMember(dest => dest.EffectivePrice,
                    opt => opt.MapFrom(src =>
                        src.DiscountPercent > 0
                         ? src.Price - (src.Price * src.DiscountPercent / 100)
                         : src.Price))
                .ForMember(dest => dest.IsDiscounted,
                opt => opt.MapFrom(src =>
                src.DiscountPercent >= 10
                ? true : false))
                .ForMember(dest => dest.StockStatus,
                opt => opt.MapFrom(src =>
                src.Stock <= 0 ? "OUT_OF_STOCK"
                : src.Stock < 5 ? "LOW_STOCK"
                : "IN_STOCK"))
                .ForMember(dest => dest.CategoryName,
                opt => opt.MapFrom(src =>
                src.Category == null
                ? "Unavailable"
                : src.Category.IsActive == false ? "Unavailable" : "Available"))
                ;
            CreateMap<Product, ProductAdminDto>()
                .ForMember(dest => dest.CategoryName,
                opt => opt.MapFrom(src =>
                src.Category == null
                ? "N/A"
                : src.Category.Name));

            // Fix: store the mapping expression in a variable so that subsequent calls
            // (ForMember, ForAllMembers, AfterMap) are invoked on the same expression.
            var map = CreateMap<ProductUpdateDto, Product>();
            map.ForMember(dest => dest.Id, opt => opt.Ignore());
            map.ForAllMembers(opt =>
                opt.Condition((src, dest, srcMember) => srcMember != null));
            map.AfterMap((src, dest) =>
            {
                if (dest.DiscountPercent < 0)
                {
                    dest.DiscountPercent = 0;
                }
            });

            CreateMap<OrderCreateDto, Order>()
                .ForMember(dest => dest.ProductIds,
                opt => opt.MapFrom(src =>
                string.Join(",", src.ProductIds)))
                .ForMember(dest=>dest.Status , 
                opt=>opt.MapFrom(src=>
                "Pending"))
                .ForMember(dest=>dest.CreatedAt,
                opt=>opt.MapFrom(src=>
                DateTime.UtcNow.ToString()))
                .ForMember(dest=>dest.TotalAmount,
                opt=>opt.MapFrom(src=>
                100))
                ;
            CreateMap<ProductCreateDto, Product>();
            CreateMap<Order , OrderDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryCreate, Category>();


        }
    }
}
