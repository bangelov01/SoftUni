namespace SMS.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Data.Constants.DataConstants;

    public class Product
    {
        public Product()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required, MaxLength(ProductNameMaxLength)]
        public string Name { get; set; }

        [Range(typeof(decimal), PriceMinValue, PriceMaxValue)]
        public decimal Price { get; set; }

        [ForeignKey(nameof(Cart))]
        public string CartId { get; set; }

        public virtual Cart Cart { get; set; }
    }
}
