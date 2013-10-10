using System.Windows.Automation;

namespace JustUI.Elements
{
    public class TabItem : BaseElement<TabItem>
    {
        public TabItem()
        {
            ControlType = ControlType.TabItem;
        }

        public void Select()
        {
            var tab = (SelectionItemPattern) Element.GetCurrentPattern(SelectionItemPattern.Pattern);
            tab.Select();
        }
    }
}
