//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
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
