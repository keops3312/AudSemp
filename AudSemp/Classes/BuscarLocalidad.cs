﻿

namespace AudSemp.Classes
{

    #region Libraries (librerias)
    using System;
    using System.Linq;
    using AudSemp.Context;
    using AudSemp.Properties;
    #endregion
    public class BuscarLocalidad
    {
        #region Context
        private SEMP2013_Context db;
       
        
        public BuscarLocalidad()
        {
            db = new SEMP2013_Context();
           // db.Database.Connection.ConnectionString = Settings.Default["data"].ToString();
           
        }
        #endregion

        #region Methods (metodos)
        public String[] LocalidadBuscada()
        {


            String[] array = new string[6];
            var localidad = db.Localidades.Where(p => p.impresora == "RAIZ").First();

            array[0] = localidad.LOCALIDAD;
            array[1] = localidad.Nombre_Sucursal;
            array[2] = localidad.DIRECCION;
            array[3] = localidad.Empresa;
            array[4] = localidad.ENCARGADO;
            array[5] = localidad.Logotipo;


            return array;
        }


        public Localidades localidades()
        {
            var localidad = db.Localidades.Where(p => p.impresora == "RAIZ").First();

            return localidad;

        }
        #endregion
    }
}
