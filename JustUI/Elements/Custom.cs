using System.Windows.Automation;

namespace JustUI.Elements
{
    public class Custom : BaseElement<Custom>
    {
        public Custom()
        {
            ControlType = ControlType.Custom;
        }

        public void DoubleClick()
        {
            ((SelectionItemPattern) Element.GetCurrentPattern(SelectionItemPattern.Pattern)).Select();
            ((InvokePattern) Element.GetCurrentPattern(InvokePattern.Pattern)).Invoke();
        }
    }
}
