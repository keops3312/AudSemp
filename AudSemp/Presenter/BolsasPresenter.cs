

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
    public class BolsasPresenter
    {

        IBolsas BolsasView;
        BolsasModel bolsasModel;
        public BolsasPresenter(IBolsas view, DataContext db)
        {
            BolsasView = view;
            bolsasModel = new BolsasModel(db);
        }
        
        


        public DateTime timeInicio()
        {

            return BolsasView.dateTimeInicio = bolsasModel.dateInicio(BolsasView.OpcionDR);
        }

        public DateTime timeFin()
        {
            return BolsasView.dateTimeFin = bolsasModel.dateFin(BolsasView.OpcionDR);
        }


        public List<string> TiposPrenda()
        {
            return BolsasView.tipos = bolsasModel.TipoPrenda(BolsasView.OpcionDR);
        }
        public List<TiposOrden> tiposOrden()
        {
            return BolsasView.tiposOrden = bolsasModel.TiposOrden(BolsasView.OpcionDR);
        }

        public List<ModoOrdenes> modosOrden()
        {
            return BolsasView.modosOrden = bolsasModel.Ordenes();
        }
    }
}
