using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenAPI.Models.DataTransferObjects
{
    public class PatientsDTO
    {
        public class Patients
        {
            public System.Guid patient_id { get; set; }
            public string hospital_number { get; set; }
            public Nullable<System.DateTime> registration_date { get; set; }
            public string last_name { get; set; }
            public string first_name { get; set; }
            public string middle_name { get; set; }
            public string display_name { get; set; }
            public System.DateTime date_of_birth { get; set; }
            public string gender { get; set; }
            public string marital_status { get; set; }
            public string nationality { get; set; }
            public string highest_education_level { get; set; }
            public string occupation { get; set; }

            public IEnumerable<PatientAllergiesOnly> patient_allergies { get; set; }
            public IEnumerable<PatientDiagnosisOnly> patient_diagnosis { get; set; }
            public IEnumerable<PatientMedicationsOnly> patient_medications { get; set; }
            public IEnumerable<PatientPrevHospitalizationsOnly> patient_prev_hospitalizations { get; set; }
            public IEnumerable<PatientPrevSurgeriesOnly> patient_prev_surgeries { get; set; }
        }

        public class PatientInfo
        {
            public System.Guid patient_id { get; set; }
            public string hospital_number { get; set; }
            public Nullable<System.DateTime> registration_date { get; set; }
            public string last_name { get; set; }
            public string first_name { get; set; }
            public string middle_name { get; set; }
            public string display_name { get; set; }
            public System.DateTime date_of_birth { get; set; }
            public string gender { get; set; }
            public string marital_status { get; set; }
            public string nationality { get; set; }
            public string highest_education_level { get; set; }
            public string occupation { get; set; }
        }

        public class PatientAllergies
        {
            public System.Guid patient_id { get; set; }
            public string hospital_number { get; set; }
            public string last_name { get; set; }
            public string first_name { get; set; }
            public string middle_name { get; set; }
            public string display_name { get; set; }

            public IEnumerable<PatientAllergiesOnly> patient_allergies { get; set; }
        }

        public class PatientAllergiesOnly
        {
            public System.Guid patient_adverse_reaction_cause_id { get; set; }
            public string cause { get; set; }
            public string reaction { get; set; }
            public string reaction_cause_status { get; set; }
            public Nullable<System.DateTime> created_date_time { get; set; }
        }

        public class PatientDiagnosis
        {
            public System.Guid patient_id { get; set; }
            public string hospital_number { get; set; }
            public string last_name { get; set; }
            public string first_name { get; set; }
            public string middle_name { get; set; }
            public string display_name { get; set; }

            public IEnumerable<PatientDiagnosisOnly> patient_diagnosis { get; set; }
        }

        public class PatientDiagnosisOnly
        {
            public System.Guid patient_visit_id { get; set; }
            public System.Guid patient_medical_coding_id { get; set; }
            public Nullable<System.DateTime> actual_visit_date_time { get; set; }
            public string visit_type { get; set; }
            public string charge_type { get; set; }
            public string coding_type { get; set; }
            public string coding_system { get; set; }
            public string code { get; set; }
            public string diagnosis { get; set; }
            public Nullable<System.DateTime> recorded_date_time { get; set; }
            public Nullable<bool> active_flag { get; set; }
            public Nullable<bool> primary_flag { get; set; }
            public Nullable<bool> current_visit_diagnostic_flag { get; set; }
        }

        public class PatientMedications
        {
            public System.Guid patient_id { get; set; }
            public string hospital_number { get; set; }
            public string last_name { get; set; }
            public string first_name { get; set; }
            public string middle_name { get; set; }
            public string display_name { get; set; }

            public IEnumerable<PatientMedicationsOnly> patient_medications { get; set; }
        }

        public class PatientMedicationsOnly
        {
            public System.Guid note_id { get; set; }
            public string details { get; set; }
            public Nullable<System.DateTime> note_date { get; set; }
            public Nullable<bool> active_flag { get; set; }
        }

        public class PatientPrevHospitalizations
        {
            public System.Guid patient_id { get; set; }
            public string hospital_number { get; set; }
            public string last_name { get; set; }
            public string first_name { get; set; }
            public string middle_name { get; set; }
            public string display_name { get; set; }

            public IEnumerable<PatientPrevHospitalizationsOnly> patient_previous_hospitalizations { get; set; }
        }

        public class PatientPrevHospitalizationsOnly
        {
            public System.Guid patient_visit_id { get; set; }
            public Nullable<System.DateTime> actual_visit_date_time { get; set; }
            public Nullable<System.DateTime> closure_date_time { get; set; }
            public string visit_type { get; set; }
            public string visit_type_group { get; set; }
            public string charge_type { get; set; }
            public string primary_service { get; set; }
        }

        public class PatientPrevSurgeries
        {
            public System.Guid patient_id { get; set; }
            public string hospital_number { get; set; }
            public string last_name { get; set; }
            public string first_name { get; set; }
            public string middle_name { get; set; }
            public string display_name { get; set; }

            public IEnumerable<PatientPrevSurgeriesOnly> patient_previous_surgeries { get; set; }
        }

        public class PatientPrevSurgeriesOnly
        {
            public string previous_surgeries { get; set; }
        }

        public class PatientBill
        {
            public string hospital_number { get; set; }
            public System.DateTime actual_visit_date_time { get; set; }
            public decimal? total_deposit { get; set; }
            public decimal? charged_amount { get; set; }

            //public IEnumerable<ItemsUsed> patient_items_used { get; set; }
            //public IEnumerable<Deposit> patient_deposit_balance { get; set; }
        }

        public class ItemsUsed
        {
            public string item_name { get; set; }
            public decimal amount { get; set; }
        }

        public class Deposit
        {
            public Nullable<decimal> deposit_amount { get; set; }
            public Nullable<decimal> used_amount { get; set; }
        }
    }
}