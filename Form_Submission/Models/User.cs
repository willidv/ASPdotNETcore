using System.ComponentModel.DataAnnotations;

namespace Form_Submission.Models
{
    public abstract class BaseEntity {}
    
    public class User : BaseEntity
    {
        [Required]
        [MinLength(4)]
        public string First_Name { get; set; }

        [Required]
        [MinLength(4)]
        public string Last_Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Email {get; set;}

        [Required]
        [MinLength(8)]
        public string Password {get; set;}
    }
}