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
    
    public partial class NotasDesempenoAvances
    {
        public int IdNotasDesempenoAvances { get; set; }
        public System.DateTime Fecha { get; set; }
        public System.TimeSpan Hora { get; set; }
        public string Sucursal { get; set; }
        public int NoSemana { get; set; }
        public string Tipo { get; set; }
        public decimal ImporteFact { get; set; }
        public decimal IvaFact { get; set; }
        public decimal TotalFact { get; set; }
        public decimal Abono { get; set; }
        public decimal GastosOP { get; set; }
        public int cantidad { get; set; }
    }
}
