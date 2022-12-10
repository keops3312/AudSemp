

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
    public class InventarioPresenter
    {
        IInventario InventarioView;
        InventarioModel inventarioModel;
        public InventarioPresenter(IInventario view,DataContext db)
        {
            InventarioView = view;
            inventarioModel = new InventarioModel(db);
        }

       

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
