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
    
    public partial class Reimpresiones
    {
        public int no { get; set; }
        public string reimpresion { get; set; }
        public Nullable<decimal> costo { get; set; }
        public string folio_reimpreso { get; set; }
        public string folio_nuevo { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public string caja { get; set; }
        public string cliente { get; set; }
        public string id_cliente { get; set; }
        public string realizo { get; set; }
        public string jefe { get; set; }
        public string audita { get; set; }
        public string autoriza { get; set; }
        public string comentariosAudita { get; set; }
        public Nullable<bool> chkAudita { get; set; }
        public string comentariosAutoriza { get; set; }
        public Nullable<bool> chkAutoriza { get; set; }
        public string contratoReimpreso { get; set; }
        public string bolsa { get; set; }
    }
}
