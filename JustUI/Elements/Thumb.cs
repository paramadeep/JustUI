using System.Windows.Automation;

namespace JustUI.Elements
{
    public class Thumb : BaseElement<Thumb>
    {
        public Thumb()
        {
            ControlType = ControlType.Thumb;
        }

        public void ClickWithoutFocus()
        {
            var click = (InvokePattern) Element.GetCurrentPattern(InvokePattern.Pattern);
            click.Invoke();
        }
    }
}
