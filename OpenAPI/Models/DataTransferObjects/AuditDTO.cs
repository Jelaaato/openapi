using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenAPI.Models.DataTransferObjects
{
    public class AuditDTO
    {
        public int application_id { get; set; }
        public string user_id { get; set; }
        public string device_name { get; set; }
        public string os_version { get; set; }
        public string location { get; set; }
        public string action { get; set; }
        public string ip_address { get; set; }
    }
}