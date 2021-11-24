using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftJail.Data.Models
{
    public class Prisoner
    {
        public Prisoner()
        {
            Mails = new HashSet<Mail>();
            PrisonerOfficers = new HashSet<OfficerPrisoner>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        //[MinLength(3)] -- client
        [MaxLength(20)]
        public string FullName { get; set; }

        [Required]
        //[RegularExpression(@"^The [A-Z]{1}[a-z]+$")] -- client
        public string Nickname { get; set; }

        //[Range(18,65)] -- client
        public int Age { get; set; }
        public DateTime IncarcerationDate { get; set; }
        public DateTime? ReleaseDate { get; set; }

        //[Range(typeof(decimal), "0", "79228162514264337593543950335")] -- client
        public decimal? Bail { get; set; }

        [ForeignKey(nameof(Cell))]
        public int? CellId { get; set; }
        public virtual Cell Cell { get; set; }

        public virtual ICollection<Mail> Mails { get; set; }
        public virtual ICollection<OfficerPrisoner> PrisonerOfficers { get; set; }
    }
}