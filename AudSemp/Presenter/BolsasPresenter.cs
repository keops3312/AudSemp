

namespace AudSemp.Presenter
{
    using AudSemp.Classes;
    using AudSemp.Models;
    using AudSemp.Views;
    #region Libraries (Librerias)
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    #endregion
    public class BolsasPresenter
    {

        IBolsas BolsasView;
        public BolsasPresenter(IBolsas view)
        {
            BolsasView = view;
        }
        
        BolsasModel bolsasModel = new BolsasModel();


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
