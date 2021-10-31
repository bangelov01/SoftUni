using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class User
    {
        public User()
        {
            Bets = new HashSet<Bet>();
        }

        [Key]
        public int UserId { get; set; }

        public decimal Balance { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(75)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(75)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(256)")]
        public string Password { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Username { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }
    }
}
