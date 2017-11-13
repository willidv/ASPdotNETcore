using System.ComponentModel.DataAnnotations;

namespace logreg.Models
{
    public class HPusers
    {
        public User Reguser { get; set; }
        public LoginVM LogUser { get; set; }
    }
}