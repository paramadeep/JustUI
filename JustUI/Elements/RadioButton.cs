using System.Windows.Automation;

namespace JustUI.Elements
{
    public class RadioButton : BaseElement<RadioButton>
    {
        public RadioButton()
        {
            ControlType = ControlType.RadioButton;
        }

        public void Select()
        {
            var radioButton = ((SelectionItemPattern) Element.GetCurrentPattern(SelectionItemPattern.Pattern));
            radioButton.Select();
        }
    }
}
