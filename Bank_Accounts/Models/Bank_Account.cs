using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;


namespace Bank_Accounts.Models
{   
    public class Bank_Account : BaseEntity
    {
        public int id {get; set;}
        public int owner_id {get; set;}
        
        [Required]
        [MinLength(4)]
        [Display(Name = "Account Holder")]
        public string User_Name { get; set; }

        [Required]
        [Display(Name = "Account Balance")]
        public int Account_Balance {get; set;}

        [Required]
        [Display(Name = "Opened On")]
        public DateTime created_at {get; set;}

        [Required]
        [Display(Name = "last visited")]
        public DateTime updated_at {get; set;}
    }
}