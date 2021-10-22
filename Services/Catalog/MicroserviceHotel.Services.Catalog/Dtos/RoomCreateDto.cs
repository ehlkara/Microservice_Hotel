using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceHotel.Services.Catalog.Dtos
{
    public class RoomCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Picture { get; set; }
        public string CustomerId { get; set; }
        public BodyCountDto BodyCount { get; set; }
        public string CategoryId { get; set; }
    }
}
