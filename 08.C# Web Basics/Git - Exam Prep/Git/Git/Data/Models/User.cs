namespace Git.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static Git.Data.Constatnts.DataConstants;

    public class User
    {
        public User()
        {
            this.Repositories = new HashSet<Repository>();
            this.Commits = new HashSet<Commit>();
        }

        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required, MaxLength(USERNAME_MAX_LENGTH)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual ICollection<Repository> Repositories { get; set; }

        public virtual ICollection<Commit> Commits { get; set; }
    }
}
