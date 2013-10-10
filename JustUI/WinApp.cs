using System;
using System.Diagnostics;

using JustUI.Elements;

namespace JustUI
{
    public class WinApp
    {
        private readonly string _executableLocation;
        private Process _process;

        public WinApp(string executableLocation)
        {
            _executableLocation = executableLocation;
        }

        public Window Launch()
        {
            _process = Process.Start(_executableLocation);
            WaitForAppProcessToStart();
            WaitForAppWindowToLoad();
            return new Window(_process);
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
