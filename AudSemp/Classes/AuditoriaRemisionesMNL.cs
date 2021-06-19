

namespace AudSemp.Classes
{
    #region Libraries

    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using AudSemp.Context;
    //using OperSemp.Context; 
    #endregion
    public class AuditoriaRemisionesMNL
    {
        #region Notes
        /*campos para auditoria
     * Auditado bool
     * Audita string 
     * FechaAudita Date
     */

        /*campos para operaciones
         * Autorizado bool
         * Autoriza string
         * FechaAutoriza Date
         */

        /*auditado	bit	Checked
        audita	nvarchar(150)	Checked
        fechaAuditado	date	Checked
        comentarioAuditado	nvarchar(150)	Checked
        autorizado	bit	Checked
        autoriza	nvarchar(150)	Checked
        fechaAutoriza	date	Checked
        comentarioAutorizado	nvarchar(150)	Checked*/

        /*descuentos MNL (manuales para autorizar*/
        #endregion

        #region Context
        private SEMP2013_Context db;


        public AuditoriaRemisionesMNL()
        {
            db = new SEMP2013_Context();
        }
        #endregion

        #region properties
        public List<remisiones> listaRemisiones;
        #endregion

        #region methods
        public bool listaRevisionRemisiones(string caja, string usuario, DateTime fechaInicial, DateTime fechafinal)
        {
            try
            {

                listaRemisiones = new List<remisiones>();
                if (caja == "TODAS")
                {
                    caja = string.Empty;
                }

                if (usuario == "TODOS")
                {

                    usuario = string.Empty;
                }

                /*solo fecha*/
                if (string.IsNullOrEmpty(caja) && string.IsNullOrEmpty(usuario))
                {

                    listaRemisiones = db.remisiones.Where(u => u.conceptopromocion.Contains("(MNL)")
                                        && u.status == "VENDIDO" &&
                                        u.Fecha >= fechaInicial && u.Fecha <= fechafinal).OrderBy(u => u.Fecha).ToList();


                }

                /*caja y usuario*/
                if (!string.IsNullOrEmpty(caja) && !string.IsNullOrEmpty(usuario))
                {

                    listaRemisiones = db.remisiones.Where(u => u.conceptopromocion.Contains("(MNL)")
                                        && u.status == "VENDIDO" && u.caja == caja && u.vendio == usuario
                                        && u.Fecha >= fechaInicial && u.Fecha <= fechafinal).OrderBy(u => u.Fecha).ToList();


                }


                /*caja*/
                if (!string.IsNullOrEmpty(caja) && string.IsNullOrEmpty(usuario))
                {

                    listaRemisiones = db.remisiones.Where(u => u.conceptopromocion.Contains("(MNL)")
                                        && u.status == "VENDIDO" && u.caja == caja
                                        && u.Fecha >= fechaInicial && u.Fecha <= fechafinal).OrderBy(u => u.Fecha).ToList();


                }

                /*usuario*/
                if (string.IsNullOrEmpty(caja) && !string.IsNullOrEmpty(usuario))
                {

                    listaRemisiones = db.remisiones.Where(u => u.conceptopromocion.Contains("(MNL)")
                                        && u.status == "VENDIDO" && u.vendio == usuario
                                        && u.Fecha >= fechaInicial && u.Fecha <= fechafinal).OrderBy(u => u.Fecha).ToList();


                }

                return true;

            }
            catch (Exception ex)
            {

                return false;
            }


        }

        public List<string> cajas()
        {
            List<string> misCajas = new List<string>();
            var cajas = db.selcaja.ToList();

            if (cajas != null)
            {
                misCajas.Add("TODAS");
                foreach (var item in cajas)
                {
                    misCajas.Add(item.Caja);
                }

            }



            return misCajas;
        }


        public List<string> usuarios()
        {
            List<string> misUsuarios = new List<string>();
            var usuarios = db.remisiones.Select(p=>p.vendio).Distinct().ToList();

            if (usuarios != null)
            {
                misUsuarios.Add("TODOS");
                foreach (var item in usuarios)
                {
                    misUsuarios.Add(item.ToString());
                }

            }



            return misUsuarios;
        }


        public DateTime final()
        {
            
            string Final="1999-01-01";
            DateTime date = DateTime.Parse(Final);


            var fecha = db.remisiones.Where(u => u.conceptopromocion.Contains("(MNL)"))
                 .OrderByDescending(p => p.Fecha).FirstOrDefault();
            if (fecha!= null)
            {

                date = DateTime.Parse(fecha.Fecha.ToString());

            }

            return date;
        }


        public DateTime inicial()
        {

            string Final = "1999-01-01";
            DateTime date = DateTime.Parse(Final);


            var fecha = db.remisiones.Where(u => u.conceptopromocion.Contains("(MNL)"))
                 .OrderBy(p => p.Fecha).FirstOrDefault();
            if (fecha != null)
            {

                date = DateTime.Parse(fecha.Fecha.ToString());

            }

            return date;
        }

        public bool updateAutorizaRem(int consec, string autoriza, string autorizo, DateTime fecha, string comentario)
        {
            using (var context = new SEMP2013_Context())
            {
                using (DbContextTransaction dbTran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var remision = context.remisiones.
                            Where(p => p.consec==consec).FirstOrDefault();

                        if (remision== null)
                        {
                            return false;
                        }

                        remision.autoriza = autoriza;
                        remision.autorizado = autorizo;
                        remision.fechaAutoriza = fecha;
                        remision.comentarioAutorizado = comentario;
                        
                        context.Entry(remision).State = EntityState.Modified;
                        context.SaveChanges();

                        dbTran.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        //Rollback transaction if exception occurs    
                        dbTran.Rollback();
                        return false;
                    }
                }
            }



        }


    
        #endregion


    }
}
