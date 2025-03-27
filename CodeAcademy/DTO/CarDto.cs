using System.ComponentModel.DataAnnotations;

namespace CodeAcademy.DTO
{
    public class CarDto
    {
        public int Id { get; set; }

        [EnumDataType(typeof(CarBrand))]
        public CarBrand Brand { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public string Color { get; set; }
    }

    public enum CarBrand
    {
        BMW = 1,
        Audi = 2,
        VW = 3,
        Tesla = 4
    }
}
