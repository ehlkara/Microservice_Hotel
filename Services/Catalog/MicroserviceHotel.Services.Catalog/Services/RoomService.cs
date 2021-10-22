using AutoMapper;
using MicroserviceHotel.Services.Catalog.Dtos;
using MicroserviceHotel.Services.Catalog.Models;
using MicroserviceHotel.Services.Catalog.Settings;
using MicroserviceHotel.Shared.Dtos;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceHotel.Services.Catalog.Services
{
    public class RoomService : IRoomService
    {
        private readonly IMongoCollection<Room> _roomCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public RoomService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);

            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _roomCollection = database.GetCollection<Room>(databaseSettings.RoomCollectionName);

            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);

            _mapper = mapper;
        }

        public async Task<Response<RoomDto>> CreateAsync(RoomCreateDto roomCreateDto)
        {
            var newRoom = _mapper.Map<Room>(roomCreateDto);

            newRoom.CreatedTime = DateTime.Now;
            await _roomCollection.InsertOneAsync(newRoom);

            return Response<RoomDto>.Success(_mapper.Map<RoomDto>(newRoom), 200);
        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            var result = await _roomCollection.DeleteOneAsync(x => x.Id == id);

            if(result.DeletedCount > 0)
            {
                return Response<NoContent>.Success(204);
            }
            else
            {
                return Response<NoContent>.Fail("Room not found", 404);
            }
        }

        public async Task<Response<List<RoomDto>>> GetAllAsync()
        {
            var rooms = await _roomCollection.Find(room => true).ToListAsync();

            if(rooms.Any())
            {
                foreach (var room in rooms)
                {
                    room.Category = await _categoryCollection.Find<Category>(x => x.Id == room.CategoryId).FirstAsync();
                }
            }
            else
            {
                rooms = new List<Room>();
            }

            return Response<List<RoomDto>>.Success(_mapper.Map<List<RoomDto>>(rooms), 200);
        }

        public async Task<Response<List<RoomDto>>> GetAllByCustomerIdAsync(string customerId)
        {
            var rooms = await _roomCollection.Find<Room>(x => x.CustomerId == customerId).ToListAsync();

            if(rooms.Any())
            {
                foreach (var room in rooms)
                {
                    room.Category = await _categoryCollection.Find<Category>(x => x.Id == room.CategoryId).FirstAsync();
                }
            }
            else
            {
                rooms = new List<Room>();
            }

            return Response<List<RoomDto>>.Success(_mapper.Map<List<RoomDto>>(rooms), 200);
        }

        public async Task<Response<RoomDto>> GetByIdAsync(string id)
        {
            var room = await _roomCollection.Find<Room>(x => x.Id == id).FirstOrDefaultAsync();

            if(room == null)
            {
                return Response<RoomDto>.Fail("Room not found", 404);
            }
            room.Category = await _categoryCollection.Find<Category>(x => x.Id == room.CategoryId).FirstAsync();

            return Response<RoomDto>.Success(_mapper.Map<RoomDto>(room), 200);
        }

        public async Task<Response<NoContent>> UpdateAsync(RoomUpdateDto roomUpdateDto)
        {
            var updateRoom = _mapper.Map<Room>(roomUpdateDto);

            var result = await _roomCollection.FindOneAndReplaceAsync(x => x.Id == roomUpdateDto.Id, updateRoom);

            if(result == null)
            {
                return Response<NoContent>.Fail("Room not found", 404);
            }

            return Response<NoContent>.Success(204);
        }
    }
}


// Serviceler,Dtos,Model,Mapping ve Settingsi yazdın. Controllers, appsettings ve startuptan devam et!