namespace SharedTrip.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserTrip
    {
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        [ForeignKey(nameof(Trip))]
        public string TripId { get; set; }

        public virtual Trip Trip { get; set; }
    }
}
