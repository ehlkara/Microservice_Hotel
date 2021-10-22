using MicroserviceHotel.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceHotel.Shared.ControllerBases
{
    public class CustomBaseController : ControllerBase
    {
        public IActionResult CreateActionResultInstance<T>(Response<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}