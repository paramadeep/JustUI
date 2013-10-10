using System.Windows.Automation;

namespace JustUI.Elements
{
    public class CheckBox : BaseElement<CheckBox>
    {
        public CheckBox()
        {
            ControlType = ControlType.CheckBox;
        }

        public void Toggle()
        {
            var checkBox = (TogglePattern) Element.GetCurrentPattern(TogglePattern.Pattern);
            checkBox.Toggle();
        }

        public bool IsChecked()
        {
            var checkBox = (TogglePattern) Element.GetCurrentPattern(TogglePattern.Pattern);
            return checkBox.Current.ToggleState == ToggleState.On;
        }
    }
}
