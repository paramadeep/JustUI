using System.Collections.Generic;
using System.Linq;
using System.Windows.Automation;

namespace JustUI.Elements
{
    public class ComboBox : ContainerElement<ComboBox>
    {
        public ComboBox()
        {
            ControlType = ControlType.ComboBox;
        }

        public void Select(string value)
        {
            ExpandColapse();
            Get<ListItem>(By.Name(value),false).Select();
            WaitForLoader();
        }

        private void ExpandColapse()
        {
            var expandCollapsePattern = (ExpandCollapsePattern) Element.GetCurrentPattern(ExpandCollapsePattern.Pattern);
            expandCollapsePattern.Expand();
            expandCollapsePattern.Collapse();
        }

        public string GetSelected()
        {
            return ((SelectionPattern) Element.GetCurrentPattern(SelectionPattern.Pattern)).Current.GetSelection().Single().Current.Name;
        }

        public List<ListItem> GetListItems()
        {
            ExpandColapse();
            return GetAll<ListItem>(15000,Relation.Children);
        }
    }
}
