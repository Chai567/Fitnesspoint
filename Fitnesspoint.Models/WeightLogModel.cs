using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Fitnesspoint.Models
{
    //Created class WeightLogModel which represents the database table NutritionPlan
    public class WeightLogModel
    {

        /*Table WeightLog has columns WeightId, Weight 
         * Created_At, Updated_At and UserId.
         * Class WeightLogModel has properties WeightId, Weight 
         * Created_At, Updated_At and UserId corresponding to the columns name in the database
         */

        [Key]    //WeightId is Primary Key
        public int WeightId { get; set; }

        //Weight is required. Weight must have value b/w 2 and 300.
        [Required(ErrorMessage = "Weight of the person is required.")]
        [Range(2, 300, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Weight { get; set; }

        //Created_At is required.
        [Required]
        public System.DateTime Created_At { get; set; }

        //Updated_At is required.
        [Required]
        public System.DateTime Updated_At { get; set; }

        //UserId is required.

        //Display UserID as User Id
        [Display(Name = "User Id")]
        public int? UserId { get; set; }

        public virtual UserModel User { get; set; }
    }

}