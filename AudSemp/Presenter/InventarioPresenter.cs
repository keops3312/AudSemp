

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
    public class InventarioPresenter
    {
        IInventario InventarioView;
        public InventarioPresenter(IInventario view)
        {
            InventarioView = view;
        }

        InventarioModel inventarioModel = new InventarioModel();

        public DateTime timeInicio()
        {

            return InventarioView.dateTimeInicio = inventarioModel.dateInicio();
        }

        public DateTime timeFin()
        {
            return InventarioView.dateTimeFin = inventarioModel.dateFin();
        }

        public List<string> TiposPrenda()
        {
            return InventarioView.tipos = inventarioModel.TipoPrenda();
        }


        public List<string> TiposEstatus()
        {
            return InventarioView.status = inventarioModel.Estatus();
        }

        public List<TiposOrden> tiposOrden()
        {
            return InventarioView.tiposOrden = inventarioModel.TiposOrden();
        }

        public List<ModoOrdenes> modosOrden()
        {
            return InventarioView.modosOrden = inventarioModel.Ordenes();
        }
    }
}
