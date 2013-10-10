using System.Windows.Automation;

namespace JustUI.Elements
{
    public class Hyperlink : BaseElement<Hyperlink>
    {
        public Hyperlink()
        {
            ControlType = ControlType.Hyperlink;
        }

        public void ClickWithoutFocus()
        {
            Element.SetFocus();
            var click = (InvokePattern) Element.GetCurrentPattern(InvokePattern.Pattern);
            click.Invoke();
        }
    }
}
