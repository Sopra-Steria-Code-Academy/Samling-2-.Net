using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CarBrand
    {
        BMW,
        Audi,
        VW,
        Tesla
    }
}
