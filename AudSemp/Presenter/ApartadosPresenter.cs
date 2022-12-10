
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
    public class ApartadosPresenter
    {

        IApartados ApartadosView;
        ApartadosModel apartadosModel; 
        public ApartadosPresenter(IApartados view, DataContext db)
        {
            ApartadosView = view;
            apartadosModel = new ApartadosModel(db);
        }

     

       
        public DateTime timeInicio()
        {

            return ApartadosView.dateTimeInicio = apartadosModel.dateInicio();
        }

        public DateTime timeFin()
        {
            return ApartadosView.dateTimeFin = apartadosModel.dateFin();
        }

        public List<string> TiposPrenda()
        {
            return ApartadosView.tipos = apartadosModel.TipoPrenda();
        }


        public List<string> TiposEstatus()
        {
            return ApartadosView.status = apartadosModel.Estatus();
        }

        public List<TiposOrden> tiposOrden()
        {
            return ApartadosView.tiposOrden = apartadosModel.TiposOrden();
        }

        public List<ModoOrdenes> modosOrden()
        {
            return ApartadosView.modosOrden = apartadosModel.Ordenes();
        }

    }
}
