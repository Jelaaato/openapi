using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenAPI.Models.DataTransferObjects
{
    public class EmployeesDTO
    {
        public class Employees
        {
            public System.Guid employee_id { get; set; }
            public string employee_nr { get; set; }
            public string old_employee_id { get; set; }
            public string display_name { get; set; }
            public string last_name { get; set; }
            public string first_name { get; set; }
            public string middle_name { get; set; }
            public string common_name { get; set; }
            public string title { get; set; }
            public string suffix { get; set; }
            public System.DateTime date_of_birth { get; set; }
            public Nullable<int> age { get; set; }
            public string gender { get; set; }
            public string race { get; set; }
            public string nationality { get; set; }
            public string religion { get; set; }
            public string marital_status { get; set; }
            public string primary_language { get; set; }
            public string ethnic_group { get; set; }

            public IEnumerable<EmploymentDetailsOnly> employment_details { get; set; }
            public IEnumerable<EmployeePrivilegesOnly> employee_privileges { get; set; }
            public IEnumerable<EmployeeCareerHistoryOnly> employee_career_history { get; set; }
            public IEnumerable<EmployeeEducationOnly> employee_education { get; set; }
        }

        public class EmployeeInfo
        {
            public System.Guid employee_id { get; set; }
            public string employee_nr { get; set; }
            public string old_employee_id { get; set; }
            public string display_name { get; set; }
            public string last_name { get; set; }
            public string first_name { get; set; }
            public string middle_name { get; set; }
            public string common_name { get; set; }
            public string title { get; set; }
            public string suffix { get; set; }
            public System.DateTime date_of_birth { get; set; }
            public Nullable<int> age { get; set; }
            public string gender { get; set; }
            public string race { get; set; }
            public string nationality { get; set; }
            public string religion { get; set; }
            public string marital_status { get; set; }
            public string primary_language { get; set; }
            public string ethnic_group { get; set; }
        }

        public class EmploymentDetails
        {
            public System.Guid employee_id { get; set; }
            public string employee_nr { get; set; }
            public string old_employee_id { get; set; }
            public string display_name { get; set; }
            public Nullable<System.DateTime> hire_date { get; set; }
            public Nullable<System.DateTime> effective_from_date { get; set; }
            public Nullable<System.DateTime> effective_until_date { get; set; }
            public Nullable<System.DateTime> termination_date { get; set; }
            public string termination_reason { get; set; }
            public string occupation { get; set; }
            public string occupation_status { get; set; }
            public string occupation_type { get; set; }
            public string employee_status { get; set; }
            public string employee_type { get; set; }
            public string company_code { get; set; }
            public string company { get; set; }
            public string job_type { get; set; }
            public Nullable<int> job_type_level_nr { get; set; }
            public string job_category { get; set; }
            public string job_title { get; set; }
            public string job_grade { get; set; }
            public Nullable<int> job_grade_level_nr { get; set; }
            public string costcentre { get; set; }
            public string department { get; set; }
            public string position_status { get; set; }
            public string employment_reason { get; set; }
            public string work_hours_per_week { get; set; }
        }

        public class EmploymentDetailsOnly
        {
            public Nullable<System.DateTime> hire_date { get; set; }
            public Nullable<System.DateTime> effective_from_date { get; set; }
            public Nullable<System.DateTime> effective_until_date { get; set; }
            public Nullable<System.DateTime> termination_date { get; set; }
            public string termination_reason { get; set; }
            public string occupation { get; set; }
            public string occupation_status { get; set; }
            public string occupation_type { get; set; }
            public string employee_status { get; set; }
            public string employee_type { get; set; }
            public string company_code { get; set; }
            public string company { get; set; }
            public string job_type { get; set; }
            public string job_category { get; set; }
            public string job_title { get; set; }
            public string job_grade { get; set; }
            public string costcentre { get; set; }
            public string department { get; set; }
            public string position_status { get; set; }
            public string employment_reason { get; set; }
            public string work_hours_per_week { get; set; }
        }

        public class EmployeePrivileges
        {
            public System.Guid employee_id { get; set; }
            public string employee_nr { get; set; }
            public string old_employee_id { get; set; }
            public string display_name { get; set; }
            public string last_name { get; set; }
            public string first_name { get; set; }
            public string middle_name { get; set; }

            public IEnumerable<EmployeePrivilegesOnly> employee_priviliges { get; set; }
        }

        public class EmployeePrivilegesOnly
        {
            public Nullable<bool> admitting_privilege_flag { get; set; }
            public Nullable<bool> request_patient_record_flag { get; set; }
            public string special_privileges { get; set; }
            public string admitting_status { get; set; }
            public string doctor_status { get; set; }
        }

        public class EmployeeCareerHistory
        {
            public System.Guid employee_id { get; set; }
            public string employee_nr { get; set; }
            public string old_employee_id { get; set; }
            public string display_name { get; set; }
            public string last_name { get; set; }
            public string first_name { get; set; }
            public string middle_name { get; set; }

            public IEnumerable<EmployeeCareerHistoryOnly> employee_career_history { get; set; }
        }

        public class EmployeeCareerHistoryOnly
        {
            public Nullable<System.DateTime> career_history_start_date { get; set; }
            public Nullable<System.DateTime> career_history_end_date { get; set; }
            public string career_history_position { get; set; }
            public Nullable<int> career_duration_in_years { get; set; }
            public Nullable<int> career_duration_in_months { get; set; }
        }

        public class EmployeeEducation
        {
            public System.Guid employee_id { get; set; }
            public string employee_nr { get; set; }
            public string old_employee_id { get; set; }
            public string display_name { get; set; }
            public string last_name { get; set; }
            public string first_name { get; set; }
            public string middle_name { get; set; }

            public IEnumerable<EmployeeEducationOnly> employee_education { get; set; }
        }

        public class EmployeeEducationOnly
        {
            public string major { get; set; }
            public string subject { get; set; }
            public Nullable<System.DateTime> dates_attended_from { get; set; }
            public Nullable<System.DateTime> dates_attended_to { get; set; }
            public Nullable<System.DateTime> graduation_date { get; set; }
            public string comments { get; set; }
            public Nullable<bool> verified_flag { get; set; }
            public Nullable<System.DateTime> verified_date { get; set; }
            public Nullable<bool> completed_flag { get; set; }
            public string education_type { get; set; }
        }
    }
}