

namespace AudSemp.Presenter
{
    #region Libraries (librerias) 
    using System;
    using System.Collections.Generic;
    using AudSemp.Classes;
    using AudSemp.Models;
    using AudSemp.Views;
    #endregion
    public class DepositosRetirosPresenter
    {

        IDepositosRetiros DepositosRetirosView;
        public DepositosRetirosPresenter(IDepositosRetiros view)
        {
            DepositosRetirosView = view;
        }

        depositosRetirosModel DepositosRetirosModel = new depositosRetirosModel();
        

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
