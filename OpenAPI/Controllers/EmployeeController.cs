using OpenAPI.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OpenAPI.Controllers
{
    [RoutePrefix("employee")]
    public class EmployeeController : ApiController
    {
        private Employee emp = new Employee();

        //[Route("getAllEmployeeDetails")]
        //public IHttpActionResult GetAllEmployeeDetails()
        //{
        //    var employee_all_details = emp.GetAllEmployeeDetails();
        //    return Ok(employee_all_details);
        //}

        //[Route("getEmployeeDetails")]
        //public IHttpActionResult GetAllEmployeeDetails(string employee_nr = null, string name = null, string old_employee_id = null)
        //{
        //    if (employee_nr != null || name != null || old_employee_id != null)
        //    {
        //        var employee_all_details = emp.GetAllEmployeeDetails(employee_nr, name, old_employee_id);
        //        return Ok(employee_all_details);
        //    }
        //    else 
        //    {
        //        var employee_all_details = emp.GetAllEmployeeDetails();
        //        return Ok(employee_all_details);
        //    }
        //}

        //[Route("getAllEmployees")]
        //public IHttpActionResult GetEmployees()
        //{
        //    var employees = emp.GetEmployees();
        //    return Ok(employees);
        //}

        [Authorize]
        [Route("getEmployees")]
        public IHttpActionResult GetEmployees(string employee_nr = null, string name = null, string old_employee_id = null)
        {
            if (employee_nr != null || name != null || old_employee_id != null)
            {
                var employees = emp.GetEmployees(employee_nr, name, old_employee_id);
                return Ok(employees);
            }
            else 
            {
                var employees = emp.GetEmployees();
                return Ok(employees);
            }
        }

        //[Route("getAllEmploymentDetails")]
        //public IHttpActionResult GetEmploymentDetails()
        //{
        //    var employment_details = emp.GetEmploymentDetails();
        //    return Ok(employment_details);   
        //}

        [Authorize]
        [Route("getEmploymentDetails")]
        public IHttpActionResult GetEmploymentDetails(string employee_nr = null, string name = null, string old_employee_id = null, string employee_status = null, string employee_type = null, string job_grade = null)
        {
            if (employee_nr != null || name != null || old_employee_id != null)
            {
                var employment_details = emp.GetEmploymentDetails(employee_status, employee_type, job_grade, employee_nr, name, old_employee_id);
                return Ok(employment_details);
            }
            else 
            {
                var employment_details = emp.GetEmploymentDetails();
                return Ok(employment_details);
            }
        }

        //[Route("getAllEmployeePrivileges")]
        //public IHttpActionResult GetEmployeePrivileges()
        //{
        //    var employee_privileges = emp.GetEmployeePrivileges();
        //    return Ok(employee_privileges);
        //}

        [Authorize]
        [Route("getEmployeePrivileges")]
        public IHttpActionResult GetEmployeePrivileges(string employee_nr = null, string name = null, string old_employee_id = null)
        {
            if (employee_nr != null || name != null || old_employee_id != null)
            {
                var employee_privileges = emp.GetEmployeePrivileges(employee_nr, name, old_employee_id);
                return Ok(employee_privileges);
            }
            else 
            {
                var employee_privileges = emp.GetEmployeePrivileges();
                return Ok(employee_privileges);
            }
        }

        //[Route("getAllEmployeeCareerHistory")]
        //public IHttpActionResult GetEmployeeCareerHistory()
        //{
        //    var employee_career_history = emp.GetEmployeeCareerHistory();
        //    return Ok(employee_career_history);
        //}

        [Authorize]
        [Route("getEmployeeCareerHistory")]
        public IHttpActionResult GetEmployeeCareerHistory(string employee_nr = null, string name = null, string old_employee_id = null)
        {
            if (employee_nr != null || name != null || old_employee_id != null)
            {
                var employee_career_history = emp.GetEmployeeCareerHistory(employee_nr, name, old_employee_id);
                return Ok(employee_career_history);
            }
            else
            {
                var employee_career_history = emp.GetEmployeeCareerHistory();
                return Ok(employee_career_history);
            }
        }

        //[Route("getAllEmployeeEducation")]
        //public IHttpActionResult GetEmployeeEducation()
        //{
        //    var employee_privileges = emp.GetEmployeeEducation();
        //    return Ok(employee_privileges);
        //}

        [Authorize]
        [Route("getEmployeeEducation")]
        public IHttpActionResult GetEmployeeEducation(string employee_nr = null, string name = null, string old_employee_id = null)
        {
            if (employee_nr != null || name != null || old_employee_id != null)
            {
                var employee_education = emp.GetEmployeeEducation(employee_nr, name, old_employee_id);
                return Ok(employee_education);
            }
            else
            {
                var employee_education = emp.GetEmployeeEducation();
                return Ok(employee_education);
            }
        }
    }
}
