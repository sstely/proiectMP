using System.ComponentModel.DataAnnotations;

namespace proiectMP.Models
{
    public class Comment
    {
        public int ID { get; set; }

        public int? ClientID { get; set; }

        public Client? Client { get; set; }

        [StringLength(200,ErrorMessage = "Text is too long. It can't be more than 200")]
        public string Text { get; set; }


        [DataType(DataType.Date)]
        public DateTime PostDate { get; set; }
    }
}
