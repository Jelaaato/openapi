﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OpenAPI.Models.DoctorModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class doctor_entities : DbContext
    {
        public doctor_entities()
            : base("name=doctor_entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<department> departments { get; set; }
        public virtual DbSet<doctor> doctors { get; set; }
        public virtual DbSet<doctors_contacts> doctors_contacts { get; set; }
        public virtual DbSet<doctors_department> doctors_department { get; set; }
        public virtual DbSet<doctors_specialization> doctors_specialization { get; set; }
    }
}
