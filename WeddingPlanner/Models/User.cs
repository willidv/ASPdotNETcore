using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace WeddingPlanner.Models
{
    public class User : BaseEntity
    {
        public int UserId {get; set;}

        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        public string Email {get; set;}

        public string Password {get; set;}
        public User()
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
    public class Guest : BaseEntity
    {
         public int GuestId {get; set;}
         public int WeddingId {get; set;}
         public Wedding Wedding{get; set;}

         public int UserId{get; set;}
         public User User{get; set;}
         public DateTime created_at {get; set;}
        public DateTime updated_at {get; set;}
    }
    public class Wedding : BaseEntity
    {
        public Wedding()
        {
            Guests = new List<Guest>();
        }
        public int WeddingId {get; set;}

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        [Display(Name = "Wedder One")]
        public string Wedder_One {get; set;}
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        [Display(Name = "Wedder Two")]
        public string Wedder_Two {get; set;}

        [Required]
        [Display(Name = "Date")]
        public DateTime Date {get; set;}

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        [Display(Name = "Address")]
        public string Address {get; set;}
        public List<Guest> Guests {get; set;}
        public DateTime created_at {get; set;}
        public DateTime updated_at {get; set;}

    }

     public class WrapperVM
    {
        public RegisterViewModel RegisterVM { get; set; }
        public LoginViewModel LogUser { get; set; }
        public Wedding Wedding { get; set; }
        public Guest Guest {get; set;}
    }
}