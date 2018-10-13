

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
    public class HistorialApartadosPresenter
    {

        IHistorialApartado ApartadosHistorialView;
        public HistorialApartadosPresenter(IHistorialApartado view)
        {
            ApartadosHistorialView = view;
        }

        HistorialApartadosModel hisotrialapartadosModel = new HistorialApartadosModel();


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
