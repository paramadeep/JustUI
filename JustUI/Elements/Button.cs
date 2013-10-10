using System.Windows.Automation;

namespace JustUI.Elements
{
    public class Button : BaseElement<Button>
    {
        public Button()
        {
            ControlType = ControlType.Button;
        }

        public void Click()
        {
            Element.SetFocus();
            ClickWithoutFocus();
        }

        public void ClickWithoutFocus()
        {
            var click = (InvokePattern) Element.GetCurrentPattern(InvokePattern.Pattern);
            click.Invoke();
            WaitForLoader();
        }

        
    }
}
