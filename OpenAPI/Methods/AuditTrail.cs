using OpenAPI.Models.AuditTrailModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenAPI.Methods
{
    public class AuditTrail
    {
        private audit_trail_entities db = new audit_trail_entities();

        public string GetAppType(int app_id)
        {
            string app_type = db.applications.Where(a => a.application_id == app_id).Select(a => a.application_type).First();

            return app_type.Trim();
        }

        public bool validAppID(int app_id)
        {
            var isValid = db.applications.Any(a => a.application_id == app_id);

            return isValid;
        }

        public IEnumerable<audit_trail> GetLogs()
        {
            var logs = db.audit_trail.OrderByDescending(a => a.date_time);

            return logs;
        }
    }
}