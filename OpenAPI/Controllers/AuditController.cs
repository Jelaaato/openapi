using OpenAPI.Methods;
using OpenAPI.Models.AuditTrailModel;
using OpenAPI.Models.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PagedList;
using PagedList.Mvc;
using OpenAPI.Helpers;

namespace OpenAPI.Controllers
{
    [RoutePrefix("audit")]
    public class AuditController : ApiController
    {
        private audit_trail_entities db = new audit_trail_entities();
        private AuditTrail audittrail = new AuditTrail(); 

        [HttpPost]
        [Route("postuseractions")]
        public IHttpActionResult PostUserActions(AuditDTO model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (audittrail.validAppID(model.application_id))
                    {
                        if (audittrail.GetAppType(model.application_id) == "web")
                        {
                            audit_trail audit = new audit_trail()
                            {
                                id = Guid.NewGuid(),
                                application_id = model.application_id,
                                user_id = model.user_id,
                                action = model.action,
                                date_time = DateTime.Now,
                                device_name = model.device_name,
                                os_version = model.os_version,
                                location = model.location,
                                ip_address = model.ip_address
                            };

                            db.audit_trail.Add(audit);
                            db.SaveChanges();

                            if (db.SaveChanges() >= 0)
                            {
                                return Ok();
                            }
                            else
                            {
                                return Conflict();
                            }
                        }
                        else if (audittrail.GetAppType(model.application_id) == "ios")
                        {
                            audit_trail audit = new audit_trail()
                            {
                                id = Guid.NewGuid(),
                                application_id = model.application_id,
                                user_id = model.user_id,
                                action = model.action,
                                date_time = DateTime.Now,
                                device_name = model.device_name,
                                os_version = model.os_version,
                                location = model.location,
                                ip_address = null
                            };

                            db.audit_trail.Add(audit);
                            db.SaveChanges();

                            if (db.SaveChanges() >= 0)
                            {
                                return Ok();
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
                    else
                    {
                        return NotFound();
                    }
                }
                return BadRequest(ModelState);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            
        }

        [HttpGet]
        [Route("getlogs")]
        public IHttpActionResult GetLogs(int pageNo = 1, int pageSize = 10)
        {
            try
            {
                int skip = (pageNo - 1) * pageSize;
                int total = audittrail.GetLogs().Count();
                var logs = audittrail.GetLogs().Skip(skip).Take(pageSize);
                return Ok(new Paging<audit_trail>(logs, pageNo, pageSize, total));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            
        }

        [HttpGet]
        [Route("getlogsbyapp/{app_id}")]
        public IHttpActionResult GetLogs(int app_id, int pageNo = 1, int pageSize = 10)
        {
            try
            {
                if (audittrail.validAppID(app_id))
                {
                    int skip = (pageNo - 1) * pageSize;
                    int total = audittrail.GetLogs().Where(a => a.application_id == app_id).Count();
                    var logs = audittrail.GetLogs().Where(a => a.application_id == app_id).Skip(skip).Take(pageSize);
                    return Ok(new Paging<audit_trail>(logs, pageNo, pageSize, total));
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [Route("getlogsbyuser/{user_id}")]
        public IHttpActionResult GetLogs(string user_id, int pageNo = 1, int pageSize = 10)
        {
            try
            {
                if (db.audit_trail.Any(a => a.user_id == user_id))
                {
                    int skip = (pageNo - 1) * pageSize;
                    int total = audittrail.GetLogs().Where(a => a.user_id == user_id).Count();
                    var logs = audittrail.GetLogs().Where(a => a.user_id == user_id).Skip(skip).Take(pageSize).OrderByDescending(a => a.date_time);
                    return Ok(new Paging<audit_trail>(logs, pageNo, pageSize, total));
                }
                else 
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
