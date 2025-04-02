using CodeAcademy.DTO;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CodeAcademy.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CarController : ControllerBase
    {
        private static readonly List<CarDto> Cars = new List<CarDto>()
            {
                new CarDto{
                    Brand = CarBrand.Audi,
                    Color = "Red",
                    Id = 1,
                    Name = "Q7",
                    Price = 10_000
                },
                new CarDto{
                    Brand = CarBrand.BMW,
                    Color = "Blue",
                    Id = 2,
                    Name = "x5",
                    Price = 100_000
                },
                new CarDto{
                    Brand = CarBrand.VW,
                    Color = "Pink",
                    Id = 3,
                    Name = "Golf",
                    Price = 1_100_000
                }
            };


        [HttpGet(Name = "GetCarById")]
        [ProducesResponseType<CarDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CarDto> GetCarById([FromQuery, SwaggerParameter("Search id", Required = true)] int id)
        {
            var carResult = Cars.FirstOrDefault(car => car.Id == id);
            return carResult == null ? NotFound() : Ok(carResult);
        }

        [HttpGet(Name = "GetAllCars")]
        public ActionResult<List<CarDto>> GetAllCars()
        {
            return Ok(Cars);
        }

        [HttpDelete(Name = "DeleteCar")]
        public ActionResult DeleteCar([FromQuery, SwaggerParameter("Car id", Required = true)] int id)
        {
            Cars.RemoveAll(car => car.Id == id);
            //Should implement more business logic here to check if the car exist and return a correct response.
            return Ok();
        }

        [HttpPost(Name = "UpdateCar")]
        public ActionResult<CarDto> UpdateCar(CarDto car)
        {
            //Business logic
            return Ok(car);
        }

        [HttpGet(Name = "GetCarsBasedOnPrice")]
        public ActionResult<List<CarDto>> GetCarsBasedOnPrice([FromQuery, SwaggerParameter("Find cars with lower price", Required = true)] int price)
        {
            return Ok(Cars.Where(car => car.Price <= price).ToList());
        }

        [HttpGet(Name = "GetCarBasedOnBrand")]
        public ActionResult<List<CarDto>> GetCarBasedOnBrand(CarBrand carBrand)
        {
            return Ok(Cars.Where(car => car.Brand == carBrand).ToList());
        }
    }
}
