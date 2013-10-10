using System.Windows.Automation;

namespace JustUI.Elements
{
    public class Tab : BaseElement<Tab>
    {
        public Tab()
        {
            ControlType = ControlType.Tab;
        }

        public TabItem GetSelected()
        {
            var getItem = (SelectionPattern) Element.GetCurrentPattern(SelectionPattern.Pattern);
            return new TabItem {Element = getItem.Current.GetSelection()[0]};
        }
    }
}
