using OpenAPI.Models.EmployeeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenAPI.Models.DataTransferObjects;
using OpenAPI.Models.PatientModel;
using OpenAPI.Models.ValidationModel;

namespace OpenAPI.Methods
{
    public class Patient
    {
        private patient_entities db = new patient_entities();
        private UserTypesEntities validdb = new UserTypesEntities();

        public IEnumerable<PatientsDTO.Patients> GetAllPatientDetails()
        {
            var patient = db.patients.Include("patient_allergies")
                            .Select(p => new PatientsDTO.Patients
                            {
                                patient_id = p.patient_id,
                                hospital_number = p.hospital_number,
                                last_name = p.last_name,
                                first_name = p.first_name,
                                middle_name = p.middle_name,
                                display_name = p.display_name,
                                date_of_birth = p.date_of_birth,
                                gender = p.gender,
                                marital_status = p.marital_status,
                                nationality = p.nationality,
                                highest_education_level = p.highest_education_level,
                                occupation = p.occupation,
                                registration_date = p.registration_date,
                                patient_allergies = db.patient_allergies.Select(b => new PatientsDTO.PatientAllergiesOnly
                                {
                                    cause = b.cause,
                                    reaction = b.reaction,
                                    reaction_cause_status = b.reaction_cause_status
                                }),
                                patient_medications = db.patient_medications.Select(c => new PatientsDTO.PatientMedicationsOnly
                                {
                                    note_id = c.note_id,
                                    note_date = c.note_date,
                                    details = c.details,
                                    active_flag = c.active_flag
                                }),
                                patient_prev_hospitalizations = db.patient_previous_hospitalizations.Select(d => new PatientsDTO.PatientPrevHospitalizationsOnly
                                {
                                    patient_visit_id = d.patient_visit_id,
                                    actual_visit_date_time = d.actual_visit_date_time,
                                    closure_date_time = d.closure_date_time,
                                    visit_type_group = d.visit_type_group,
                                    visit_type = d.visit_type,
                                    primary_service = d.primary_service,
                                    charge_type = d.charge_type
                                }),
                                patient_prev_surgeries = db.patient_previous_surgeries.Select(e => new PatientsDTO.PatientPrevSurgeriesOnly
                                {
                                    previous_surgeries = e.previous_surgeries
                                }),
                                patient_diagnosis = db.patient_diagnosis.Select(f => new PatientsDTO.PatientDiagnosisOnly {
                                    patient_medical_coding_id = f.patient_medical_coding_id,
                                    patient_visit_id = f.patient_visit_id,
                                    actual_visit_date_time = f.actual_visit_date_time,
                                    visit_type = f.visit_type,
                                    charge_type = f.charge_type,
                                    coding_system = f.coding_system,
                                    coding_type = f.coding_type,
                                    code = f.code,
                                    diagnosis = f.diagnosis,
                                    primary_flag = f.primary_flag,
                                    active_flag = f.active_flag,
                                    current_visit_diagnostic_flag = f.current_visit_diagnostic_flag,
                                    recorded_date_time = f.recorded_date_time
                                })
                            }).OrderBy(a => a.last_name);

            return patient;
        }

        public IEnumerable<PatientsDTO.Patients> GetAllPatientDetails(string hn, string name)
        {
            var patient = db.patients.Include("patient_allergies")
                            .Where(a => a.hospital_number == hn || a.display_name.Contains(name))
                            .Select(p => new PatientsDTO.Patients
                            {
                                patient_id = p.patient_id,
                                hospital_number = p.hospital_number,
                                last_name = p.last_name,
                                first_name = p.first_name,
                                middle_name = p.middle_name,
                                display_name = p.display_name,
                                date_of_birth = p.date_of_birth,
                                gender = p.gender,
                                marital_status = p.marital_status,
                                nationality = p.nationality,
                                highest_education_level = p.highest_education_level,
                                occupation = p.occupation,
                                registration_date = p.registration_date,
                                patient_allergies = db.patient_allergies.Select(b => new PatientsDTO.PatientAllergiesOnly
                                {
                                    cause = b.cause,
                                    reaction = b.reaction,
                                    reaction_cause_status = b.reaction_cause_status
                                }),
                                patient_medications = db.patient_medications.Select(c => new PatientsDTO.PatientMedicationsOnly
                                {
                                    note_id = c.note_id,
                                    note_date = c.note_date,
                                    details = c.details,
                                    active_flag = c.active_flag
                                }),
                                patient_prev_hospitalizations = db.patient_previous_hospitalizations.Select(d => new PatientsDTO.PatientPrevHospitalizationsOnly
                                {
                                    patient_visit_id = d.patient_visit_id,
                                    actual_visit_date_time = d.actual_visit_date_time,
                                    closure_date_time = d.closure_date_time,
                                    visit_type_group = d.visit_type_group,
                                    visit_type = d.visit_type,
                                    primary_service = d.primary_service,
                                    charge_type = d.charge_type
                                }),
                                patient_prev_surgeries = db.patient_previous_surgeries.Select(e => new PatientsDTO.PatientPrevSurgeriesOnly
                                {
                                    previous_surgeries = e.previous_surgeries
                                }),
                                patient_diagnosis = db.patient_diagnosis.Select(f => new PatientsDTO.PatientDiagnosisOnly
                                {
                                    patient_medical_coding_id = f.patient_medical_coding_id,
                                    patient_visit_id = f.patient_visit_id,
                                    actual_visit_date_time = f.actual_visit_date_time,
                                    visit_type = f.visit_type,
                                    charge_type = f.charge_type,
                                    coding_system = f.coding_system,
                                    coding_type = f.coding_type,
                                    code = f.code,
                                    diagnosis = f.diagnosis,
                                    primary_flag = f.primary_flag,
                                    active_flag = f.active_flag,
                                    current_visit_diagnostic_flag = f.current_visit_diagnostic_flag,
                                    recorded_date_time = f.recorded_date_time
                                })
                            }).OrderBy(a => a.last_name);

            return patient;
        }

        public IEnumerable<PatientsDTO.PatientInfo> GetPatients()
        {
            var patients = (from p in db.patients
                             select new PatientsDTO.PatientInfo
                             {
                                 patient_id = p.patient_id,
                                 hospital_number = p.hospital_number,
                                 last_name = p.last_name,
                                 first_name = p.first_name,
                                 middle_name = p.middle_name,
                                 display_name = p.display_name,
                                 date_of_birth = p.date_of_birth,
                                 gender = p.gender,
                                 marital_status = p.marital_status,
                                 nationality = p.nationality,
                                 highest_education_level = p.highest_education_level,
                                 occupation = p.occupation,
                                 registration_date = p.registration_date
                             }).OrderBy(p => p.last_name).ToList();

            return patients;
        }

        public IEnumerable<PatientsDTO.PatientInfo> GetPatients(string hn, string name)
        {
            var patients = (from p in db.patients
                            .Where(p => p.hospital_number == hn || p.display_name.Contains(name))
                            select new PatientsDTO.PatientInfo
                            {
                                patient_id = p.patient_id,
                                hospital_number = p.hospital_number,
                                last_name = p.last_name,
                                first_name = p.first_name,
                                middle_name = p.middle_name,
                                display_name = p.display_name,
                                date_of_birth = p.date_of_birth,
                                gender = p.gender,
                                marital_status = p.marital_status,
                                nationality = p.nationality,
                                highest_education_level = p.highest_education_level,
                                occupation = p.occupation,
                                registration_date = p.registration_date
                            }).OrderBy(p => p.last_name).ToList();

            return patients;
        }

        public IEnumerable<PatientsDTO.PatientAllergiesOnly> GetPatientAllergies()
        {
            //var patient_allergies = db.patients.Include("patient_allergies")
            //                          .Select(a => new PatientsDTO.PatientAllergies
            //                          {
            //                              patient_id = a.patient_id,
            //                              hospital_number = a.hospital_number,
            //                              last_name = a.last_name,
            //                              first_name = a.first_name,
            //                              middle_name = a.middle_name,
            //                              display_name = a.display_name,
            //                              patient_allergies = db.patient_allergies.Select(b => new PatientsDTO.PatientAllergiesOnly
            //                              {
            //                                  patient_id = b.patient_id,
            //                                  patient_adverse_reaction_cause_id = b.patient_adverse_reaction_cause_id,
            //                                  cause = b.cause,
            //                                  reaction = b.reaction,
            //                                  reaction_cause_status = b.reaction_cause_status
            //                              })
            //                          }).OrderBy(a => a.display_name);

            var patient_allergies = db.patient_allergies.Select(a => new PatientsDTO.PatientAllergiesOnly
                                    {
                                        hospital_number = a.hospital_number,
                                        cause = a.cause,
                                        reaction = a.reaction,
                                        reaction_cause_status = a.reaction_cause_status
                                    }).OrderByDescending(a => a.cause);

            return patient_allergies;
        }

        public IEnumerable<PatientsDTO.PatientAllergiesOnly> GetPatientAllergies(string hn, string name)
        {
            //var patient_allergies = db.patients.Include("patient_allergies")
            //                          .Where(a => a.hospital_number == hn || a.display_name.Contains(name))
            //                          .Select(a => new PatientsDTO.PatientAllergies
            //                          {
            //                              patient_id = a.patient_id,
            //                              hospital_number = a.hospital_number,
            //                              last_name = a.last_name,
            //                              first_name = a.first_name,
            //                              middle_name = a.middle_name,
            //                              display_name = a.display_name,
            //                              patient_allergies = db.patient_allergies.Select(b => new PatientsDTO.PatientAllergiesOnly
            //                              {
            //                                  patient_adverse_reaction_cause_id = b.patient_adverse_reaction_cause_id,
            //                                  cause = b.cause,
            //                                  reaction = b.reaction,
            //                                  reaction_cause_status = b.reaction_cause_status
            //                              })
            //                          }).OrderBy(a => a.display_name);

            var patient_allergies = db.patient_allergies.Where(a => a.hospital_number == hn || a.display_name.Contains(name)).Select(a => new PatientsDTO.PatientAllergiesOnly
                                    {
                                        hospital_number = a.hospital_number,
                                        cause = a.cause,
                                        reaction = a.reaction,
                                        reaction_cause_status = a.reaction_cause_status
                                    }).OrderByDescending(a => a.cause);

            return patient_allergies;
        }

        public IEnumerable<PatientsDTO.PatientMedicationsOnly> GetPatientMedications()
        {
            //var patient_medications = db.patients.Include("patient_medications")
            //                            .Select(a => new PatientsDTO.PatientMedications
            //                            {
            //                                patient_id = a.patient_id,
            //                                hospital_number = a.hospital_number,
            //                                last_name = a.last_name,
            //                                first_name = a.first_name,
            //                                middle_name = a.middle_name,
            //                                display_name = a.display_name,
            //                                patient_medications = db.patient_medications.Select(b => new PatientsDTO.PatientMedicationsOnly
            //                                {
            //                                    note_id = b.note_id,
            //                                    note_date = b.note_date,
            //                                    details = b.details,
            //                                    active_flag = b.active_flag
            //                                })
            //                            }).OrderBy(a => a.last_name);

            var patient_medications = db.patient_medications.Select(b => new PatientsDTO.PatientMedicationsOnly
                                    {
                                        note_id = b.note_id,
                                        note_date = b.note_date,
                                        details = b.details,
                                        active_flag = b.active_flag
                                    }).OrderByDescending(b => b.note_date);

            return patient_medications;
        }

        public IEnumerable<PatientsDTO.PatientMedicationsOnly> GetPatientMedications(string hn, string name)
        {
            //var patient_medications = db.patients.Include("patient_medications")
            //                            .Where(a => a.hospital_number == hn || a.display_name.Contains(name))
            //                            .Select(a => new PatientsDTO.PatientMedications
            //                            {
            //                                patient_id = a.patient_id,
            //                                hospital_number = a.hospital_number,
            //                                last_name = a.last_name,
            //                                first_name = a.first_name,
            //                                middle_name = a.middle_name,
            //                                display_name = a.display_name,
            //                                patient_medications = db.patient_medications.Select(b => new PatientsDTO.PatientMedicationsOnly
            //                                {
            //                                    note_id = b.note_id,
            //                                    note_date = b.note_date,
            //                                    details = b.details,
            //                                    active_flag = b.active_flag
            //                                })
            //                            }).OrderBy(a => a.last_name);

            var patient_medications = db.patient_medications.Where(a => a.hospital_number == hn || a.display_name.Contains(name))
                                        .Select(b => new PatientsDTO.PatientMedicationsOnly
                                        {
                                            note_id = b.note_id,
                                            note_date = b.note_date,
                                            details = b.details,
                                            active_flag = b.active_flag
                                        }).OrderByDescending(b => b.note_date);

            return patient_medications;
        }

        public IEnumerable<PatientsDTO.PatientDiagnosisOnly> GetPatientDiagnosis()
        {
            //var patient_diagnosis = db.patients.Include("patient_diagnosis")
            //                          .Select(a => new PatientsDTO.PatientDiagnosis
            //                          {
            //                              patient_id = a.patient_id,
            //                              hospital_number = a.hospital_number,
            //                              last_name = a.last_name,
            //                              first_name = a.first_name,
            //                              middle_name = a.middle_name,
            //                              display_name = a.display_name,
            //                              patient_diagnosis = db.patient_diagnosis.Select(b => new PatientsDTO.PatientDiagnosisOnly
            //                              {
            //                                  patient_medical_coding_id = b.patient_medical_coding_id,
            //                                  patient_visit_id = b.patient_visit_id,
            //                                  actual_visit_date_time = b.actual_visit_date_time,
            //                                  visit_type = b.visit_type,
            //                                  charge_type = b.charge_type,
            //                                  coding_system = b.coding_system,
            //                                  coding_type = b.coding_type,
            //                                  code = b.code,
            //                                  diagnosis = b.diagnosis,
            //                                  primary_flag = b.primary_flag,
            //                                  active_flag = b.active_flag,
            //                                  current_visit_diagnostic_flag = b.current_visit_diagnostic_flag,
            //                                  recorded_date_time = b.recorded_date_time
            //                              })
            //                          }).OrderBy(a => a.last_name);

            var patient_diagnosis = db.patient_diagnosis.Select(b => new PatientsDTO.PatientDiagnosisOnly
                                          {
                                              patient_medical_coding_id = b.patient_medical_coding_id,
                                              patient_visit_id = b.patient_visit_id,
                                              actual_visit_date_time = b.actual_visit_date_time,
                                              visit_type = b.visit_type,
                                              charge_type = b.charge_type,
                                              coding_system = b.coding_system,
                                              coding_type = b.coding_type,
                                              code = b.code,
                                              diagnosis = b.diagnosis,
                                              primary_flag = b.primary_flag,
                                              active_flag = b.active_flag,
                                              current_visit_diagnostic_flag = b.current_visit_diagnostic_flag,
                                              recorded_date_time = b.recorded_date_time
                                          }).OrderByDescending(b => b.recorded_date_time);

            return patient_diagnosis;
        }

        public IEnumerable<PatientsDTO.PatientDiagnosisOnly> GetPatientDiagnosis(string hn, string name)
        {
            //var patient_diagnosis = db.patients.Include("patient_diagnosis")
            //                          .Where(a => a.hospital_number == hn || a.display_name.Contains(name))
            //                          .Select(a => new PatientsDTO.PatientDiagnosis
            //                          {
            //                              patient_id = a.patient_id,
            //                              hospital_number = a.hospital_number,
            //                              last_name = a.last_name,
            //                              first_name = a.first_name,
            //                              middle_name = a.middle_name,
            //                              display_name = a.display_name,
            //                              patient_diagnosis = db.patient_diagnosis.Select(b => new PatientsDTO.PatientDiagnosisOnly
            //                              {
            //                                  patient_medical_coding_id = b.patient_medical_coding_id,
            //                                  patient_visit_id = b.patient_visit_id,
            //                                  actual_visit_date_time = b.actual_visit_date_time,
            //                                  visit_type = b.visit_type,
            //                                  charge_type = b.charge_type,
            //                                  coding_system = b.coding_system,
            //                                  coding_type = b.coding_type,
            //                                  code = b.code,
            //                                  diagnosis = b.diagnosis,
            //                                  primary_flag = b.primary_flag,
            //                                  active_flag = b.active_flag,
            //                                  current_visit_diagnostic_flag = b.current_visit_diagnostic_flag,
            //                                  recorded_date_time = b.recorded_date_time
            //                              })
            //                          }).OrderBy(a => a.last_name);

            var patient_diagnosis = db.patient_diagnosis.Where(a => a.hospital_number == hn || a.display_name.Contains(name))
                                    .Select(b => new PatientsDTO.PatientDiagnosisOnly
                                    {
                                        patient_medical_coding_id = b.patient_medical_coding_id,
                                        patient_visit_id = b.patient_visit_id,
                                        actual_visit_date_time = b.actual_visit_date_time,
                                        visit_type = b.visit_type,
                                        charge_type = b.charge_type,
                                        coding_system = b.coding_system,
                                        coding_type = b.coding_type,
                                        code = b.code,
                                        diagnosis = b.diagnosis,
                                        primary_flag = b.primary_flag,
                                        active_flag = b.active_flag,
                                        current_visit_diagnostic_flag = b.current_visit_diagnostic_flag,
                                        recorded_date_time = b.recorded_date_time
                                    }).OrderByDescending(b => b.recorded_date_time);

            return patient_diagnosis;
        }

        public IEnumerable<PatientsDTO.PatientPrevHospitalizationsOnly> GetPatientPrevHospitalizations()
        {
            //var patient_prev_hospitalizations = db.patients.Include("patient_previous_hospitalizations")
            //                                      .Select(a => new PatientsDTO.PatientPrevHospitalizations
            //                                      {
            //                                          patient_id = a.patient_id,
            //                                          hospital_number = a.hospital_number,
            //                                          last_name = a.last_name,
            //                                          first_name = a.first_name,
            //                                          middle_name = a.middle_name,
            //                                          display_name = a.display_name,
            //                                          patient_previous_hospitalizations = db.patient_previous_hospitalizations.Select(b => new PatientsDTO.PatientPrevHospitalizationsOnly
            //                                          {
            //                                              patient_visit_id = b.patient_visit_id,
            //                                              actual_visit_date_time = b.actual_visit_date_time,
            //                                              closure_date_time = b.closure_date_time,
            //                                              visit_type_group = b.visit_type_group,
            //                                              visit_type = b.visit_type,
            //                                              primary_service = b.primary_service,
            //                                              charge_type = b.charge_type
            //                                          })
            //                                      }).OrderBy(a => a.last_name);

            var patient_prev_hospitalizations = db.patient_previous_hospitalizations.Select(b => new PatientsDTO.PatientPrevHospitalizationsOnly
                                                      {
                                                          patient_visit_id = b.patient_visit_id,
                                                          actual_visit_date_time = b.actual_visit_date_time,
                                                          closure_date_time = b.closure_date_time,
                                                          visit_type_group = b.visit_type_group,
                                                          visit_type = b.visit_type,
                                                          primary_service = b.primary_service,
                                                          charge_type = b.charge_type
                                                      }).OrderByDescending(b => b.actual_visit_date_time);
            return patient_prev_hospitalizations;
        }

        public IEnumerable<PatientsDTO.PatientPrevHospitalizationsOnly> GetPatientPrevHospitalizations(string hn, string name)
        {
            //var patient_prev_hospitalizations = db.patients.Include("patient_previous_hospitalizations")
            //                                      .Where(a => a.hospital_number == hn || a.display_name.Contains(name))
            //                                      .Select(a => new PatientsDTO.PatientPrevHospitalizations
            //                                      {
            //                                          patient_id = a.patient_id,
            //                                          hospital_number = a.hospital_number,
            //                                          last_name = a.last_name,
            //                                          first_name = a.first_name,
            //                                          middle_name = a.middle_name,
            //                                          display_name = a.display_name,
            //                                          patient_previous_hospitalizations = db.patient_previous_hospitalizations.Select(b => new PatientsDTO.PatientPrevHospitalizationsOnly
            //                                          {
            //                                              patient_visit_id = b.patient_visit_id,
            //                                              actual_visit_date_time = b.actual_visit_date_time,
            //                                              closure_date_time = b.closure_date_time,
            //                                              visit_type_group = b.visit_type_group,
            //                                              visit_type = b.visit_type,
            //                                              primary_service = b.primary_service,
            //                                              charge_type = b.charge_type
            //                                          })
            //                                      }).OrderBy(a => a.last_name);

            var patient_prev_hospitalizations = db.patient_previous_hospitalizations.Where(a => a.hospital_number == hn || a.display_name.Contains(name))
                                                .Select(b => new PatientsDTO.PatientPrevHospitalizationsOnly
                                                {
                                                    patient_visit_id = b.patient_visit_id,
                                                    actual_visit_date_time = b.actual_visit_date_time,
                                                    closure_date_time = b.closure_date_time,
                                                    visit_type_group = b.visit_type_group,
                                                    visit_type = b.visit_type,
                                                    primary_service = b.primary_service,
                                                    charge_type = b.charge_type
                                                }).OrderByDescending(b => b.actual_visit_date_time);

            return patient_prev_hospitalizations;
        }

        public IEnumerable<PatientsDTO.PatientPrevSurgeriesOnly> GetPatientPrevSurgeries()
        {
            //var patient_prev_surgeries = db.patients.Include("patient_previous_surgeries")
            //                               .Select(a => new PatientsDTO.PatientPrevSurgeries
            //                               {
            //                                   patient_id = a.patient_id,
            //                                   hospital_number = a.hospital_number,
            //                                   last_name = a.last_name,
            //                                   first_name = a.first_name,
            //                                   middle_name = a.middle_name,
            //                                   display_name = a.display_name,
            //                                   patient_previous_surgeries = db.patient_previous_surgeries.Select(b => new PatientsDTO.PatientPrevSurgeriesOnly
            //                                   {
            //                                       previous_surgeries = b.previous_surgeries
            //                                   })
            //                               }).OrderBy(a => a.last_name);
            var patient_prev_surgeries = db.patient_previous_surgeries.Select(b => new PatientsDTO.PatientPrevSurgeriesOnly
                                              {
                                                  previous_surgeries = b.previous_surgeries
                                              }).OrderBy(b => b.previous_surgeries);
                                           

            return patient_prev_surgeries;
        }

        public IEnumerable<PatientsDTO.PatientPrevSurgeriesOnly> GetPatientPrevSurgeries(string hn, string name)
        {
            //var patient_prev_surgeries = db.patients.Include("patient_previous_surgeries")
            //                               .Where(a => a.hospital_number == hn || a.display_name.Contains(name))
            //                               .Select(a => new PatientsDTO.PatientPrevSurgeries
            //                               {
            //                                   patient_id = a.patient_id,
            //                                   hospital_number = a.hospital_number,
            //                                   last_name = a.last_name,
            //                                   first_name = a.first_name,
            //                                   middle_name = a.middle_name,
            //                                   display_name = a.display_name,
            //                                   patient_previous_surgeries = db.patient_previous_surgeries.Select(b => new PatientsDTO.PatientPrevSurgeriesOnly
            //                                   {
            //                                       previous_surgeries = b.previous_surgeries
            //                                   })
            //                               }).OrderBy(a => a.last_name);

            var patient_prev_surgeries = db.patient_previous_surgeries.Where(a => a.hospital_number == hn || a.display_name.Contains(name))
                                        .Select(b => new PatientsDTO.PatientPrevSurgeriesOnly
                                        {
                                            previous_surgeries = b.previous_surgeries
                                        }).OrderBy(b => b.previous_surgeries);


            return patient_prev_surgeries;
        }



        public IEnumerable<PatientsDTO.PatientBill> GetPatientBill(string hn)
        {
            var total_deposit = this.GetTotalDeposit(hn);
            var items_used_total_amount = this.GetTotalAmountofItemsUsed(hn);

            var patient_bill = db.patient_visit.Include("patient_items_used")
                               .Where(a => a.hospital_number == hn)
                               .Select(a => new PatientsDTO.PatientBill
                               {
                                   hospital_number = a.hospital_number,
                                   actual_visit_date_time = a.actual_visit_date_time,
                                   total_deposit = total_deposit,
                                   charged_amount = items_used_total_amount
                                   //patient_items_used = db.patient_items_used.Where(b => b.hospital_number == hn).Select(b => new PatientsDTO.ItemsUsed
                                   //{
                                   //    item_name = b.item_name,
                                   //    amount = b.amount
                                   //})
                               });

            return patient_bill;
        }

        private decimal? GetTotalDeposit(string hn)
        {
            var id = (from a in db.patient_deposit_balance
                      join b in db.patient_visit on a.customer_id equals b.patient_id
                      where b.hospital_number == hn
                      select b.patient_id).First();

            var deposit = db.patient_deposit_balance.Where(a => a.customer_id == id).Select(a => a.deposit_amount).Sum();
            var used_amount = db.patient_deposit_balance.Where(a => a.customer_id == id).Select(a => a.used_amount).Sum();

            var total_deposit_amount = deposit + used_amount;

            return total_deposit_amount;
        }

        private decimal? GetTotalAmountofItemsUsed(string hn)
        {
            var id = (from a in db.patient_deposit_balance
                      join b in db.patient_visit on a.customer_id equals b.patient_id
                      where b.hospital_number == hn
                      select b.patient_id).First();

            var items_used_total_amount = db.patient_items_used.Where(a => a.patient_id == id).Select(a => a.amount).Sum();

            return items_used_total_amount;
        }

        public bool patientExists(string hn)
        {
            var isExists = validdb.validate_patient.Any(a => a.hospital_number == hn);
            return isExists;
        }

        public bool hasOpenVisit(string hn)
        {
            var isOpen = db.patient_visit.Any(a => a.hospital_number == hn);
            return isOpen;
        }
    }
}