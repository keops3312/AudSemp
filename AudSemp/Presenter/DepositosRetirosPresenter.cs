

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
    public class DepositosRetirosPresenter
    {

     

        IDepositosRetiros DepositosRetirosView;
        depositosRetirosModel DepositosRetirosModel;
        public DepositosRetirosPresenter(IDepositosRetiros view, DataContext db)
        {
            DepositosRetirosView = view;
             DepositosRetirosModel = new depositosRetirosModel(db);
        }

      
        

        public DateTime timeInicio()
        {

            return DepositosRetirosView.dateTimeInicio = DepositosRetirosModel.dateInicio(DepositosRetirosView.OpcionDR);
        }

        public DateTime timeFin()
        {
            return DepositosRetirosView.dateTimeFin = DepositosRetirosModel.dateFin(DepositosRetirosView.OpcionDR);
        }

      

        public List<TiposOrden> tiposOrden()
        {
            return DepositosRetirosView.tiposOrden = DepositosRetirosModel.TiposOrden(DepositosRetirosView.OpcionDR);
        }

        public List<ModoOrdenes> modosOrden()
        {
            return DepositosRetirosView.modosOrden = DepositosRetirosModel.Ordenes();
        }



    }
}
