//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OpenAPI.Models.EmployeeModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class employee_career_history
    {
        public System.Guid career_history_id { get; set; }
        public System.Guid employee_id { get; set; }
        public string employee_nr { get; set; }
        public string display_name { get; set; }
        public Nullable<System.DateTime> career_history_start_date { get; set; }
        public Nullable<System.DateTime> career_history_end_date { get; set; }
        public string career_history_position { get; set; }
        public Nullable<int> career_duration_in_years { get; set; }
        public Nullable<int> career_duration_in_months { get; set; }
    
        public virtual employee employee { get; set; }
    }
}
