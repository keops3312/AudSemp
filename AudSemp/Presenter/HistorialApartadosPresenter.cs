

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
    public class HistorialApartadosPresenter
    {

        IHistorialApartado ApartadosHistorialView;
        HistorialApartadosModel hisotrialapartadosModel;
        public HistorialApartadosPresenter(IHistorialApartado view, DataContext db)
        {
            ApartadosHistorialView = view;
            hisotrialapartadosModel = new HistorialApartadosModel(db);
        }

        





        public DateTime timeInicio()
        {

            return ApartadosHistorialView.dateTimeInicio = hisotrialapartadosModel.dateInicio();
        }

        public DateTime timeFin()
        {
            return ApartadosHistorialView.dateTimeFin = hisotrialapartadosModel.dateFin();
        }

        public List<string> TiposEstatus()
        {
            return ApartadosHistorialView.status = hisotrialapartadosModel.Estatus();
        }

        public List<TiposOrden> tiposOrden()
        {
            return ApartadosHistorialView.tiposOrden = hisotrialapartadosModel.TiposOrden();
        }

        public List<ModoOrdenes> modosOrden()
        {
            return ApartadosHistorialView.modosOrden = hisotrialapartadosModel.Ordenes();
        }
    }
}
