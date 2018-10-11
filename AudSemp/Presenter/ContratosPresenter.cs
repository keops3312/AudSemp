

namespace AudSemp.Presenter
{

    #region Libraries (librerias)
    using AudSemp.Classes;
    using AudSemp.Models;
    using AudSemp.Views;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    #endregion
    public class ContratosPresenter
    {

        IContratos ContratosView;
        public ContratosPresenter(IContratos view)
        {
            ContratosView = view;
        }

        ContratosModel contratosModel = new ContratosModel();

        public DateTime timeInicio()
        {

            return ContratosView.dateTimeInicio = contratosModel.dateInicio();
        }

        public DateTime timeFin()
        {
            return ContratosView.dateTimeFin = contratosModel.dateFin();
        }

        public List<string> TiposPrenda()
        {
            return ContratosView.tipos = contratosModel.TipoPrenda();
        }


        public List<string> TiposEstatus()
        {
            return ContratosView.status = contratosModel.Estatus();
        }

        public List<TiposOrden> tiposOrden()
        {
            return ContratosView.tiposOrden = contratosModel.TiposOrden();
        }

        public List<ModoOrdenes> modosOrden()
        {
            return ContratosView.modosOrden = contratosModel.Ordenes();
        }




    }
}
