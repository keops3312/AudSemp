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
    
    public partial class ClientesPtsPromociones
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string Cliente { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public decimal Entrada { get; set; }
        public decimal Salida { get; set; }
        public decimal Saldo { get; set; }
        public string TipoMov { get; set; }
        public string EntXopTipo { get; set; }
        public string Folio { get; set; }
        public string Xpromocion { get; set; }
        public string Caja { get; set; }
        public string Registro { get; set; }
        public string Status { get; set; }
        public string Comentario { get; set; }
        public string Inventario { get; set; }
    }
}