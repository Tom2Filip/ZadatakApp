//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Zadatak
    {
        public int Id { get; set; }
        public System.DateTime Start { get; set; }
        public string Naslov { get; set; }
        public string Opis { get; set; }
        public bool Status { get; set; }
        public Nullable<System.DateTime> Kraj { get; set; }
    }
}
