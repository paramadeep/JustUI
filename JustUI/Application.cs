using System;
using System.Diagnostics;

using JustUI.Elements;

namespace JustUI
{
    public class Application
    {
        private readonly string _executableLocation;
        private Process _process;
        public Window Window;

        public Application(string executableLocation)
        {
            _executableLocation = executableLocation;
        }

        public void Launch()
        {
            _process = Process.Start(_executableLocation);
            WaitForAppProcessToStart();
            WaitForAppWindowToLoad();
            Window = new Window(_process);
        }

        private void WaitForAppProcessToStart()
        {
            new Wait(15000).UntillNotNull(() => _process);
        }

        private void WaitForAppWindowToLoad()
        {
            new Wait(50000).UntillTrue(() => _process.MainWindowHandle != new IntPtr(0));
        }

        public void CloseIfExist()
        {
            if (_process == null)
                return;
            Close();
        }

        private void Close()
        {
            _process.Kill();
        }
    }
}
