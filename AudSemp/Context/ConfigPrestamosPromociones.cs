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
    
    public partial class ConfigPrestamosPromociones
    {
        public int Id { get; set; }
        public string NombrePromocion { get; set; }
        public System.DateTime VigenciaDel { get; set; }
        public System.DateTime VigenciaAl { get; set; }
        public string TiposAdmitidos { get; set; }
        public string TiposAdmitidosPrestamo { get; set; }
        public int LimiteMaximoDePTS { get; set; }
        public decimal OtorgaPTSxCada { get; set; }
        public int PTS { get; set; }
        public int LimiteMaximoPTSXCadaOp { get; set; }
        public string Status { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Registro { get; set; }
    }
}
