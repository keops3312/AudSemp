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
    
    public partial class ArtPromociones
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public string Inventario { get; set; }
        public string Descripcion { get; set; }
        public string SubDescripcion { get; set; }
        public string Tipo { get; set; }
        public string Imagen { get; set; }
        public decimal Costo { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal PrecioPunto { get; set; }
        public decimal PrecioPromocion { get; set; }
        public decimal PrecioRemate { get; set; }
        public string Localidad { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Registro { get; set; }
        public Nullable<int> PartPa { get; set; }
        public Nullable<int> PartPb { get; set; }
        public Nullable<int> PartPc { get; set; }
        public string Status { get; set; }
    }
}