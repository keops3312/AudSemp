//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AudSemp.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class ContratoDesempenoC
    {
        public int IdContratoDesemp { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<System.TimeSpan> Hora { get; set; }
        public string Sucursal { get; set; }
        public Nullable<int> NoSemana { get; set; }
        public string Tipo { get; set; }
        public Nullable<int> Cantidad { get; set; }
        public Nullable<decimal> Prestamo { get; set; }
        public Nullable<decimal> ImporteFact { get; set; }
        public Nullable<decimal> IvaFact { get; set; }
        public Nullable<decimal> TotalFact { get; set; }
    }
}