using CarDealer.DTO.Export.CarsWithListOfPartsDtos;
using Newtonsoft.Json;

namespace CarDealer.DTO.Export.SalesWithDiscountDtos
{
    public class SaleWithDiscountDto
    {
        [JsonProperty(PropertyName = "car")]
        public CarDto Car { get; set; }

        [JsonProperty(PropertyName = "customerName")]
        public string CustomerName { get; set; }
        public string Discount { get; set; }

        [JsonProperty(PropertyName = "price")]
        public string Price { get; set; }

        [JsonProperty(PropertyName = "priceWithDiscount")]
        public string PriceWithDiscount => (decimal.Parse(Price) - (decimal.Parse(Price) * decimal.Parse(Discount)/100)).ToString("f2");
    }
}
