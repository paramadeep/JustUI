using System.Windows.Automation;

namespace JustUI.Elements
{
    public class HeaderItem : BaseElement<HeaderItem>
    {
        public HeaderItem()
        {
            ControlType = ControlType.HeaderItem;
        }

        public void ClickWithoutFocus()
        {
            var click = (InvokePattern) Element.GetCurrentPattern(InvokePattern.Pattern);
            click.Invoke();
        }
    }
}
