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
    
    public partial class PuntosClientes
    {
        public int IdPuntosCliente { get; set; }
        public Nullable<int> IdCliente { get; set; }
        public Nullable<int> PtsIniciales { get; set; }
        public Nullable<int> PtsPrestamos { get; set; }
        public Nullable<int> PtsNP { get; set; }
        public Nullable<int> PtsRemisiones { get; set; }
        public Nullable<int> PtsApartados { get; set; }
        public Nullable<int> PtsUsados { get; set; }
        public Nullable<int> PtsTotales { get; set; }
        public string MovRealizadoPor { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public string NombrePromocion { get; set; }
        public string Operacion { get; set; }
    }
}
