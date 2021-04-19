using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Fitnesspoint.Models
{
    //Created class NutritionPlanModel which represents the database table NutritionPlan
    public class NutritionPlanModel
    {
        /*Table NutritionPlan has columns NutriPlanId, Name, PlanDescription, 
        * Created_At, Updated_At and Price.
        * Class NutritionPlanModel has properties NutriPlanId, Name, PlanDescription, 
        * Created_At, Updated_At and Price corresponding to the columns name in the database
        */


        [Key]   //NutriPlanId is Primary Key
        public int NutriPlanId { get; set; }

        //Name is required. Name must have length b/w 3 and 100 characters.
        [Required(ErrorMessage = "Name of the plan is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name of the plan should have minimum 3 characters and maximum 100 characters")]
        public string Name { get; set; }

        //PlanDescription is required. PlanDescription must have length b/w 10 and 300 characters.
        [Required(ErrorMessage = "Description of the plan is required.")]
        [StringLength(300, MinimumLength = 10, ErrorMessage = "Description of the plan should have minimum 10 characters and maximum 300 characters")]
        //PlanDescription have multiple lines
        [DataType(DataType.MultilineText)]
        //Display PlanDescription as Plan Description
        [Display(Name = "Plan Description")]
        public string PlanDescription { get; set; }

        //Created_At is required.
        [Required]
        public System.DateTime Created_At { get; set; }

        //Updated_At is required.
        [Required]
        public System.DateTime Updated_At { get; set; }

        //Price is required. Price must have value b/w 10 and 100000.
        [Required(ErrorMessage = "Price of the plan is required.")]
        [Range(10, 100000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Price { get; set; }

    }
}
