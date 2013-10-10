using System.Windows.Automation;

namespace JustUI.Elements
{
    public class Edit : BaseElement<Edit>
    {
        public Edit()
        {
            ControlType = ControlType.Edit;
        }

        public void SetValue(string value)
        {
            ((ValuePattern) Element.GetCurrentPattern(ValuePattern.Pattern)).SetValue(value);
        }

        public bool IsReadOnly()
        {
            return IsEnabled();
        }

        public string GetText()
        {
            return ((ValuePattern) Element.GetCurrentPattern(ValuePattern.Pattern)).Current.Value;
        }
    }
}
