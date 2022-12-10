
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

    public class AutPrestPresenter
    {

        IAutPrest AutPrestView;
        AutPrestModel autPrestModel;
        public AutPrestPresenter(IAutPrest view,DataContext db)
        {
            AutPrestView = view;
            autPrestModel = new AutPrestModel(db);
        }

        

        public List<TiposOrden> tiposOrden()
        {
            return AutPrestView.tiposOrden = autPrestModel.TiposOrden();
        }

        public List<ModoOrdenes> modosOrden()
        {
            return AutPrestView.modosOrden = autPrestModel.Ordenes();
        }

        public DateTime timeInicio()
        {

            return AutPrestView.dateTimeInicio = autPrestModel.dateInicio();
        }

        public DateTime timeFin()
        {
            return AutPrestView.dateTimeFin = autPrestModel.dateFin();
        }
    }
}
