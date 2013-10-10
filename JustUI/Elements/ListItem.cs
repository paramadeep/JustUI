using System.Windows.Automation;

namespace JustUI.Elements
{
    public class ListItem : BaseElement<ListItem>
    {
        public ListItem()
        {
            ControlType = ControlType.ListItem;
        }

        public void Select()
        {
            ((SelectionItemPattern) Element.GetCurrentPattern(SelectionItemPattern.Pattern)).Select();
        }

      }
}
