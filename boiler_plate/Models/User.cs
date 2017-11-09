using System.ComponentModel.DataAnnotations;

namespace boiler_plate.Models
{    
    public abstract class BaseEntity {}


public class User : BaseEntity
    {
        [Required]
        [MinLength(4)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(4)]
        public string LastName { get; set; }
    }
    }
}