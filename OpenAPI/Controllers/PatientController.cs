using OpenAPI.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OpenAPI.Controllers
{
    //[RoutePrefix("patient")]
    public class PatientController : ApiController
    {
        private Patient pat = new Patient();

        //[Route("getAllPatientDetails")]
        //public IHttpActionResult GetAllPatientDetails()
        //{
        //    var patient_all_details = pat.GetAllPatientDetails();
        //    return Ok(patient_all_details);
        //}

        //[Route("getPatientDetails")]
        //public IHttpActionResult GetAllPatientDetails(string hn = null, string name = null)
        //{
        //    if (hn != null || name != null)
        //    {
        //        var patient_all_details = pat.GetAllPatientDetails(hn, name);
        //        return Ok(patient_all_details);
        //    }
        //    else
        //    {
        //        var patient_all_details = pat.GetAllPatientDetails();
        //        return Ok(patient_all_details);
        //    }
        //}

        //[Route("getAllPatients")]
        //public IHttpActionResult GetPatients()
        //{
        //    var patients = pat.GetPatients();
        //    return Ok(patients);
        //}

        [Authorize]
        [Route("getPatients")]
        public IHttpActionResult GetPatients(string hn = null, string name = null)
        {
            if (hn != null || name != null)
            {
                var patients = pat.GetPatients(hn, name);
                return Ok(patients);
            }
            else
            {
                var patients = pat.GetPatients();
                return Ok(patients);
            }
        }

        //[Route("getAllPatientAllergies")]
        //public IHttpActionResult GetPatientAllergies()
        //{
        //    var patient_allergies = pat.GetPatientAllergies();
        //    return Ok(patient_allergies);
        //}

        [Authorize]
        [Route("getPatientAllergies")]
        public IHttpActionResult GetPatientAllergies(string hn = null, string name = null)
        {
            if (hn != null || name != null)
            {
                var patient_allergies = pat.GetPatientAllergies(hn, name);
                return Ok(patient_allergies);
            }
            else
            {
                var patient_allergies = pat.GetPatientAllergies(); ;
                return Ok(patient_allergies);
            }
        }

        //[Route("getAllPatientMedications")]
        //public IHttpActionResult GetPatientMedications()
        //{
        //    var patient_medications = pat.GetPatientMedications();
        //    return Ok(patient_medications);
        //}

        [Authorize]
        [Route("getPatientMedications")]
        public IHttpActionResult GetPatientMedications(string hn = null, string name = null)
        {
            if (hn != null || name != null)
            {
                var patient_medications = pat.GetPatientMedications(hn, name);
                return Ok(patient_medications);
            }
            else
            {
                var patient_medications = pat.GetPatientMedications();
                return Ok(patient_medications);
            }
        }

        //[Route("getAllPatientDiagnosis")]
        //public IHttpActionResult GetPatientDiagnosis()
        //{
        //    var patient_diagnosis = pat.GetPatientDiagnosis();
        //    return Ok(patient_diagnosis);
        //}

        [Authorize]
        [Route("getPatientDiagnosis")]
        public IHttpActionResult GetPatientDiagnosis(string hn = null, string name = null)
        {
            if (hn != null || name != null)
            {
                var patient_diagnosis = pat.GetPatientDiagnosis(hn, name);
                return Ok(patient_diagnosis);
            }
            else
            {
                var patient_diagnosis = pat.GetPatientDiagnosis();
                return Ok(patient_diagnosis);
            }
        }

        //[Route("getAllPatientPreviousHospitalizations")]
        //public IHttpActionResult GetPatientPrevHospitalizations()
        //{
        //    var patient_prev_hosp = pat.GetPatientPrevHospitalizations();
        //    return Ok(patient_prev_hosp);
        //}

        [Authorize]
        [Route("getPatientPreviousHospitalizations")]
        public IHttpActionResult GetPatientPrevHospitalizations(string hn = null, string name = null)
        {
            if (hn != null || name != null)
            {
                var patient_prev_hosp = pat.GetPatientPrevHospitalizations(hn, name);
                return Ok(patient_prev_hosp);
            }
            else 
            {
                var patient_prev_hosp = pat.GetPatientPrevHospitalizations();
                return Ok(patient_prev_hosp);
            }
        }

        //[Route("getAllPatientPreviousSurgeries")]
        //public IHttpActionResult GetPatientPrevSurgeries()
        //{
        //    var patient_prev_surgeries = pat.GetPatientPrevSurgeries();
        //    return Ok(patient_prev_surgeries);
        //}

        [Authorize]
        [Route("getPatientPreviousSurgeries")]
        public IHttpActionResult GetPatientPrevSurgeries(string hn = null, string name = null)
        {
            if (hn != null || name != null)
            {
                var patient_prev_surgeries = pat.GetPatientPrevSurgeries(hn, name);
                return Ok(patient_prev_surgeries);
            }
            else
            {
                var patient_prev_surgeries = pat.GetPatientPrevSurgeries();
                return Ok(patient_prev_surgeries);
            }
        }

        //[Authorize]
        [Route("getPatientBill/{hn}")]
        public IHttpActionResult GetPatientBill(string hn)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (pat.patientExists(hn))
                    {
                        if (pat.hasOpenVisit(hn))
                        {
                            var patient_bill = pat.GetPatientBill(hn);
                            return Ok(patient_bill);
                        }
                        else
                        {
                            return Conflict();
                        }
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception e)
                {
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, String.Format("An error has occured : {0}", e.Message)));
                }
            }
            else 
            {
                return BadRequest(ModelState);
            }
        }
    }
}
