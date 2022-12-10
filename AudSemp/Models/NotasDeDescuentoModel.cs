
namespace AudSemp.Models
{
    using AudSemp.Classes;
    //using AudSemp.Context;
    using OperSemp.Commons.Data;
    using OperSemp.Commons.Entities;
    using OperSemp.Commons.Helper;

    #region Libraries

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks; 
    #endregion


    public class NotasDeDescuentoModel
    {

        #region Constructor

        private DataContext db;
        public string _oString;
        private IConectionHelper conectionHelper;

        public NotasDeDescuentoModel(string cadena)
        {
            conectionHelper = new ConectionHelper();
            _oString = cadena;
            db = new DataContext(conectionHelper.SQLConectionAsync(cadena));
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
                           new TiposOrden() { tipo ="TipoOperacion"},
                           new TiposOrden() { tipo ="Caja"},
                           new TiposOrden() { tipo ="Descuento"},
                           new TiposOrden() { tipo = "Status Auditado" },
                           new TiposOrden() { tipo = "Status Autorizado" }

             };

            return tiposOrden;


        }

        public List<string> TipoPrenda()
        {

            List<string> tiposList = new List<string>();


            var tipos = db.NotasDescuento.Select(p => p.TipOperacion).Distinct();

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


            var fecha = db.NotasDescuento
                 .OrderBy(p => p.FechaDescuento).FirstOrDefault();
            if (fecha != null)
            {

                date = DateTime.Parse(fecha.FechaDescuento.ToString());

            }

            return date;
        }

        public DateTime final()
        {

            string Final = "1999-01-01";
            DateTime date = DateTime.Parse(Final);


            var fecha = db.NotasDescuento
                 .OrderByDescending(p => p.FechaDescuento).FirstOrDefault();
            if (fecha != null)
            {

                date = DateTime.Parse(fecha.FechaDescuento.ToString());

            }

            return date;
        }


        public List<string> AuditoriaTipo()
        {

            List<string> tiposListAu = new List<string>();


            var tipos = db.NotasDescuento.Select(p => p.Auditado).Distinct();

            foreach (var item in tipos)
            {
                tiposListAu.Add(item);

            }

            return tiposListAu;

        }



        public List<string> AutorizaTipo()
        {

            List<string> tiposListAu = new List<string>();


            var tipos = db.NotasDescuento.Select(p => p.GOAutorizado).Distinct();

            foreach (var item in tipos)
            {
                tiposListAu.Add(item);

            }

            return tiposListAu;

        }

        public List<NotasDescuento> listaNotasDescuento;

        public DataTable dtNotasDescuento;


        public string empleado()
        {
            var myEmpleado = db.Empleados.Where(p => p.Puesto == "DIRECTOR").FirstOrDefault();
            return myEmpleado.NombreCompleto;
        }
        #endregion

        #region Principal Methods
        public bool listaRevisionND(DateTime fechaInicial, DateTime fechafinal,
         string[] tipos, string[] statusAudita, string[] statusAutorizado, int tipoFecha)
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


                listaNotasDescuento = new List<NotasDescuento>();
                dtNotasDescuento = new DataTable("NotasDescuento");


                dtNotasDescuento.Columns.Add("Id", typeof(System.Int32));
                dtNotasDescuento.Columns.Add("ND", typeof(System.String));
                dtNotasDescuento.Columns.Add("IdCliente", typeof(System.Int32));
                dtNotasDescuento.Columns.Add("Cliente", typeof(System.String));
                dtNotasDescuento.Columns.Add("TipoOperacion", typeof(System.String));
                dtNotasDescuento.Columns.Add("NP", typeof(System.String));
                dtNotasDescuento.Columns.Add("Remision", typeof(System.String));
                dtNotasDescuento.Columns.Add("Contrato", typeof(System.Int32));
                dtNotasDescuento.Columns.Add("Prestamo", typeof(System.Decimal));
                dtNotasDescuento.Columns.Add("SubTotal", typeof(System.Decimal));
                dtNotasDescuento.Columns.Add("Iva", typeof(System.Decimal));
                dtNotasDescuento.Columns.Add("Total", typeof(System.Decimal));
                dtNotasDescuento.Columns.Add("SubTotalR", typeof(System.Decimal));
                dtNotasDescuento.Columns.Add("IvaR", typeof(System.Decimal));
                dtNotasDescuento.Columns.Add("TotalR", typeof(System.Decimal));
                dtNotasDescuento.Columns.Add("Estatus", typeof(System.String));
                dtNotasDescuento.Columns.Add("CantidadDescuento", typeof(System.Decimal));
                dtNotasDescuento.Columns.Add("ImporteDescuento", typeof(System.Decimal));                  
                dtNotasDescuento.Columns.Add("Caja", typeof(System.String));
                dtNotasDescuento.Columns.Add("ArgumentoUsuario", typeof(System.String));
                dtNotasDescuento.Columns.Add("Usuario", typeof(System.String));
                dtNotasDescuento.Columns.Add("JefeAutorizo", typeof(System.String));
                dtNotasDescuento.Columns.Add("FechaDescuento", typeof(System.DateTime));
                dtNotasDescuento.Columns.Add("GOAutorizo", typeof(System.String));
                dtNotasDescuento.Columns.Add("GOAutorizado", typeof(System.String));
                dtNotasDescuento.Columns.Add("GOArgumento", typeof(System.String));
                dtNotasDescuento.Columns.Add("GOAutorizadoFecha", typeof(System.DateTime));
                dtNotasDescuento.Columns.Add("Auditor", typeof(System.String));
                dtNotasDescuento.Columns.Add("Auditado", typeof(System.String));
                dtNotasDescuento.Columns.Add("AuditorArgumento", typeof(System.String));
                dtNotasDescuento.Columns.Add("AuditadoFecha", typeof(System.DateTime));
                dtNotasDescuento.Columns.Add("Sucursal", typeof(System.String));
               

                

                if (tipoFecha == 1)//fecha Operacion
                {

                    var Lista = db.NotasDescuento.SqlQuery("Select * from NotasDescuento where Auditado in(" + _queryAudita + ") " +
                                                                  " and GOAutorizado in(" + _queryAutoriza + ") and TipOperacion in(" + _queryTipo + ")").ToList();

                    var listaTest = Lista.Where(p => p.FechaDescuento >= fechaInicial && p.FechaDescuento <= fechafinal).OrderBy(p => p.Id).ToList();

                  




                    if (listaTest != null)
                    {
                        foreach (var item in listaTest)
                        {


                            NotasDescuento oNotasDescuento = new NotasDescuento
                            {

                                Id = item.Id,
                                ND = item.ND,
                                IdCliente = item.IdCliente,
                                Cliente = item.Cliente,
                                TipOperacion = item.TipOperacion,
                                NP = item.NP,
                                Remision = item.Remision,
                                Contrato = item.Contrato,
                                Prestamo = item.Prestamo,
                                SubTotal = item.SubTotal,
                                Iva = item.Iva,
                                Total = item.Total,
                                SubTotalR = item.SubTotalR,
                                IvaR = item.IvaR,
                                TotalR = item.TotalR,
                                Estatus = item.Estatus,
                                CantidadDescuento = item.CantidadDescuento,
                                ImporteDescuento = item.ImporteDescuento,
                                Caja = item.Caja,
                                ArgumentoUsuario = item.ArgumentoUsuario,
                                Usuario = item.Usuario,
                                JefeAutorizo = item.JefeAutorizo,
                                FechaDescuento = item.FechaDescuento,
                                GOAutorizo = item.GOAutorizo,
                                GOAutorizado = item.GOAutorizado,
                                GOArgumento = item.GOArgumento,
                                GOAutorizadoFecha = item.GOAutorizadoFecha,
                                Auditor = item.Auditor,
                                Auditado = item.Auditado,
                                AuditorArgumento = item.AuditorArgumento,
                                AuditadoFecha = item.AuditadoFecha,
                                Sucursal = item.Sucursal,

                            };

                            listaNotasDescuento.Add(oNotasDescuento);

                        }

                    }




                    if (listaTest != null)
                    {



                        foreach (var item in listaTest)
                        {
                            dtNotasDescuento.Rows.Add(item.Id, item.ND, item.IdCliente, item.Cliente, item.TipOperacion, item.NP,
                             item.Remision, item.Contrato, item.Prestamo, item.SubTotal, item.Iva, item.Total, item.SubTotalR,
                             item.IvaR, item.TotalR, item.Estatus, item.CantidadDescuento, item.ImporteDescuento, item.Caja, item.ArgumentoUsuario,
                             item.Usuario, item.JefeAutorizo, item.FechaDescuento, item.GOAutorizo, item.GOAutorizado, item.GOArgumento, item.GOAutorizadoFecha,
                             item.Auditor, item.Auditado, item.AuditorArgumento, item.AuditadoFecha, item.Sucursal);
                        }

                    }






                }

                if (tipoFecha == 2)//fecha auditoria
                {

                    var Lista = db.NotasDescuento.SqlQuery("Select * from NotasDescuento where Auditado in(" + _queryAudita + ") " +
                                                                  " and GOAutorizado in(" + _queryAutoriza + ") and TipOperacion in(" + _queryTipo + ")").ToList();

                    var listaTest = Lista.Where(p => p.AuditadoFecha >= fechaInicial && p.AuditadoFecha <= fechafinal).OrderBy(p => p.Id).ToList();






                    if (listaTest != null)
                    {
                        foreach (var item in listaTest)
                        {


                            NotasDescuento oNotasDescuento = new NotasDescuento
                            {

                                Id = item.Id,
                                ND = item.ND,
                                IdCliente = item.IdCliente,
                                Cliente = item.Cliente,
                                TipOperacion = item.TipOperacion,
                                NP = item.NP,
                                Remision = item.Remision,
                                Contrato = item.Contrato,
                                Prestamo = item.Prestamo,
                                SubTotal = item.SubTotal,
                                Iva = item.Iva,
                                Total = item.Total,
                                SubTotalR = item.SubTotalR,
                                IvaR = item.IvaR,
                                TotalR = item.TotalR,
                                Estatus = item.Estatus,
                                CantidadDescuento = item.CantidadDescuento,
                                ImporteDescuento = item.ImporteDescuento,
                                Caja = item.Caja,
                                ArgumentoUsuario = item.ArgumentoUsuario,
                                Usuario = item.Usuario,
                                JefeAutorizo = item.JefeAutorizo,
                                FechaDescuento = item.FechaDescuento,
                                GOAutorizo = item.GOAutorizo,
                                GOAutorizado = item.GOAutorizado,
                                GOArgumento = item.GOArgumento,
                                GOAutorizadoFecha = item.GOAutorizadoFecha,
                                Auditor = item.Auditor,
                                Auditado = item.Auditado,
                                AuditorArgumento = item.AuditorArgumento,
                                AuditadoFecha = item.AuditadoFecha,
                                Sucursal = item.Sucursal,

                            };

                            listaNotasDescuento.Add(oNotasDescuento);

                        }

                    }




                    if (listaTest != null)
                    {



                        foreach (var item in listaTest)
                        {
                            dtNotasDescuento.Rows.Add(item.Id, item.ND, item.IdCliente, item.Cliente, item.TipOperacion, item.NP,
                             item.Remision, item.Contrato, item.Prestamo, item.SubTotal, item.Iva, item.Total, item.SubTotalR,
                             item.IvaR, item.TotalR, item.Estatus, item.CantidadDescuento, item.ImporteDescuento, item.Caja, item.ArgumentoUsuario,
                             item.Usuario, item.JefeAutorizo, item.FechaDescuento, item.GOAutorizo, item.GOAutorizado, item.GOArgumento, item.GOAutorizadoFecha,
                             item.Auditor, item.Auditado, item.AuditorArgumento, item.AuditadoFecha, item.Sucursal);
                        }

                    }

                }

                if (tipoFecha == 3)//fecha autorizacion
                {


                    var Lista = db.NotasDescuento.SqlQuery("Select * from NotasDescuento where Auditado in(" + _queryAudita + ") " +
                                                                    " and GOAutorizado in(" + _queryAutoriza + ") and TipOperacion in(" + _queryTipo + ")").ToList();

                    var listaTest = Lista.Where(p => p.GOAutorizadoFecha >= fechaInicial && p.GOAutorizadoFecha <= fechafinal).OrderBy(p => p.Id).ToList();






                    if (listaTest != null)
                    {
                        foreach (var item in listaTest)
                        {


                            NotasDescuento oNotasDescuento = new NotasDescuento
                            {

                                Id = item.Id,
                                ND = item.ND,
                                IdCliente = item.IdCliente,
                                Cliente = item.Cliente,
                                TipOperacion = item.TipOperacion,
                                NP = item.NP,
                                Remision = item.Remision,
                                Contrato = item.Contrato,
                                Prestamo = item.Prestamo,
                                SubTotal = item.SubTotal,
                                Iva = item.Iva,
                                Total = item.Total,
                                SubTotalR = item.SubTotalR,
                                IvaR = item.IvaR,
                                TotalR = item.TotalR,
                                Estatus = item.Estatus,
                                CantidadDescuento = item.CantidadDescuento,
                                ImporteDescuento = item.ImporteDescuento,
                                Caja = item.Caja,
                                ArgumentoUsuario = item.ArgumentoUsuario,
                                Usuario = item.Usuario,
                                JefeAutorizo = item.JefeAutorizo,
                                FechaDescuento = item.FechaDescuento,
                                GOAutorizo = item.GOAutorizo,
                                GOAutorizado = item.GOAutorizado,
                                GOArgumento = item.GOArgumento,
                                GOAutorizadoFecha = item.GOAutorizadoFecha,
                                Auditor = item.Auditor,
                                Auditado = item.Auditado,
                                AuditorArgumento = item.AuditorArgumento,
                                AuditadoFecha = item.AuditadoFecha,
                                Sucursal = item.Sucursal,

                            };

                            listaNotasDescuento.Add(oNotasDescuento);

                        }

                    }




                    if (listaTest != null)
                    {



                        foreach (var item in listaTest)
                        {
                            dtNotasDescuento.Rows.Add(item.Id, item.ND, item.IdCliente, item.Cliente, item.TipOperacion, item.NP,
                             item.Remision, item.Contrato, item.Prestamo, item.SubTotal, item.Iva, item.Total, item.SubTotalR,
                             item.IvaR, item.TotalR, item.Estatus, item.CantidadDescuento, item.ImporteDescuento, item.Caja, item.ArgumentoUsuario,
                             item.Usuario, item.JefeAutorizo, item.FechaDescuento, item.GOAutorizo, item.GOAutorizado, item.GOArgumento, item.GOAutorizadoFecha,
                             item.Auditor, item.Auditado, item.AuditorArgumento, item.AuditadoFecha, item.Sucursal);
                        }

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



        public bool updateAutorizaND(int consec, string autoriza, string autorizo, DateTime fecha, string comentario)
        {



            using (var context = new DataContext(conectionHelper.SQLConectionAsync(_oString)))
            {
                using (System.Data.Entity.DbContextTransaction dbTran = context.Database.BeginTransaction())
                {
                    try
                    {

                        var oND = context.NotasDescuento.
                        Where(p => p.Id == consec).First();

                        if (oND == null)
                        {
                            return false;
                        }

                        //NotasDescuento notasDescuento = new NotasDescuento();
                        //notasDescuento = oND;

                        oND.Auditor = autoriza;
                        oND.Auditado = autorizo.Substring(0, 3);
                        oND.AuditadoFecha = fecha;
                        oND.AuditorArgumento = comentario;


                        //context.Entry(oND).State = System.Data.Entity.EntityState.Detached;
                        //context.Entry(notasDescuento).State = System.Data.Entity.EntityState.Modified;
                        context.NotasDescuento.Attach(oND);
                        context.Entry(oND).State = System.Data.Entity.EntityState.Modified;
                       
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
