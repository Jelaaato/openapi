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
    
    public partial class employee_privileges
    {
        public System.Guid privileges_id { get; set; }
        public System.Guid employee_id { get; set; }
        public string employee_nr { get; set; }
        public string old_employee_id { get; set; }
        public string display_name { get; set; }
        public Nullable<bool> admitting_privilege_flag { get; set; }
        public Nullable<bool> request_patient_record_flag { get; set; }
        public string special_privileges { get; set; }
        public string admitting_status { get; set; }
        public string doctor_status { get; set; }
    
        public virtual employee employee { get; set; }
    }
}
