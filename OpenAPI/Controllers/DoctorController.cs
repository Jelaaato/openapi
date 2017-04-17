using OpenAPI.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PagedList;
using PagedList.Mvc;
using OpenAPI.Helpers;
using OpenAPI.Models.DataTransferObjects;
using OpenAPI.Models.DoctorModel;

namespace OpenAPI.Controllers
{
    [RoutePrefix("doctor")]
    public class DoctorController : ApiController
    {
        private Doctor doc = new Doctor();

        [Route("info")]
        public IHttpActionResult GetDoctorsInfo(int pageNo = 1, int pageSize = 10)
        {
            int skip = (pageNo - 1) * pageSize;
            int total = doc.GetDoctors().Count();
            var doctors = doc.GetDoctors().Skip(skip).Take(pageSize).ToList();

            return Ok(new Paging<DoctorsDTO.Doctors>(doctors, pageNo, pageSize, total));
        }

        //[Route("departments")]
        //public IHttpActionResult GetDepartments(int pageNo = 1, int pageSize = 10)
        //{
        //    int skip = (pageNo - 1) * pageSize;
        //    int total = doc.GetAllDepartments().Count();
        //    var departments = doc.GetAllDepartments().Skip(skip).Take(pageSize).ToList();
        //    return Ok(new Paging<department>(departments, pageNo, pageSize, total));
        //}

        [Route("departments")]
        public IHttpActionResult GetDepartments(int pageNo = 1, int pageSize = 10)
        {
            var departments = doc.GetAllDepartments().ToList();
            return Ok(departments);
        }

        [Route("info/searchbyname/{search}")]
        public IHttpActionResult GetDoctorsFilterByName(string search, int pageNo = 1, int pageSize = 10)
        {
            if (search != null)
            {
                var doctors = doc.GetDoctorsViaName(search);
                if (doctors.Count() != 0)
                {
                    int skip = (pageNo - 1) * pageSize;
                    int total = doctors.Count();

                    doctors.Skip(skip).Take(pageSize).ToList();

                    return Ok(new Paging<DoctorsDTO.Doctors>(doctors, pageNo, pageSize, total));
                }
                else
                {
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, String.Format("No matched results.")));
                }
            }
            else
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, String.Format("Please check your request.")));
            }
        }

        [Route("info/searchbydepartment/{search}")]
        public IHttpActionResult GetDoctorsFilterByDepartment(string search, int pageNo = 1, int pageSize = 10)
        {
            if (search != null)
            {
                var doctors = doc.GetDoctors();

                if (doctors.Count() != 0)
                {
                    var doctors_search_result = doctors.Where(a => a.doc_depts.Any(b => b.department_name.IndexOf(search, StringComparison.OrdinalIgnoreCase) != -1));
                    if (doctors_search_result.Count() != 0)
                    {
                        int skip = (pageNo - 1) * pageSize;
                        int total = doctors_search_result.Count();

                        doctors_search_result.Skip(skip).Take(pageSize).ToList();

                        return Ok(new Paging<DoctorsDTO.Doctors>(doctors_search_result, pageNo, pageSize, total));
                    }
                    else
                    {
                        throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, String.Format("No matched results.")));
                    }
                }
                else
                {
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, String.Format("There are no existing records as of the moment.")));
                }
            }
            else
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, String.Format("Please check your request.")));
            }
        }
    }
}
