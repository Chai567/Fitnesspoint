//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fitnesspoint.Db
{
    using System;
    using System.Collections.Generic;
    
    public partial class NutritionPlan
    {
        public int NutriPlanId { get; set; }
        public string Name { get; set; }
        public string PlanDescription { get; set; }
        public System.DateTime Created_At { get; set; }
        public System.DateTime Updated_At { get; set; }
        public int Price { get; set; }
    }
}
