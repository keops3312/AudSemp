

namespace AudSemp.Presenter
{
    #region Libraries (librerias) 
    using System;
    using System.Collections.Generic;
    using AudSemp.Classes;
    using AudSemp.Models;
    using AudSemp.Views;
    using OperSemp.Commons.Data;
    #endregion
    public class NotaPagoPresenter
    {

        InotasPago NotasPagoView;
        NotasPagoModel notasPagoModel;

        public NotaPagoPresenter(InotasPago view,DataContext db)
        {
            NotasPagoView = view;
            notasPagoModel = new NotasPagoModel(db);
        }

       

        public DateTime timeInicio()
        {

            return NotasPagoView.dateTimeInicio = notasPagoModel.dateInicio();
        }

        public DateTime timeFin()
        {
            return NotasPagoView.dateTimeFin = notasPagoModel.dateFin();
        }

        public List<string> TiposRd()
        {
            return NotasPagoView.tiposrd = notasPagoModel.TipoRD();
        }


        public List<string> TiposEstatus()
        {
            return NotasPagoView.status = notasPagoModel.Estatus();
        }

        public List<TiposOrden> tiposOrden()
        {
            return NotasPagoView.tiposOrden = notasPagoModel.TiposOrden();
        }

        public List<ModoOrdenes> modosOrden()
        {
            return NotasPagoView.modosOrden = notasPagoModel.Ordenes();
        }



    }
}
