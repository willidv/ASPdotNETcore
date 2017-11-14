using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;


namespace restauranter.Models
{   
    public class Review : BaseEntity
    {
        public int id {get; set;}
        
        [Required]
        [MinLength(4)]
        [Display(Name = "Reviewer Name")]
        public string Reviewer_Name { get; set; }

        [Display(Name = "Restaurant Name")]
        public string Restaurant_Name { get; set; }

        [Display(Name = "Review")]
        public string Opinion { get; set; }

        [Required]
        [Display(Name = "Date of Visit")]
        public DateTime date_visited {get; set;}

        [Required]
        [Range(1, 5)]
        [Display(Name = "Stars")]
        public int stars {get; set;}
    }
}