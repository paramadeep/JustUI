using System.Windows.Automation;

namespace JustUI.Elements
{
    public class Image : BaseElement<Image>
    {
        public Image()
        {
            ControlType = ControlType.Image;
        }

        public void SingleClick()
        {
            Mouse.SingleClick(Element.Current.BoundingRectangle);
            WaitForLoader();
        }
    }
}
