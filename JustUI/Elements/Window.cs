using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        public Window(Process process)
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
