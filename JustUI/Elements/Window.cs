using System.Diagnostics;
using System.Windows.Automation;
using JustUI.CustomElements;

namespace JustUI.Elements
{
    public class Window : BaseElement<Window>
    {
        public Window()
        {
            ControlType = ControlType.Window;
        }

        protected Window(Process process)
        {
            ControlType = ControlType.Window;
            Element = AutomationElement.FromHandle(process.MainWindowHandle);
        }

        public ContextMenu GetContextMenu()
        {
            return new ContextMenu(this);
        }
    }
}