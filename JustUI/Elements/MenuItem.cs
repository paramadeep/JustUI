using System.Windows.Automation;

namespace JustUI.Elements
{
    public class MenuItem : BaseElement<MenuItem>
    {
        public MenuItem()
        {
            ControlType = ControlType.MenuItem;
        }

        public void Expand()
        {
            ((ExpandCollapsePattern) Element.GetCurrentPattern(ExpandCollapsePattern.Pattern)).Expand();
        }

        public void Select()
        {
            ((InvokePattern) Element.GetCurrentPattern(InvokePattern.Pattern)).Invoke();
            WaitForLoader();
        }
    }
}
