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
