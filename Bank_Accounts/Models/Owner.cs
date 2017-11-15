using System.ComponentModel.DataAnnotations;

namespace Bank_Accounts.Models
{
    public class Owner : BaseEntity
    {
        public int id {get; set;}

        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        public string Email {get; set;}

        public string Password {get; set;}
        public Owner()
        {

        }
    }
    public class RegisterViewModel : BaseEntity{

        public int id {get; set;}

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        [Display(Name = "First Name")]
        public string First_Name {get; set;}

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        [Display(Name = "Last Name")]
        public string Last_Name {get; set;}

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email {get; set;}

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password {get; set;}  

        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password Confirmation")]
        public string Password_Confirmation {get; set;}
    }

    public class LoginViewModel : BaseEntity
    {
        [Required]
        public string LogEmail {get; set;}

        [Required]
        public string LogPassword {get; set;}
    }
    public class TransactionModel : BaseEntity
    {
        public int id {get; set;}
        public int Account_id {get; set;}
        public int withdrawl {get; set;}
        public int deposit {get; set;}
    }
     public class WrapperVM
    {
        public RegisterViewModel RegisterVM { get; set; }
        public LoginViewModel LogUser { get; set; }
        public TransactionModel Transaction {get; set;} 
    }
}