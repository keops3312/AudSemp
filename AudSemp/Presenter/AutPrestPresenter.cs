
namespace AudSemp.Presenter
{
    using AudSemp.Classes;
    using AudSemp.Models;
    using AudSemp.Views;
    using System.Collections.Generic;

    public class AutPrestPresenter
    {

        IAutPrest AutPrestView;
        public AutPrestPresenter(IAutPrest view)
        {
            AutPrestView = view;
        }

        AutPrestModel autPrestModel = new AutPrestModel();

        public List<TiposOrden> tiposOrden()
        {
            return AutPrestView.tiposOrden = autPrestModel.TiposOrden();
        }

        public List<ModoOrdenes> modosOrden()
        {
            return AutPrestView.modosOrden = autPrestModel.Ordenes();
        }
    }
}
