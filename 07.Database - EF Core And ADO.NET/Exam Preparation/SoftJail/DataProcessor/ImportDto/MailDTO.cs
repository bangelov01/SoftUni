using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto
{
    public class MailDTO
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public string Sender { get; set; }
        [Required, RegularExpression(@"^[\d\w\s]+ str.$")]
        public string Address { get; set; }
    }
}
