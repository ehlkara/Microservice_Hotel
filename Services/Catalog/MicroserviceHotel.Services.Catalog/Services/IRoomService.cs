using MicroserviceHotel.Services.Catalog.Dtos;
using MicroserviceHotel.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceHotel.Services.Catalog.Services
{
    public interface IRoomService
    {
        Task<Response<List<RoomDto>>> GetAllAsync();

        Task<Response<RoomDto>> GetByIdAsync(string id);

        Task<Response<List<RoomDto>>> GetAllByCustomerIdAsync(string customerId);

        Task<Response<RoomDto>> CreateAsync(RoomCreateDto roomCreateDto);

        Task<Response<NoContent>> UpdateAsync(RoomUpdateDto roomUpdateDto);

        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
