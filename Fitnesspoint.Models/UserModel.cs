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


        [Required(ErrorMessage = "Enter your Gender")]
        public string Gender { get; set; }


        [Required(ErrorMessage = "Enter your Date of birth")]
        public System.DateTime DOB { get; set; }


        [Required(ErrorMessage = "Enter your Weight")]
        public int Weight { get; set; }


        [Required(ErrorMessage = "Enter your Height")]
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
        public long Contact { get; set; }

    }
}
