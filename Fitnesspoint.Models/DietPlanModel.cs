using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Fitnesspoint.Models
{
        //Created class DietPlanModel which represents the database table DietPlan
        public class DietPlanModel
        {
            /*Table DietPlan has columns DietId, Slots 
            * FoodType, FatRatio, CarbsRatio, ProteinRatio,
            * TotalCalorie and UserId.
            * Class DietPlanModel has properties DietId, Slots 
            * FoodType, FatRatio, CarbsRatio, ProteinRatio,
            * TotalCalorie and UserId corresponding to the columns name in the database
            */

            [Key] //DietId is Primary Key
            public int DietId { get; set; }

            //Slots is required. Slots must have value b/w 1 and 10.
            [Required(ErrorMessage = "Slots in the diet plan is required.")]
            [Range(2, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
            public int Slots { get; set; }

            //FoodType is required.
            [Required(ErrorMessage = "Food Type in the diet plan is required.")]
            [Display(Name = "Food Type")]
            public string FoodType { get; set; }

            //FatRatio is required.
            [Required(ErrorMessage = "Fat Ratio in the diet plan is required.")]
            [Range(2, 2000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
            [Display(Name = "Fat Ratio")]
            public int FatRatio { get; set; }

            //CarbsRatio is required.
            [Required(ErrorMessage = "Carbs Ratio in the diet plan is required.")]
            [Range(2, 2000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
            [Display(Name = "Carbs Ratio")]
            public int CarbsRatio { get; set; }

            //ProteinRatio is required.
            [Required(ErrorMessage = "Protein Ratio in the diet plan is required.")]
            [Range(2, 2000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
            [Display(Name = "Protein Ratio")]
            public int ProteinRatio { get; set; }

            //TotalCalorie is required.
            [Required]
            [Display(Name = "Total Calorie")]
            public int TotalCalorie { get; set; }

            //UserId is required.
            [Required(ErrorMessage = "User Id is required.")]
            //Display UserID as User Id
            [Display(Name = "User Id")]
            public int UserId { get; set; }

            public virtual UserModel User { get; set; }
        }
}
