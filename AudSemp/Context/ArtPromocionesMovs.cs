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
    
    public partial class ArtPromocionesMovs
    {
        public int Id { get; set; }
        public string Inventario { get; set; }
        public int Cantidad { get; set; }
        public int Entrada { get; set; }
        public int Salida { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public string Registro { get; set; }
        public Nullable<decimal> PrecioVenta { get; set; }
        public Nullable<decimal> PrecioPuntos { get; set; }
        public Nullable<int> IdCliente { get; set; }
        public string Cliente { get; set; }
        public string Caja { get; set; }
        public string Comentario { get; set; }
        public string Status { get; set; }
        public string Folio { get; set; }
    }
}