
namespace AudSemp.Models
{

    #region Libraries 
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using AudSemp.Classes;
    using AudSemp.Context;
  
    #endregion



    public class AutorizaRemisionesMNLModel
    {

        #region Constructor
        private SEMP2013_Context db;
        public AutorizaRemisionesMNLModel()
        {
            db = new SEMP2013_Context();
        }

        #endregion


        #region Attributes
        public List<ModoOrdenes> Ordenes()
        {
            List<ModoOrdenes> ordenes = new List<ModoOrdenes>();
            ordenes.Clear();

            ordenes = new List<ModoOrdenes>()
            {



                new ModoOrdenes(){modo="Ascendente"},
                new ModoOrdenes(){modo="Descendente"}

             };
            return ordenes;


        }

        public List<TiposOrden> TiposOrden()
        {
            List<TiposOrden> tiposOrden = new List<TiposOrden>();


          
                tiposOrden.Clear();

                tiposOrden = new List<TiposOrden>()  {
                           new TiposOrden() { tipo ="Fecha"},
                           new TiposOrden() { tipo ="Remision"},
                           new TiposOrden() { tipo ="Tipo Prenda"},
                           new TiposOrden() { tipo ="Descuento"},
                           new TiposOrden() { tipo = "Status Auditado" },
                           new TiposOrden() { tipo = "Status Autorizado" }

             };

                return tiposOrden;


        }

        public List<string> TipoPrenda()
        {

            List<string> tiposList = new List<string>();

         
                var tipos = db.remisiones.Select(p => p.tipo_prenda).Distinct();

                foreach (var item in tipos)
                {
                    tiposList.Add(item);

                }

                return tiposList;
          
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

        public DateTime final()
        {

            string Final = "1999-01-01";
            DateTime date = DateTime.Parse(Final);


            var fecha = db.remisiones.Where(u => u.conceptopromocion.Contains("(MNL)"))
                 .OrderByDescending(p => p.Fecha).FirstOrDefault();
            if (fecha != null)
            {

                date = DateTime.Parse(fecha.Fecha.ToString());

            }

            return date;
        }


        public List<string> AuditoriaTipo()
        {

            List<string> tiposListAu = new List<string>();


            var tipos = db.remisiones.Select(p => p.auditado).Distinct();

            foreach (var item in tipos)
            {
                tiposListAu.Add(item);

            }

            return tiposListAu;

        }



        public List<string> AutorizaTipo()
        {

            List<string> tiposListAu = new List<string>();


            var tipos = db.remisiones.Select(p => p.autorizado).Distinct();

            foreach (var item in tipos)
            {
                tiposListAu.Add(item);

            }

            return tiposListAu;

        }

        public List<remisiones> listaRemisiones;

        public DataTable dtRemisiones;
        #endregion

        #region Principal Methods
        public bool listaRevisionRemisiones(DateTime fechaInicial, DateTime fechafinal,
         string[] tipos, string[] statusAudita, string[] statusAutorizado)
        {
            try
            {

                string _queryTipo = "";
                string _queryAudita = "";
                string _queryAutoriza = "";

                if (tipos.Length == 1)
                {
                    _queryTipo = tipos[0];
                }
                else
                {
                    int i = 0;
                    foreach (string item in tipos)
                    {
                        if (i == 0)
                        {
                            _queryTipo += item;
                            i = 1;
                        }
                        else
                        {
                            _queryTipo += "," + item;//'xxx'=>first,'xxx','xxx'
                        }

                    }
                }


                if (statusAudita.Length == 1)
                {
                    _queryAudita = statusAudita[0];
                }
                else
                {
                    int i = 0;
                    foreach (string item in statusAudita)
                    {
                        if (i == 0)
                        {
                            _queryAudita += item;
                            i = 1;
                        }
                        else
                        {
                            _queryAudita += "," + item;//'xxx'=>first,'xxx','xxx'
                        }

                    }
                }


                if (statusAutorizado.Length == 1)
                {
                    _queryAutoriza = statusAutorizado[0];
                }
                else
                {
                    int i = 0;
                    foreach (string item in statusAutorizado)
                    {
                        if (i == 0)
                        {
                            _queryAutoriza += item;
                            i = 1;
                        }
                        else
                        {
                            _queryAutoriza += "," + item;//'xxx'=>first,'xxx','xxx'
                        }

                    }
                }



                listaRemisiones = new List<remisiones>();
                dtRemisiones = new DataTable("Remisiones");

               
                dtRemisiones.Columns.Add("NumRemision", typeof(System.String));
                dtRemisiones.Columns.Add("Fecha", typeof(System.DateTime));
                dtRemisiones.Columns.Add("Cliente", typeof(System.String));
                dtRemisiones.Columns.Add("Inventario", typeof(System.String));
                dtRemisiones.Columns.Add("Precio", typeof(System.Decimal));
                dtRemisiones.Columns.Add("Descuento", typeof(System.Decimal));
                dtRemisiones.Columns.Add("Importe", typeof(System.Decimal));
                dtRemisiones.Columns.Add("Cantidad", typeof(System.Int32));
                dtRemisiones.Columns.Add("Descripcion", typeof(System.String));
                dtRemisiones.Columns.Add("conceptopromocion", typeof(System.String));
                dtRemisiones.Columns.Add("noserieart", typeof(System.String));
                dtRemisiones.Columns.Add("codebar", typeof(System.String));
                dtRemisiones.Columns.Add("vendio", typeof(System.String));
                dtRemisiones.Columns.Add("suc", typeof(System.String));
                dtRemisiones.Columns.Add("status", typeof(System.String));
                dtRemisiones.Columns.Add("idcliente", typeof(System.String));
                dtRemisiones.Columns.Add("comentarios", typeof(System.String));
                dtRemisiones.Columns.Add("caja", typeof(System.String));
                dtRemisiones.Columns.Add("tipo_desc", typeof(System.String));
                dtRemisiones.Columns.Add("tipo_prenda", typeof(System.String));
                dtRemisiones.Columns.Add("consec", typeof(System.Int32));
                dtRemisiones.Columns.Add("noRemate", typeof(System.Int32));
                dtRemisiones.Columns.Add("precioRemate", typeof(System.Decimal));
                dtRemisiones.Columns.Add("descRemate", typeof(System.Decimal));
                dtRemisiones.Columns.Add("conceptPromocion", typeof(System.String));
                dtRemisiones.Columns.Add("descPromocion", typeof(System.Decimal));
                dtRemisiones.Columns.Add("tipoDescPromocion", typeof(System.String));
                dtRemisiones.Columns.Add("auditado", typeof(System.String));
                dtRemisiones.Columns.Add("audita", typeof(System.String));
                dtRemisiones.Columns.Add("fechaAuditado", typeof(System.DateTime));
                dtRemisiones.Columns.Add("comentarioAuditado", typeof(System.String));
                dtRemisiones.Columns.Add("autorizado", typeof(System.String));
                dtRemisiones.Columns.Add("autoriza", typeof(System.String));
                dtRemisiones.Columns.Add("fechaAutoriza", typeof(System.DateTime));
                dtRemisiones.Columns.Add("comentarioAutorizado", typeof(System.String));




                //var Lista = db.remisiones.SqlQuery("Select * from Remisiones where auditado in(" + _queryAudita + ") " +
                //                                                   " and autorizado in(" + _queryAutoriza + ") and tipo_prenda in(" + _queryTipo + ") " +
                //                                                   " and fecha between '" + fechaInicial.ToString("yyyy-MM-dd") + "' and '" + fechafinal.ToString("yyyy-MM-dd") + "' " +
                //                                                   " order by consec").ToList();

                var Lista = db.remisiones.SqlQuery("Select * from Remisiones where auditado in(" + _queryAudita + ") " +
                                                                " and autorizado in(" + _queryAutoriza + ") and tipo_prenda in(" + _queryTipo + ") ").ToList();

                var listaTest = Lista.Where(p => p.Fecha >= fechaInicial && p.Fecha <= fechafinal && p.conceptopromocion.Contains("(MNL)")).OrderBy(p=>p.consec).ToList();


                if (listaTest != null)
                {
                    foreach (var item in listaTest)
                    {
                        listaRemisiones.Add(item);
                    }

                }



                if (listaTest != null)
                {
                    foreach (var item in listaTest)
                    {
                        dtRemisiones.Rows.Add(item.NumRemision, item.Fecha, item.Cliente, item.Inventario, item.Precio, item.Descuento,
                         item.Importe, item.Cantidad, item.Descripcion, item.conceptopromocion, item.noserieart, item.codebar, item.vendio,
                         item.suc, item.status, item.idcliente, item.comentarios, item.caja, item.tipo_desc, item.tipo_prenda, item.consec,
                         item.noRemate, item.precioRemate, item.descRemate, item.conceptPromocion, item.descPromocion, item.tipoDescPromocion, item.auditado,
                         item.audita, item.fechaAuditado, item.comentarioAuditado, item.autorizado, item.autoriza, item.fechaAutoriza, item.comentarioAutorizado);
                    }

                }

                return true;

            }
            catch (Exception ex)
            {
                string _error = ex.Message.ToString();
                return false;
            }


        }



        public bool updateAutorizaRem(int consec, string autoriza, string autorizo, DateTime fecha, string comentario)
        {
            using (var context = new SEMP2013_Context())
            {
                using (System.Data.Entity.DbContextTransaction dbTran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var remision = context.remisiones.
                            Where(p => p.consec == consec).FirstOrDefault();

                        if (remision == null)
                        {
                            return false;
                        }

                        remision.audita = autoriza;
                        remision.auditado = autorizo.Substring(0,3);
                        remision.fechaAuditado = fecha;
                        remision.comentarioAuditado = comentario;

                        context.remisiones.Attach(remision);
                        context.Entry(remision).State = System.Data.Entity.EntityState.Modified;
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
