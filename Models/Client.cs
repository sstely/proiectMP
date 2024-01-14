using System.ComponentModel.DataAnnotations;

namespace proiectMP.Models
{
    public class Client
    {
        public int ID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-z\s]*$", ErrorMessage = "First Name should start with capital letter (eg: Jo or Jo Nas or Jo-Nas)")]
        [StringLength(30, MinimumLength = 2)]
        public string? FirstName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-z\s]*$", ErrorMessage = "Last Name should start with capital letter (eg: Liu or Liu Kang or Liu-Kang)")]
        [StringLength(30, MinimumLength = 2)]
        public string? LastName { get; set; }

        [EmailAddress(ErrorMessage = "Enter a valid email format")]
        [StringLength(80)]
        public string Email { get; set; }

        [Phone(ErrorMessage = " Enter a valid phone number")]
        public string? Phone { get; set; }

        [Display(Name = "Full Name")]
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public ICollection<Comment>? Comments { get; set; }

        public ICollection<Reservation>? Reservations { get; set; }
    }
}
