﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto
{
    public class ImportPrisonersAndMailsDTO
    {
        [Required, MinLength(3), MaxLength(20)]
        public string FullName { get; set; }
        [Required, RegularExpression(@"^The [A-Z]{1}[a-z]+$")]
        public string Nickname { get; set; }
        [Range(18, 65)]
        public int Age { get; set; }
        [Required]
        public string IncarcerationDate { get; set; }
        public string ReleaseDate { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal? Bail { get; set; }
        public virtual IEnumerable<MailDTO> Mails { get; set; }
    }
}
