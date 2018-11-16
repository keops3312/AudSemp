

namespace AudSemp.Presenter
{
    #region Libraries (librerias) 
    using AudSemp.Models;
    using AudSemp.Views;
    #endregion
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
