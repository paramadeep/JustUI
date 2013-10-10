using JustUI.Elements;

namespace JustUI.CustomElements
{
    public class ContextMenu
    {
        private readonly Window _window;

        public ContextMenu(Window window)
        {
            _window = window;
        }

        public void Select(string menuItem)
        {
            var windowsBasePane = _window.GetParent<Pane>();
            var contextMenuWindow = windowsBasePane.Get<Window>(By.Name(""), false, 20000);
            var item = contextMenuWindow.Get<MenuItem>(By.Name(menuItem), false, 20000);
            item.Select();
        }
    }
}
