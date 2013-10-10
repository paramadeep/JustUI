using System.Windows.Automation;

namespace JustUI.Elements
{
    public class Group : BaseElement<Group>
    {
        public Group()
        {
            ControlType = ControlType.Group;
        }

        public void Expand()
        {
            ((ExpandCollapsePattern) Element.GetCurrentPattern(ExpandCollapsePattern.Pattern)).Expand();
        }
    }
}
