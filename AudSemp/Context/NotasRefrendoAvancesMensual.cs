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
    
    public partial class NotasRefrendoAvancesMensual
    {
        public int IdNotasRefrendoAvancesMensual { get; set; }
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
