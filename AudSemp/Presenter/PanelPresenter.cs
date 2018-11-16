

namespace AudSemp.Presenter
{
    #region Libraries (librerias) 
    using AudSemp.Models;
    using AudSemp.Views;
    #endregion
    public class PanelPresenter
    {
        IPanel PanelView;
        public PanelPresenter(IPanel view)
        {
            PanelView=view;
        }
        LocalidadModel localidades = new LocalidadModel();
        public void LocalidadResult(string clave)
        {
           
            localidades.localidadResult(clave);
            PanelView.empresaText = localidades.empresa;
            PanelView.encargadoText = localidades.encargado;
            PanelView.marcaText = localidades.marca;
            PanelView.logotipoText = localidades.logotipo;
            PanelView.localidadText = localidades.localidad;
            PanelView.sucursalText = localidades.sucursal;



        }



    }
}
