using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnesspoint.Models
{
    public class PaymentModel
    {
        public int Order_id { get; set; }
        public int? User_id { get; set; }
        public int? Plan_id { get; set; }
        public string Plan_name { get; set; }
        public int Amount { get; set; }
    }
}
