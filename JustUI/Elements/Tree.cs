using System.Linq;
using System.Windows.Automation;

namespace JustUI.Elements
{
    public class Tree : ContainerElement<Tree>
    {
        public Tree()
        {
            ControlType = ControlType.Tree;
        }

        public string GetSelectedNodeName()
        {
            return
                ((SelectionPattern) Element.GetCurrentPattern(SelectionPattern.Pattern)).Current.GetSelection()
                                                                                        .Single()
                                                                                        .Current.Name;
        }
    }
}
