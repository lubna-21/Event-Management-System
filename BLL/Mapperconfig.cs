using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;

namespace BLL
{
    public class Mapperconfig
    {
            public static MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Admin, AdminDTO>().ReverseMap();
                cfg.CreateMap<User, UserDTO>().ReverseMap();
                cfg.CreateMap<EventCategory, EventCategoryDTO>().ReverseMap();
                cfg.CreateMap<Booking, BookingDTO>()
                   .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User != null ? src.User.FullName : ""))
                   .ForMember(dest => dest.EventCategoryName, opt => opt.MapFrom(src => src.EventCategory != null ? src.EventCategory.Name : ""))
                   .ForMember(dest => dest.EventPrice, opt => opt.MapFrom(src => src.EventCategory != null ? src.EventCategory.Price : 0))
                   .ReverseMap();
            });

            public static Mapper GetMapper()
            {
                return new Mapper(config);
            }
        }
    }

