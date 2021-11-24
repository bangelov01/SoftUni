﻿using SoftJail.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftJail.Data.Models
{
    public class Officer
    {
        public Officer()
        {
            OfficerPrisoners = new HashSet<OfficerPrisoner>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        //[MinLength(3)] -- client
        [MaxLength(30)]
        public string FullName { get; set; }

        [Required]
        //[Range(typeof(decimal), "0", "79228162514264337593543950335")] -- client
        public decimal Salary { get; set; }
        public Position Position { get; set; }
        public Weapon Weapon { get; set; }

        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<OfficerPrisoner> OfficerPrisoners { get; set; }
    }
}
