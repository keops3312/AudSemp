

namespace AudSemp.Models
{
    #region Libraries (librerias) 
    using System.Data;
    using System.Linq;
    using AudSemp.Context;
    #endregion
    public class LocalidadModel
    {

        #region Context
        private SEMP2013_Context db;// = new MySqlConnectionContext();
        public LocalidadModel()
        {
            db = new SEMP2013_Context();
        }

        #endregion

        #region Attributes (atributos)
        public string sucursal { get; set; }
        public string marca { get; set; }
        public string empresa { get; set; }

        public string encargado { get; set; }

        public string localidad { get; set; }
        public string logotipo { get; set; }

        public string clave { get; set; }
        #endregion

        #region Methods

        public int localidadResult(string clave)
        {
            var localidadUsr = db.Localidades.Where(p => p.LOCALIDAD == clave).First();

            sucursal = localidadUsr.Nombre_Sucursal;
            marca = localidadUsr.Marca;
            empresa = localidadUsr.Empresa;
            encargado = localidadUsr.ENCARGADO;
            localidad = localidadUsr.LOCALIDAD;
            logotipo = localidadUsr.Logotipo;
            clave = localidadUsr.LOCALIDAD;

          
            return 0;
        }

        #endregion

    }
}
