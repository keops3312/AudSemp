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
    
    public partial class documentosCorte
    {
        public int IdDocumentoCorte { get; set; }
        public string Sucursal { get; set; }
        public string Hora { get; set; }
        public string Caja { get; set; }
        public string Registro { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Concepto { get; set; }
        public decimal Importe { get; set; }
        public bool Estatus { get; set; }
        public Nullable<System.DateTime> FechaGasto { get; set; }
    }
}