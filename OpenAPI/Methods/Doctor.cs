using OpenAPI.Models.DataTransferObjects;
using OpenAPI.Models.DoctorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenAPI.Methods
{
    public class Doctor
    {
        private doctor_entities db = new doctor_entities();

        public IEnumerable<department> GetAllDepartments()
        {
            var depts = db.departments.OrderBy(a => a.department_name).ToList();
            return depts;
        }

        public IEnumerable<DoctorsDTO.Doctors> GetDoctors()
        {
            var doctors = db.doctors.Include("doc_contacts")
                           .Select(p => new DoctorsDTO.Doctors
                           {
                               doctor_id = p.doctor_id,
                               first_name = p.first_name,
                               middle_name = p.middle_name,
                               last_name = p.last_name,
                               display_name = p.display_name,
                               mob_room = p.mob_room,
                               doc_contacts = p.doctors_contacts.Select(a => new DoctorsDTO.doctors_contacts
                               {
                                   contact_type = a.contact_type,
                                   contact_number = a.contact_number
                               }),
                               doc_depts = p.doctors_department.Select(b => new DoctorsDTO.doctors_departments
                               {
                                   department_id = b.department_id,
                                   department_name = b.department_name
                               }),
                               doc_specs = p.doctors_specialization.Select(c => new DoctorsDTO.doctors_specializations
                               {
                                   specialization_id = c.specialization_id,
                                   specialization_name = c.specialization_name
                               })

                           }).OrderBy(a => a.last_name.Trim());

            return doctors;
        }

        public IEnumerable<DoctorsDTO.Doctors> GetDoctorsViaName(string search)
        {
            var doctors = db.doctors.Include("doc_contacts").Where(a => a.display_name.Contains(search))
                             .Select(p => new DoctorsDTO.Doctors
                             {
                                 doctor_id = p.doctor_id,
                                 first_name = p.first_name,
                                 middle_name = p.middle_name,
                                 last_name = p.last_name,
                                 display_name = p.display_name,
                                 mob_room = p.mob_room,
                                 doc_contacts = p.doctors_contacts.Select(a => new DoctorsDTO.doctors_contacts
                                 {
                                     contact_type = a.contact_type,
                                     contact_number = a.contact_number
                                 }),
                                 doc_depts = p.doctors_department.Select(b => new DoctorsDTO.doctors_departments
                                 {
                                     department_id = b.department_id,
                                     department_name = b.department_name
                                 }),
                                 doc_specs = p.doctors_specialization.Select(c => new DoctorsDTO.doctors_specializations
                                 {
                                     specialization_id = c.specialization_id,
                                     specialization_name = c.specialization_name
                                 })

                             }).OrderBy(a => a.last_name.Trim());

            return doctors;
        }

        public IEnumerable<DoctorsDTO.Doctors> GetDoctorsViaDepartment(string search)
        {
            var doctors = db.doctors.Include("doc_contacts")
                             .Select(p => new DoctorsDTO.Doctors
                             {
                                 doctor_id = p.doctor_id,
                                 first_name = p.first_name,
                                 middle_name = p.middle_name,
                                 last_name = p.last_name,
                                 display_name = p.display_name,
                                 mob_room = p.mob_room,
                                 doc_contacts = p.doctors_contacts.Select(a => new DoctorsDTO.doctors_contacts
                                 {
                                     contact_type = a.contact_type,
                                     contact_number = a.contact_number
                                 }),
                                 doc_depts = p.doctors_department.Select(b => new DoctorsDTO.doctors_departments
                                 {
                                     department_id = b.department_id,
                                     department_name = b.department_name
                                 }),
                                 doc_specs = p.doctors_specialization.Select(c => new DoctorsDTO.doctors_specializations
                                 {
                                     specialization_id = c.specialization_id,
                                     specialization_name = c.specialization_name
                                 })

                             }).OrderBy(a => a.last_name.Trim());

            return doctors;
        }
    }
}