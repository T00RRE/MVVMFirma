//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVVMFirma.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class ZamowienieHurtowe
    {
        public int IdZamowienia { get; set; }
        public Nullable<int> IdKontrahenta { get; set; }
        public System.DateTime DataZamowienia { get; set; }
        public Nullable<System.DateTime> TerminRealizacji { get; set; }
        public string Status { get; set; }
        public Nullable<decimal> WartoscZamowienia { get; set; }
    
        public virtual Kontrahent Kontrahent { get; set; }
    }
}
