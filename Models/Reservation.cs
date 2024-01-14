using System.ComponentModel.DataAnnotations;

namespace proiectMP.Models
{
    public class Reservation
    {
        public int ID { get; set; }

        public int? ClientID { get; set; }

        public Client? Client { get; set; }

        [Range(1, 20, ErrorMessage = "Too many people. It can't be more than 20")]
        public int NumberPeople { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReservationDate { get; set; }
    }
}
