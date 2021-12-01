﻿using System.ComponentModel.DataAnnotations;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportGameDTO
    {
        [Required]
        public string Name { get; set; }
        [Range(0, (double)decimal.MaxValue)]
        public decimal Price { get; set; }
        [Required]
        public string ReleaseDate { get; set; }
        [Required]
        public string Developer { get; set; }
        [Required]
        public string Genre { get; set; }
        [MinLength(1)]
        public string[] Tags { get; set; }

    }
}
