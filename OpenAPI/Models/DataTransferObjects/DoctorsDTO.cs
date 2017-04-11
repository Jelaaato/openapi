using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenAPI.Models.DataTransferObjects
{
    public class DoctorsDTO
    {
        public class Doctors
        {
            public int doctor_id { get; set; }
            public string last_name { get; set; }
            public string first_name { get; set; }
            public string middle_name { get; set; }
            public string display_name { get; set; }
            public string mob_room { get; set; }

            public IEnumerable<doctors_contacts> doc_contacts { get; set; }
            public IEnumerable<doctors_departments> doc_depts { get; set; }
            public IEnumerable<doctors_specializations> doc_specs { get; set; }
        }

        public class doctors_contacts
        {
            public string contact_number { get; set; }
            public string contact_type { get; set; }
        }

        public class doctors_departments
        {
            public int department_id { get; set; }
            public string department_name { get; set; }
        }

        public class doctors_specializations
        {
            public int specialization_id { get; set; }
            public string specialization_name { get; set; }
        }
    }
}