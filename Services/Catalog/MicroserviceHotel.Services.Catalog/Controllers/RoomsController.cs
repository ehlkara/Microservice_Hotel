using MicroserviceHotel.Services.Catalog.Dtos;
using MicroserviceHotel.Services.Catalog.Services;
using MicroserviceHotel.Shared.ControllerBases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceHotel.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : CustomBaseController
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _roomService.GetAllAsync();

            return CreateActionResultInstance(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await _roomService.GetByIdAsync(id);

            return CreateActionResultInstance(response);
        }

        [HttpGet]
        [Route("/api/[controller]/GetAllByCustomerId/{customerId}")]
        public async Task<IActionResult> GetAllByCustomerId(string customerId)
        {
            var response = await _roomService.GetAllByCustomerIdAsync(customerId);

            return CreateActionResultInstance(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoomCreateDto roomCreateDto)
        {
            var response = await _roomService.CreateAsync(roomCreateDto);

            return CreateActionResultInstance(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(RoomUpdateDto roomUpdateDto)
        {
            var response = await _roomService.UpdateAsync(roomUpdateDto);

            return CreateActionResultInstance(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _roomService.DeleteAsync(id);

            return CreateActionResultInstance(response);
        }
    }
}
