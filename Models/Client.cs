using System.ComponentModel.DataAnnotations;

namespace proiectMP.Models
{
    public class Client
    {
        public int ID { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string Email { get; set; }

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
    }
}
