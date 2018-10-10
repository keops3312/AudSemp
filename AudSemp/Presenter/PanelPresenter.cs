using AudSemp.Models;
using AudSemp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudSemp.Presenter
{
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
