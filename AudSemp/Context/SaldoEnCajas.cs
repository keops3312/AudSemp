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
    
    public partial class SaldoEnCajas
    {
        public int IdSaldoEnCajas { get; set; }
        public string Sucursal { get; set; }
        public string Caja { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public decimal Boveda { get; set; }
        public decimal Documento { get; set; }
        public decimal Saldo { get; set; }
        public decimal TotalEfectivoBoveda { get; set; }
        public double Diferencia { get; set; }
        public decimal Efectivo { get; set; }
    }
}
