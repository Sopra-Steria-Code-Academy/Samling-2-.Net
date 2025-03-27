using CodeAcademy.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CodeAcademy.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CarController
    {
        [HttpGet(Name = "GetCar")]
        public CarDto GetCarById()
        {
            return new CarDto
            {
                Brand = CarBrand.Audi,
                Color = "Red",
                Id = 1,
                Name = "Q7",
                Price = 10000
            };
        }
    }
}
