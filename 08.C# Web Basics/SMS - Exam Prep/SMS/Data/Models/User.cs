namespace SMS.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Data.Constants.DataConstants;

    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required, MaxLength(UsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [ForeignKey(nameof(Cart))]
        public string CartId { get; set; }

        public virtual Cart Cart { get; set; }
    }
}
