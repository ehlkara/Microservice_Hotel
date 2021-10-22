using AutoMapper;
using MicroserviceHotel.Services.Catalog.Dtos;
using MicroserviceHotel.Services.Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceHotel.Services.Catalog.Mapping
{
    public class GeneralMapping: Profile
    {
        public GeneralMapping()
        {
            CreateMap<Room, RoomDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<BodyCount, BodyCountDto>().ReverseMap();

            CreateMap<Room, RoomCreateDto>().ReverseMap();
            CreateMap<Room, RoomUpdateDto>().ReverseMap();
        }
    }
}
