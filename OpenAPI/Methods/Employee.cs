using OpenAPI.Models.EmployeeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenAPI.Models.DataTransferObjects;

namespace OpenAPI.Methods
{
    public class Employee
    {
        private employee_entities db = new employee_entities();

        public IEnumerable<EmployeesDTO.Employees> GetAllEmployeeDetails()
        {
            var employee_all_details = db.employees.Include("employment_details")
                                       .Select(a => new EmployeesDTO.Employees
                                       {
                                           employee_id = a.employee_id,
                                           old_employee_id = a.old_employee_id,
                                           employee_nr = a.employee_nr,
                                           last_name = a.last_name,
                                           first_name = a.first_name,
                                           middle_name = a.middle_name,
                                           display_name = a.display_name,
                                           common_name = a.common_name,
                                           title = a.title,
                                           suffix = a.suffix,
                                           date_of_birth = a.date_of_birth,
                                           age = a.age,
                                           gender = a.gender,
                                           marital_status = a.marital_status,
                                           religion = a.religion,
                                           race = a.race,
                                           nationality = a.nationality,
                                           primary_language = a.primary_language,
                                           ethnic_group = a.ethnic_group,
                                           employment_details = a.employee_employment_details.Select(b => new EmployeesDTO.EmploymentDetailsOnly
                                           {
                                               hire_date = b.hire_date,
                                               effective_from_date = b.effective_from_date,
                                               effective_until_date = b.effective_until_date,
                                               termination_date = b.termination_date,
                                               termination_reason = b.termination_reason,
                                               employee_type = b.employee_type,
                                               employee_status = b.employee_status,
                                               employment_reason = b.employment_reason,
                                               job_title = b.job_title,
                                               job_category = b.job_category,
                                               job_type = b.job_type,
                                               job_grade = b.job_grade,
                                               occupation = b.occupation,
                                               occupation_type = b.occupation_type,
                                               occupation_status = b.occupation_status,
                                               costcentre = b.costcentre,
                                               department = b.department,
                                               position_status = b.position_status,
                                               work_hours_per_week = b.work_hours_per_week,
                                               company_code = b.company_code,
                                               company = b.company
                                           }),
                                           employee_education = a.employee_education.Select(c => new EmployeesDTO.EmployeeEducationOnly
                                           {
                                               education_type = c.education_type,
                                               dates_attended_from = c.dates_attended_from,
                                               dates_attended_to = c.dates_attended_to,
                                               major = c.major,
                                               subject = c.subject,
                                               graduation_date = c.graduation_date,
                                               completed_flag = c.completed_flag,
                                               verified_flag = c.verified_flag,
                                               verified_date = c.verified_date,
                                               comments = c.comments
                                           }),
                                           employee_career_history = a.employee_career_history.Select(d => new EmployeesDTO.EmployeeCareerHistoryOnly
                                           {
                                               career_history_start_date = d.career_history_start_date,
                                               career_history_end_date = d.career_history_end_date,
                                               career_history_position = d.career_history_position,
                                               career_duration_in_months = d.career_duration_in_months,
                                               career_duration_in_years = d.career_duration_in_years
                                           }),
                                           employee_privileges = a.employee_privileges.Select(e => new EmployeesDTO.EmployeePrivilegesOnly
                                           {
                                               admitting_privilege_flag = e.admitting_privilege_flag,
                                               admitting_status = e.admitting_status,
                                               special_privileges = e.special_privileges,
                                               request_patient_record_flag = e.request_patient_record_flag,
                                               doctor_status = e.doctor_status
                                           })
                                       }).OrderBy(a => a.last_name);

            return employee_all_details;
        }

        public IEnumerable<EmployeesDTO.Employees> GetAllEmployeeDetails(string employee_nr, string name, string old_employee_id)
        {
            var employee_all_details = db.employees.Include("employment_details")
                                       .Where(a => a.employee_nr == employee_nr || a.display_name.Contains(name) || a.old_employee_id == old_employee_id)
                                       .Select(a => new EmployeesDTO.Employees
                                       {
                                           employee_id = a.employee_id,
                                           old_employee_id = a.old_employee_id,
                                           employee_nr = a.employee_nr,
                                           last_name = a.last_name,
                                           first_name = a.first_name,
                                           middle_name = a.middle_name,
                                           display_name = a.display_name,
                                           common_name = a.common_name,
                                           title = a.title,
                                           suffix = a.suffix,
                                           date_of_birth = a.date_of_birth,
                                           age = a.age,
                                           gender = a.gender,
                                           marital_status = a.marital_status,
                                           religion = a.religion,
                                           race = a.race,
                                           nationality = a.nationality,
                                           primary_language = a.primary_language,
                                           ethnic_group = a.ethnic_group,
                                           employment_details = a.employee_employment_details.Select(b => new EmployeesDTO.EmploymentDetailsOnly
                                           {
                                               hire_date = b.hire_date,
                                               effective_from_date = b.effective_from_date,
                                               effective_until_date = b.effective_until_date,
                                               termination_date = b.termination_date,
                                               termination_reason = b.termination_reason,
                                               employee_type = b.employee_type,
                                               employee_status = b.employee_status,
                                               employment_reason = b.employment_reason,
                                               job_title = b.job_title,
                                               job_category = b.job_category,
                                               job_type = b.job_type,
                                               job_grade = b.job_grade,
                                               occupation = b.occupation,
                                               occupation_type = b.occupation_type,
                                               occupation_status = b.occupation_status,
                                               costcentre = b.costcentre,
                                               department = b.department,
                                               position_status = b.position_status,
                                               work_hours_per_week = b.work_hours_per_week,
                                               company_code = b.company_code,
                                               company = b.company
                                           }),
                                           employee_education = a.employee_education.Select(c => new EmployeesDTO.EmployeeEducationOnly
                                           {
                                               education_type = c.education_type,
                                               dates_attended_from = c.dates_attended_from,
                                               dates_attended_to = c.dates_attended_to,
                                               major = c.major,
                                               subject = c.subject,
                                               graduation_date = c.graduation_date,
                                               completed_flag = c.completed_flag,
                                               verified_flag = c.verified_flag,
                                               verified_date = c.verified_date,
                                               comments = c.comments
                                           }),
                                           employee_career_history = a.employee_career_history.Select(d => new EmployeesDTO.EmployeeCareerHistoryOnly
                                           {
                                               career_history_start_date = d.career_history_start_date,
                                               career_history_end_date = d.career_history_end_date,
                                               career_history_position = d.career_history_position,
                                               career_duration_in_months = d.career_duration_in_months,
                                               career_duration_in_years = d.career_duration_in_years
                                           }),
                                           employee_privileges = a.employee_privileges.Select(e => new EmployeesDTO.EmployeePrivilegesOnly
                                           {
                                               admitting_privilege_flag = e.admitting_privilege_flag,
                                               admitting_status = e.admitting_status,
                                               special_privileges = e.special_privileges,
                                               request_patient_record_flag = e.request_patient_record_flag,
                                               doctor_status = e.doctor_status
                                           })
                                       }).OrderBy(a => a.last_name);

            return employee_all_details;
        }

        public IEnumerable<EmployeesDTO.EmployeeInfo> GetEmployees()
        {
            var employees = (from e in db.employees
                             select new EmployeesDTO.EmployeeInfo
                             {
                                 old_employee_id = e.old_employee_id,
                                 employee_nr = e.employee_nr,
                                 last_name = e.last_name,
                                 first_name = e.first_name,
                                 middle_name = e.middle_name,
                                 display_name = e.display_name,
                                 common_name = e.common_name,
                                 title = e.title,
                                 suffix = e.suffix,
                                 date_of_birth = e.date_of_birth,
                                 age = e.age,
                                 gender = e.gender,
                                 race = e.race,
                                 nationality = e.nationality,
                                 religion = e.religion,
                                 marital_status = e.marital_status,
                                 primary_language = e.primary_language,
                                 ethnic_group = e.ethnic_group
                             }).OrderBy(e => e.last_name).ToList();

            return employees;
        }

        public IEnumerable<EmployeesDTO.EmployeeInfo> GetEmployees(string employee_nr, string name, string old_employee_id)
        {
            var employees = (from e in db.employees
                             where e.employee_nr == employee_nr || e.display_name.Contains(name) || e.old_employee_id == old_employee_id
                             select new EmployeesDTO.EmployeeInfo
                             {
                                 employee_id = e.employee_id,
                                 old_employee_id = e.old_employee_id,
                                 employee_nr = e.employee_nr,
                                 last_name = e.last_name,
                                 first_name = e.first_name,
                                 middle_name = e.middle_name,
                                 display_name = e.display_name,
                                 common_name = e.common_name,
                                 title = e.title,
                                 suffix = e.suffix,
                                 date_of_birth = e.date_of_birth,
                                 age = e.age,
                                 gender = e.gender,
                                 race = e.race,
                                 nationality = e.nationality,
                                 religion = e.religion,
                                 marital_status = e.marital_status,
                                 primary_language = e.primary_language,
                                 ethnic_group = e.ethnic_group
                             }).OrderBy(e => e.last_name).ToList();

            return employees;
        }

        public IEnumerable<EmployeesDTO.EmploymentDetails> GetEmploymentDetails()
        {
            var employment_details = (from e in db.employee_employment_details
                                      select new EmployeesDTO.EmploymentDetails
                                      {
                                          employee_id = e.employee_id,
                                          employee_nr = e.employee_nr,
                                          old_employee_id = e.old_employee_id,
                                          display_name = e.display_name,
                                          hire_date = e.hire_date,
                                          effective_from_date = e.effective_from_date,
                                          effective_until_date = e.effective_until_date,
                                          termination_date = e.termination_date,
                                          termination_reason = e.termination_reason,
                                          occupation = e.occupation,
                                          occupation_status = e.occupation_status,
                                          occupation_type = e.occupation_type,
                                          employee_status = e.employee_status,
                                          employee_type = e.employee_type,
                                          company_code = e.company_code,
                                          company = e.company,
                                          job_type = e.job_type,
                                          job_type_level_nr = e.job_type_level_nr,
                                          job_title = e.job_title,
                                          job_grade = e.job_grade,
                                          job_grade_level_nr = e.job_grade_level_nr,
                                          costcentre = e.costcentre,
                                          department = e.department,
                                          position_status = e.position_status,
                                          employment_reason = e.employment_reason,
                                          work_hours_per_week = e.work_hours_per_week
                                      }).OrderBy(a => a.display_name).ToList();

            return employment_details;
        }

        public IEnumerable<EmployeesDTO.EmploymentDetails> GetEmploymentDetails(string employee_status, string employee_type, string job_grade, string employee_nr, string name, string old_employee_id)
        {
            var employment_details = (from e in db.employee_employment_details
                                      where e.employee_nr == employee_nr || e.display_name.Contains(name) || e.old_employee_id == old_employee_id || e.employee_status == employee_status || e.employee_type == employee_type || e.job_grade == job_grade
                                      select new EmployeesDTO.EmploymentDetails
                                      {
                                          employee_id = e.employee_id,
                                          employee_nr = e.employee_nr,
                                          old_employee_id = e.old_employee_id,
                                          display_name = e.display_name,
                                          hire_date = e.hire_date,
                                          effective_from_date = e.effective_from_date,
                                          effective_until_date = e.effective_until_date,
                                          termination_date = e.termination_date,
                                          termination_reason = e.termination_reason,
                                          occupation = e.occupation,
                                          occupation_status = e.occupation_status,
                                          occupation_type = e.occupation_type,
                                          employee_status = e.employee_status,
                                          employee_type = e.employee_type,
                                          company_code = e.company_code,
                                          company = e.company,
                                          job_type = e.job_type,
                                          job_type_level_nr = e.job_type_level_nr,
                                          job_title = e.job_title,
                                          job_grade = e.job_grade,
                                          job_grade_level_nr = e.job_grade_level_nr,
                                          costcentre = e.costcentre,
                                          department = e.department,
                                          position_status = e.position_status,
                                          employment_reason = e.employment_reason,
                                          work_hours_per_week = e.work_hours_per_week
                                      }).OrderBy(a => a.display_name).ToList();

            return employment_details;
        }

        public IEnumerable<EmployeesDTO.EmployeePrivileges> GetEmployeePrivileges()
        {
            var employee_privileges = db.employees.Include("employee_privileges")
                                        .Select(a => new EmployeesDTO.EmployeePrivileges
                                        {
                                            employee_id = a.employee_id,
                                            old_employee_id = a.old_employee_id,
                                            employee_nr = a.employee_nr,
                                            last_name = a.last_name,
                                            first_name = a.first_name,
                                            middle_name = a.middle_name,
                                            display_name = a.display_name,
                                            employee_priviliges = a.employee_privileges.Select(b => new EmployeesDTO.EmployeePrivilegesOnly
                                            {
                                                admitting_privilege_flag = b.admitting_privilege_flag,
                                                admitting_status = b.admitting_status,
                                                special_privileges = b.special_privileges,
                                                request_patient_record_flag = b.request_patient_record_flag,
                                                doctor_status = b.doctor_status
                                            })
                                        }).OrderBy(a => a.last_name);

            return employee_privileges;
        }

        public IEnumerable<EmployeesDTO.EmployeePrivileges> GetEmployeePrivileges(string employee_nr, string name, string old_employee_id)
        {
            var employee_privileges = db.employees.Include("employee_privileges")
                                        .Where(a => a.employee_nr == employee_nr || a.display_name.Contains(name) || a.old_employee_id == old_employee_id)
                                        .Select(a => new EmployeesDTO.EmployeePrivileges
                                        {
                                            employee_id = a.employee_id,
                                            old_employee_id = a.old_employee_id,
                                            employee_nr = a.employee_nr,
                                            last_name = a.last_name,
                                            first_name = a.first_name,
                                            middle_name = a.middle_name,
                                            display_name = a.display_name,
                                            employee_priviliges = a.employee_privileges.Select(b => new EmployeesDTO.EmployeePrivilegesOnly
                                            {
                                                admitting_privilege_flag = b.admitting_privilege_flag,
                                                admitting_status = b.admitting_status,
                                                special_privileges = b.special_privileges,
                                                request_patient_record_flag = b.request_patient_record_flag,
                                                doctor_status = b.doctor_status
                                            })
                                        }).OrderBy(a => a.last_name);

            return employee_privileges;
        }

        public IEnumerable<EmployeesDTO.EmployeeCareerHistory> GetEmployeeCareerHistory()
        {
            var employee_career_history = db.employees.Include("employee_career_history")
                                            .Select(a => new EmployeesDTO.EmployeeCareerHistory
                                            {
                                                employee_id = a.employee_id,
                                                old_employee_id = a.old_employee_id,
                                                employee_nr = a.employee_nr,
                                                last_name = a.last_name,
                                                first_name = a.first_name,
                                                middle_name = a.middle_name,
                                                display_name = a.display_name,
                                                employee_career_history = a.employee_career_history.Select(b => new EmployeesDTO.EmployeeCareerHistoryOnly
                                                {
                                                    career_history_start_date = b.career_history_start_date,
                                                    career_history_end_date = b.career_history_end_date,
                                                    career_history_position = b.career_history_position,
                                                    career_duration_in_months = b.career_duration_in_months,
                                                    career_duration_in_years = b.career_duration_in_years
                                                })
                                            }).OrderBy(a => a.display_name);

            return employee_career_history;
        }

        public IEnumerable<EmployeesDTO.EmployeeCareerHistory> GetEmployeeCareerHistory(string employee_nr, string name, string old_employee_id)
        {
            var employee_career_history = db.employees.Include("employee_career_history")
                                            .Where(a => a.employee_nr == employee_nr || a.display_name.Contains(name) || a.old_employee_id == old_employee_id)
                                            .Select(a => new EmployeesDTO.EmployeeCareerHistory
                                            {
                                                employee_id = a.employee_id,
                                                old_employee_id = a.old_employee_id,
                                                employee_nr = a.employee_nr,
                                                last_name = a.last_name,
                                                first_name = a.first_name,
                                                middle_name = a.middle_name,
                                                display_name = a.display_name,
                                                employee_career_history = a.employee_career_history.Select(b => new EmployeesDTO.EmployeeCareerHistoryOnly
                                                {
                                                    career_history_start_date = b.career_history_start_date,
                                                    career_history_end_date = b.career_history_end_date,
                                                    career_history_position = b.career_history_position,
                                                    career_duration_in_months = b.career_duration_in_months,
                                                    career_duration_in_years = b.career_duration_in_years
                                                })
                                            }).OrderBy(a => a.display_name);

            return employee_career_history;
        }

        public IEnumerable<EmployeesDTO.EmployeeEducation> GetEmployeeEducation()
        {
            var employee_education = db.employees.Include("employee_education")
                                        .Select(a => new EmployeesDTO.EmployeeEducation
                                        {
                                            employee_id = a.employee_id,
                                            old_employee_id = a.old_employee_id,
                                            employee_nr = a.employee_nr,
                                            last_name = a.last_name,
                                            first_name = a.first_name,
                                            middle_name = a.middle_name,
                                            display_name = a.display_name,
                                            employee_education = a.employee_education.Select(b => new EmployeesDTO.EmployeeEducationOnly
                                            {
                                                education_type = b.education_type,
                                                dates_attended_from = b.dates_attended_from,
                                                dates_attended_to = b.dates_attended_to,
                                                graduation_date = b.graduation_date,
                                                major = b.major,
                                                subject = b.subject,
                                                verified_flag = b.verified_flag,
                                                verified_date = b.verified_date,
                                                completed_flag = b.completed_flag,
                                                comments = b.comments
                                            })
                                        }).OrderBy(a => a.last_name);

            return employee_education;
        }

        public IEnumerable<EmployeesDTO.EmployeeEducation> GetEmployeeEducation(string employee_nr, string name, string old_employee_id)
        {
            var employee_education = db.employees.Include("employee_education")
                                        .Where(a => a.employee_nr == employee_nr || a.display_name.Contains(name) || a.old_employee_id == old_employee_id)
                                        .Select(a => new EmployeesDTO.EmployeeEducation
                                        {
                                            employee_id = a.employee_id,
                                            old_employee_id = a.old_employee_id,
                                            employee_nr = a.employee_nr,
                                            last_name = a.last_name,
                                            first_name = a.first_name,
                                            middle_name = a.middle_name,
                                            display_name = a.display_name,
                                            employee_education = a.employee_education.Select(b => new EmployeesDTO.EmployeeEducationOnly
                                            {
                                                education_type = b.education_type,
                                                dates_attended_from = b.dates_attended_from,
                                                dates_attended_to = b.dates_attended_to,
                                                graduation_date = b.graduation_date,
                                                major = b.major,
                                                subject = b.subject,
                                                verified_flag = b.verified_flag,
                                                verified_date = b.verified_date,
                                                completed_flag = b.completed_flag,
                                                comments = b.comments
                                            })
                                        }).OrderBy(a => a.last_name);

            return employee_education;
        }
    }
}