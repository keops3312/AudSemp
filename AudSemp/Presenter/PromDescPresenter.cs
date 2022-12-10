

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
    public class PromDescPresenter
    {
        IPromDesc PromDescView;
        PromDescModel promDescModel; 
        public PromDescPresenter(IPromDesc view, DataContext db)
        {
            PromDescView = view;
           promDescModel = new PromDescModel(db);
        }

        

        public List<TiposOrden> tiposOrden()
        {
            return PromDescView.tiposOrden = promDescModel.TiposOrden();
        }

        public List<ModoOrdenes> modosOrden()
        {
            return PromDescView.modosOrden = promDescModel.Ordenes();
        }

        public DateTime timeInicio()
        {

            return PromDescView.dateTimeInicio = promDescModel.dateInicio();
        }

        public DateTime timeFin()
        {
            return PromDescView.dateTimeFin = promDescModel.dateFin();
        }


    }
}
