﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OpenAPI.Models.PatientModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class patient_entities : DbContext
    {
        public patient_entities()
            : base("name=patient_entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<patient> patients { get; set; }
        public virtual DbSet<patient_allergies> patient_allergies { get; set; }
        public virtual DbSet<patient_diagnosis> patient_diagnosis { get; set; }
        public virtual DbSet<patient_medications> patient_medications { get; set; }
        public virtual DbSet<patient_previous_hospitalizations> patient_previous_hospitalizations { get; set; }
        public virtual DbSet<patient_previous_surgeries> patient_previous_surgeries { get; set; }
        public virtual DbSet<patient_visit> patient_visit { get; set; }
        public virtual DbSet<patient_deposit_balance> patient_deposit_balance { get; set; }
        public virtual DbSet<patient_items_used> patient_items_used { get; set; }
    }
}
