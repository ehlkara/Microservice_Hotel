using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceHotel.Services.Basket.Dtos
{
    public class BasketItemDto
    {
        public int Quantity { get; set; }

        public string HotelId { get; set; }
        public string HotelName { get; set; }

        public decimal Price { get; set; }
    }
}
