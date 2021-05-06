using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Fitnesspoint.Models
{
    public class UserModel
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Enter your name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Select your Gender")]
        public string Gender { get; set; }


        [Required(ErrorMessage = "Enter your Date of birth")]
        [MinimumAge(16,ErrorMessage ="You must be atleast 16 years old.")]
        public System.DateTime DOB { get; set; }


        [Required(ErrorMessage = "Enter your Weight")]
        [Range(50,120,ErrorMessage ="Enter a weight between 50 and 120 kgs")]
        public int Weight { get; set; }


        [Required(ErrorMessage = "Enter your Height")]
        [Range(152,219,ErrorMessage ="Enter a height between 152 and 219 cms")]
        public int Height { get; set; }

        public string MedicalCondition { get; set; }

        public string AllergicTo { get; set; }

        [Required(ErrorMessage = "Enter your Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Choose a Username")]
        public string Username { get; set; }


        [Required(ErrorMessage = "Choose a Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Role { get; set; }

        public string Goal { get; set; }

        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public long Contact { get; set; }

    }
}
