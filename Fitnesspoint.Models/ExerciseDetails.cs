using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Fitnesspoint.Models
{
    public class ExerciseDetails
    {
        public int Exerciseid { get; set; }
        public string Exercisetype { get; set; }
        public string Exercisefor { get; set; }
        public int Totalset { get; set; }
        public string Rest { get; set; }
        public string Focus { get; set; }
        public string Equipement { get; set; }
        public string Time { get; set; }
        public string Exercisename { get; set; }

        public List<ExerciseDetails> Productlist { get; set; }
    }
}
