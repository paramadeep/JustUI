using System.Windows.Automation;

namespace JustUI.Elements
{
    public class TreeItem : ContainerElement<TreeItem>
    {
        public TreeItem()
        {
            ControlType = ControlType.TreeItem;
        }

        public void Select()
        {
            ((SelectionItemPattern) Element.GetCurrentPattern(SelectionItemPattern.Pattern)).Select();
        }

        public void Expand()
        {
            ((ExpandCollapsePattern) Element.GetCurrentPattern(ExpandCollapsePattern.Pattern)).Expand();
        }

        public void DoubleClick()
        {
            ((InvokePattern) Element.GetCurrentPattern(InvokePattern.Pattern)).Invoke();
        }


        public bool IsExpaned()
        {
            var expandCollapsePattern = (ExpandCollapsePattern) Element.GetCurrentPattern(ExpandCollapsePattern.Pattern);
            return expandCollapsePattern.Current.ExpandCollapseState == ExpandCollapseState.Expanded;
        }

        
    }
}
