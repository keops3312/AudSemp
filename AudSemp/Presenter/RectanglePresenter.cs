using AudSemp.Models;
using AudSemp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudSemp.Presenter
{
    public class RectanglePresenter
    {
        IRectangle RectangleView;
        public RectanglePresenter(IRectangle view)
        {
            RectangleView = view;
        }

        public void CalculateArea()
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Length = double.Parse(RectangleView.LengthText);
            rectangle.Breadth = double.Parse(RectangleView.BreadthText);

            RectangleView.AreaText = rectangle.CalculateArea().ToString();


        }
    }
}
