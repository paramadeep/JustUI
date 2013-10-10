using System.Windows.Automation;

namespace JustUI.Elements
{
    public class List : ContainerElement<List>
    {
        public List()
        {
            ControlType = ControlType.List;
        }
    }
}
