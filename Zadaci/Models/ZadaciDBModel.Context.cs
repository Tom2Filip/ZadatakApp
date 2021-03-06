﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Zadaci.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ZadaciDBEntities : DbContext
    {
        public ZadaciDBEntities()
            : base("name=ZadaciDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Zadatak> Zadaci { get; set; }
    
        public virtual int InsertZadatak(Nullable<System.DateTime> start, string naslov, string opis, Nullable<bool> status, Nullable<System.DateTime> kraj)
        {
            var startParameter = start.HasValue ?
                new ObjectParameter("Start", start) :
                new ObjectParameter("Start", typeof(System.DateTime));
    
            var naslovParameter = naslov != null ?
                new ObjectParameter("Naslov", naslov) :
                new ObjectParameter("Naslov", typeof(string));
    
            var opisParameter = opis != null ?
                new ObjectParameter("Opis", opis) :
                new ObjectParameter("Opis", typeof(string));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(bool));
    
            var krajParameter = kraj.HasValue ?
                new ObjectParameter("Kraj", kraj) :
                new ObjectParameter("Kraj", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertZadatak", startParameter, naslovParameter, opisParameter, statusParameter, krajParameter);
        }
    }
}
