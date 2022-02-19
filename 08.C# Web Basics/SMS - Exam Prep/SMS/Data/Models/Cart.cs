namespace SMS.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Cart
    {
        public Cart()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Products = new HashSet<Product>();
        }

        [Key]
        public string Id { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
