using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudSemp.Models
{
    using AudSemp.Classes;
    using AudSemp.Context;
    #region Libraries 
    using System;
    using System.CodeDom;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
   
    #endregion
    public class AutorizaNotaPagoConDepositoModel
    {

        #region Constructor
        private SEMP2013_Context db;
        public AutorizaNotaPagoConDepositoModel()
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
                           new TiposOrden() { tipo ="Nota de Pago"},
                           new TiposOrden() { tipo ="Contrato"},
                           new TiposOrden() { tipo = "Status Auditado" },
                           new TiposOrden() { tipo = "Status Autorizado" }

             };

            return tiposOrden;


        }

        public List<string> TipoPrenda()
        {

            List<string> tiposList = new List<string>();

            tiposList.Clear();

            tiposList.Add("Refrendos");
            tiposList.Add("Desempeños");

            return tiposList;

        }

        public DateTime inicial()
        {

            string Final = "1999-01-01";
            DateTime date = DateTime.Parse(Final);


            var fecha = db.facturas.Where(u => u.conDeposito == true)
                 .OrderBy(p => p.FechaFact).FirstOrDefault();
            if (fecha != null)
            {

                date = DateTime.Parse(fecha.FechaFact.ToString());

            }

            return date;
        }

        public DateTime final()
        {

            string Final = "1999-01-01";
            DateTime date = DateTime.Parse(Final);


            var fecha = db.facturas.Where(u => u.conDeposito == true)
                 .OrderByDescending(p => p.FechaFact).FirstOrDefault();
            if (fecha != null)
            {

                date = DateTime.Parse(fecha.FechaFact.ToString());

            }

            return date;
        }


        public List<string> AuditoriaTipo()
        {

            List<string> tiposListAu = new List<string>();


            var tipos = db.facturas.Select(p => p.auditado).Distinct();

            foreach (var item in tipos)
            {
                tiposListAu.Add(item);

            }

            return tiposListAu;

        }



        public List<string> AutorizaTipo()
        {

            List<string> tiposListAu = new List<string>();


            var tipos = db.facturas.Select(p => p.autorizado).Distinct();

            foreach (var item in tipos)
            {
                tiposListAu.Add(item);

            }

            return tiposListAu;

        }

        public List<facturas> listaFacturas;

        public DataTable dtFacturas;


        public string empleado()
        {
            var myEmpleado = db.Empleados.Where(p => p.Puesto == "DIRECTOR").FirstOrDefault();
            return myEmpleado.Nombre_Completo;
        }
        #endregion



        #region Principal Methods
        public bool listaRevisionNotasConDeposito(DateTime fechaInicial, DateTime fechafinal,
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



                listaFacturas = new List<facturas>();
                dtFacturas = new DataTable("Facturas");


                dtFacturas.Columns.Add("Factura", typeof(System.String));
                dtFacturas.Columns.Add("FechaFact", typeof(System.DateTime));
                dtFacturas.Columns.Add("HoraFact", typeof(System.String));
                dtFacturas.Columns.Add("Contrato", typeof(System.Int32));
                dtFacturas.Columns.Add("Bolsa", typeof(System.Int32));
                dtFacturas.Columns.Add("Folio", typeof(System.Int32));
                dtFacturas.Columns.Add("ImporteFact", typeof(System.Decimal));
                dtFacturas.Columns.Add("IVAFact", typeof(System.Decimal));
                dtFacturas.Columns.Add("TotalFact", typeof(System.Decimal));
                dtFacturas.Columns.Add("IdCliente", typeof(System.String));
                dtFacturas.Columns.Add("Abono", typeof(System.Decimal));
                dtFacturas.Columns.Add("RD", typeof(System.String));
                dtFacturas.Columns.Add("caja", typeof(System.String));
                dtFacturas.Columns.Add("STATUS", typeof(System.String));
                dtFacturas.Columns.Add("realizo", typeof(System.String));
                dtFacturas.Columns.Add("GastosOperacion", typeof(System.String));
                dtFacturas.Columns.Add("descuentoGastosOp", typeof(System.String));
                dtFacturas.Columns.Add("totalGastosOp", typeof(System.String));
                dtFacturas.Columns.Add("descuentoPreferente", typeof(System.String));
                dtFacturas.Columns.Add("auditado", typeof(System.String));
                dtFacturas.Columns.Add("audita", typeof(System.String));
                dtFacturas.Columns.Add("fechaAuditado", typeof(System.DateTime));
                dtFacturas.Columns.Add("comentarioAuditado", typeof(System.String));
                dtFacturas.Columns.Add("autorizado", typeof(System.String));
                dtFacturas.Columns.Add("autoriza", typeof(System.String));
                dtFacturas.Columns.Add("fechaAutoriza", typeof(System.DateTime));
                dtFacturas.Columns.Add("comentarioAutorizado", typeof(System.String));



                if (tipoFecha == 1)//fecha factura
                {



                    var oListaFactura = db.facturas.Where(p => p.conDeposito == true).ToList();



                    var listaTest = from a in oListaFactura
                                    where tipos.Contains((string)a.R_D) &&
                                    (statusAudita.Contains((string)a.auditado)) &&
                                    (statusAutorizado.Contains((string)a.autorizado)) &&
                                    a.FechaFact >= fechaInicial && a.FechaFact <= fechafinal
                                    select a;



                    //int A = listaTest.ToList().Count();


                    if (listaTest != null)
                    {
                        foreach (var item in listaTest)
                        {

                            facturas ofactura = new facturas
                            {

                                Factura = item.Factura,
                                FechaFact = item.FechaFact,
                                HoraFact = item.HoraFact,
                                Contrato = item.Contrato,
                                Bolsa = item.Bolsa,
                                Folio = item.Folio,
                                ImporteFact = item.ImporteFact,
                                IVAFact = item.IVAFact,
                                TotalFact = item.TotalFact,
                                IdCliente = item.IdCliente,
                                Abono = item.Abono,
                                R_D = item.R_D,
                                caja = item.caja,
                                STATUS = item.STATUS,
                                realizo = item.realizo,
                                Gastos_Operacion = item.Gastos_Operacion,
                                descuento_gastos_op = item.descuento_gastos_op,
                                total_gastos_op = item.total_gastos_op,
                                descuento_preferente = item.descuento_preferente,
                                auditado = item.auditado,
                                audita = item.audita,
                                fechaAuditado = item.fechaAuditado,
                                comentarioAuditado = item.comentarioAuditado,
                                autorizado = item.autorizado,
                                autoriza = item.autoriza,
                                fechaAutoriza = item.fechaAutoriza,
                                comentarioAutorizado = item.comentarioAutorizado,
                                NO = item.NO,


                            };

                            listaFacturas.Add(ofactura);

                        }

                    }




                    if (listaTest != null)
                    {
                        foreach (var item in listaTest)
                        {
                            dtFacturas.Rows.Add(item.Factura, item.FechaFact, item.HoraFact, item.Contrato, item.Bolsa, item.Folio,
                             item.ImporteFact, item.IVAFact, item.TotalFact, item.IdCliente, item.Abono, item.R_D, item.caja,
                             item.STATUS, item.realizo, item.Gastos_Operacion, item.descuento_gastos_op, item.total_gastos_op, item.descuento_preferente, item.auditado,
                             item.audita, item.fechaAuditado, item.comentarioAuditado, item.autorizado, item.autoriza, item.fechaAutoriza, item.comentarioAutorizado);
                        }

                    }




                }

                if (tipoFecha == 2)//fecha auditoria
                {

                    var oListaFactura = db.facturas.Where(p => p.conDeposito == true).ToList();



                    var listaTest = from a in oListaFactura
                                    where tipos.Contains((string)a.R_D) &&
                                    (statusAudita.Contains((string)a.auditado)) &&
                                    (statusAutorizado.Contains((string)a.autorizado)) &&
                                    a.fechaAuditado >= fechaInicial && a.fechaAuditado <= fechafinal
                                    select a;



                    //int A = listaTest.ToList().Count();


                    if (listaTest != null)
                    {
                        foreach (var item in listaTest)
                        {

                            facturas ofactura = new facturas
                            {

                                Factura = item.Factura,
                                FechaFact = item.FechaFact,
                                HoraFact = item.HoraFact,
                                Contrato = item.Contrato,
                                Bolsa = item.Bolsa,
                                Folio = item.Folio,
                                ImporteFact = item.ImporteFact,
                                IVAFact = item.IVAFact,
                                TotalFact = item.TotalFact,
                                IdCliente = item.IdCliente,
                                Abono = item.Abono,
                                R_D = item.R_D,
                                caja = item.caja,
                                STATUS = item.STATUS,
                                realizo = item.realizo,
                                Gastos_Operacion = item.Gastos_Operacion,
                                descuento_gastos_op = item.descuento_gastos_op,
                                total_gastos_op = item.total_gastos_op,
                                descuento_preferente = item.descuento_preferente,
                                auditado = item.auditado,
                                audita = item.audita,
                                fechaAuditado = item.fechaAuditado,
                                comentarioAuditado = item.comentarioAuditado,
                                autorizado = item.autorizado,
                                autoriza = item.autoriza,
                                fechaAutoriza = item.fechaAutoriza,
                                comentarioAutorizado = item.comentarioAutorizado,
                                NO = item.NO,


                            };

                            listaFacturas.Add(ofactura);

                        }

                    }




                    if (listaTest != null)
                    {
                        foreach (var item in listaTest)
                        {
                            dtFacturas.Rows.Add(item.Factura, item.FechaFact, item.HoraFact, item.Contrato, item.Bolsa, item.Folio,
                             item.ImporteFact, item.IVAFact, item.TotalFact, item.IdCliente, item.Abono, item.R_D, item.caja,
                             item.STATUS, item.realizo, item.Gastos_Operacion, item.descuento_gastos_op, item.total_gastos_op, item.descuento_preferente, item.auditado,
                             item.audita, item.fechaAuditado, item.comentarioAuditado, item.autorizado, item.autoriza, item.fechaAutoriza, item.comentarioAutorizado);
                        }

                    }

                }

                if (tipoFecha == 3)//fecha autorizacion
                {


                    //var Lista3 = db.facturas.SqlQuery("Select * from facturas where auditado in(" + _queryAudita + ") " +
                    //                                                 " and autorizado in(" + _queryAutoriza + ") and [R-D] in(" + _queryTipo + ") and conDeposito=1").ToList();

                    //var listaTest3 = Lista3.Where(p => p.fechaAutoriza >= fechaInicial && p.fechaAutoriza <= fechafinal).OrderBy(p => p.NO).ToList();
                    var oListaFactura = db.facturas.Where(p => p.conDeposito == true).ToList();



                    var listaTest = from a in oListaFactura
                                    where tipos.Contains((string)a.R_D) &&
                                    (statusAudita.Contains((string)a.auditado)) &&
                                    (statusAutorizado.Contains((string)a.autorizado)) &&
                                    a.fechaAutoriza >= fechaInicial && a.fechaAutoriza <= fechafinal
                                    select a;



                    //int A = listaTest.ToList().Count();


                    if (listaTest != null)
                    {
                        foreach (var item in listaTest)
                        {

                            facturas ofactura = new facturas
                            {

                                Factura = item.Factura,
                                FechaFact = item.FechaFact,
                                HoraFact = item.HoraFact,
                                Contrato = item.Contrato,
                                Bolsa = item.Bolsa,
                                Folio = item.Folio,
                                ImporteFact = item.ImporteFact,
                                IVAFact = item.IVAFact,
                                TotalFact = item.TotalFact,
                                IdCliente = item.IdCliente,
                                Abono = item.Abono,
                                R_D = item.R_D,
                                caja = item.caja,
                                STATUS = item.STATUS,
                                realizo = item.realizo,
                                Gastos_Operacion = item.Gastos_Operacion,
                                descuento_gastos_op = item.descuento_gastos_op,
                                total_gastos_op = item.total_gastos_op,
                                descuento_preferente = item.descuento_preferente,
                                auditado = item.auditado,
                                audita = item.audita,
                                fechaAuditado = item.fechaAuditado,
                                comentarioAuditado = item.comentarioAuditado,
                                autorizado = item.autorizado,
                                autoriza = item.autoriza,
                                fechaAutoriza = item.fechaAutoriza,
                                comentarioAutorizado = item.comentarioAutorizado,
                                NO = item.NO,


                            };

                            listaFacturas.Add(ofactura);

                        }

                    }




                    if (listaTest != null)
                    {
                        foreach (var item in listaTest)
                        {
                            dtFacturas.Rows.Add(item.Factura, item.FechaFact, item.HoraFact, item.Contrato, item.Bolsa, item.Folio,
                             item.ImporteFact, item.IVAFact, item.TotalFact, item.IdCliente, item.Abono, item.R_D, item.caja,
                             item.STATUS, item.realizo, item.Gastos_Operacion, item.descuento_gastos_op, item.total_gastos_op, item.descuento_preferente, item.auditado,
                             item.audita, item.fechaAuditado, item.comentarioAuditado, item.autorizado, item.autoriza, item.fechaAutoriza, item.comentarioAutorizado);
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



        public bool updateAutorizafact(int consec, string autoriza, string autorizo, DateTime fecha, string comentario)
        {
            using (var context = new SEMP2013_Context())
            {
                using (DbContextTransaction dbTran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var factura = context.facturas.
                            Where(p => p.NO == consec).FirstOrDefault();

                        if (factura == null)
                        {
                            return false;
                        }

                        factura.audita = autoriza;
                        factura.auditado = autorizo.Substring(0, 3);
                        factura.fechaAuditado = fecha;
                        factura.comentarioAuditado = comentario;


                        context.Entry(factura).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();

                        //context.facturas.Attach(factura);
                        //context.Entry(factura).State = System.Data.Entity.EntityState.Modified;




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
