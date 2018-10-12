
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
    public class ApartadosPresenter
    {

        IApartados ApartadosView;
        public ApartadosPresenter(IApartados view)
        {
            ApartadosView = view;
        }

        ApartadosModel apartadosModel = new ApartadosModel();

       
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
