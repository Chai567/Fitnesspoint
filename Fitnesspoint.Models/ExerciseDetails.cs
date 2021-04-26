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
        public int exerciseid { get; set; }
        public string exercisetype { get; set; }
        public string exercisefor { get; set; }
        public int totalset { get; set; }
        public string rest { get; set; }
        public string focus { get; set; }
        public string equipement { get; set; }
        public string time { get; set; }
        public string exercisename { get; set; }

        public List<ExerciseDetails> productlist { get; set; }
    }
}
