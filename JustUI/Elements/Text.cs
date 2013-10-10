using System.Windows.Automation;

namespace JustUI.Elements
{
    public class Text : BaseElement<Text>
    {
        public Text()
        {
            ControlType = ControlType.Text;
        }

        public void DragDropTo<T>(BaseElement<T> dropNode,int wait = 3000) where T : BaseElement<T>
        {
            Mouse.DragDrop(Element.Current.BoundingRectangle, dropNode.Element.Current.BoundingRectangle);
            WaitToDiasppear(wait);
        }

        public void RightClick()
        {
            Mouse.RightClick(Element.Current.BoundingRectangle);
        }

        public void DoubleClick()
        {
            Mouse.DoubleClick(Element.Current.BoundingRectangle);
        }

        public void SingleClick()
        {
            Mouse.SingleClick(Element.Current.BoundingRectangle);
        }
    }
}
