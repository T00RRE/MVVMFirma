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
    
    public partial class Promocja
    {
        public int IdPromocji { get; set; }
        public string NazwaPromocji { get; set; }
        public System.DateTime DataRozpoczecia { get; set; }
        public System.DateTime DataZakonczenia { get; set; }
        public Nullable<decimal> WysokoscRabatu { get; set; }
        public string OpisPromocji { get; set; }
        public Nullable<bool> CzyAktywna { get; set; }
    }
}