using System.Windows.Automation;

namespace JustUI.Elements
{
    public class DataItem : BaseElement<DataItem>
    {
        public DataItem()
        {
            ControlType = ControlType.DataItem;
        }

        public void Select()
        {
            ((SelectionItemPattern) Element.GetCurrentPattern(SelectionItemPattern.Pattern)).Select();
        }

        public void DoubleClick()
        {
            ((InvokePattern) Element.GetCurrentPattern(InvokePattern.Pattern)).Invoke();
        }

        public void ScrollToView()
        {
            ((ScrollItemPattern) Element.GetCurrentPattern(ScrollItemPattern.Pattern)).ScrollIntoView();
        }

        public void Expand()
        {
            ((ExpandCollapsePattern) Element.GetCurrentPattern(ExpandCollapsePattern.Pattern)).Expand();
        }
    }
}
