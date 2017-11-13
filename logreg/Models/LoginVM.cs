using System.ComponentModel.DataAnnotations;

namespace logreg.Models
{   
    public class LoginVM : BaseEntity
    {
        [Required]
        public string LogEmail {get; set;}

        [Required]
        [MinLength(8)]
        public string LogPassword {get; set;}
    }
}