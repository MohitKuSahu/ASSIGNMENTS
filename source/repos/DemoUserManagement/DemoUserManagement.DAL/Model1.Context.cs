﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DemoUserManagement.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FORMEntities : DbContext
    {
        public FORMEntities()
            : base("name=FORMEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AddressDetail> AddressDetails { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }
    }
}
