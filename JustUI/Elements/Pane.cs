using System.Windows.Automation;

namespace JustUI.Elements
{
    public class Pane : BaseElement<Pane>
    {
        public Pane()
        {
            ControlType = ControlType.Pane;
        }

    }
}
