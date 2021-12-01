using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class CardDTO
    {
        [Required, RegularExpression(@"^[\d]{4} [\d]{4} [\d]{4} [\d]{4}$")]
        public string Number { get; set; }
        [Required, RegularExpression(@"^[\d]{3}$")]
        public string CVC { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
