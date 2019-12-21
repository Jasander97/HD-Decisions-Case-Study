using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Authorization;


namespace HD_Decisions_Case_Study.Models
{
    public class FormData
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Display(Name = "Annual Income")]
        [Required(ErrorMessage = "Please enter your annual income before tax")]
        public int AnnualIncome { get; set; }
       
        [Display(Name = "Date of Birth")]
        [DataType (DataType.Date)]
        [Required(ErrorMessage = "Please enter your date of birth")]
        [MinimumAge(18)]
        public DateTime DateOfBirth { get; set; }


    }

}
