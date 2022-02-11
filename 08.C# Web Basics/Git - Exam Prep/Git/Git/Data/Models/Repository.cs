namespace Git.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Git.Data.Constatnts.DataConstants;

    public class Repository
    {
        public Repository()
        {
            this.Commits = new HashSet<Commit>();
        }

        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required, MaxLength(REPOSITORY_NAME_MAX_LENGTH)]
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public bool IsPublic { get; set; }

        [ForeignKey(nameof(Owner))]
        public string OwnerId { get; set; }

        public virtual User Owner { get; set; }

        public virtual ICollection<Commit> Commits { get; set; }
    }
}
