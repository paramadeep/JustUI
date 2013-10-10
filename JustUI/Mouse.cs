using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Forms;

using Point = System.Drawing.Point;
using ClickablePoint = System.Windows.Point;

namespace JustUI
{
    public class Mouse
    {
        [Flags]
        public enum MouseEventFlags : uint
        {
            LeftDown = 0x00000002,
            LeftUp = 0x00000004,
            RightDown = 0x00000008,
            RightUp = 0x00000010,
            Absolute = 0x8000
        }

        public static void RightClick(Rect targetRectangle)
        {
            var clickPoint = GetCenterPoint(targetRectangle);
            Cursor.Position = clickPoint;
            mouse_event(MouseEventFlags.RightDown, (uint) clickPoint.X, (uint) clickPoint.Y, 0, 0);
            mouse_event(MouseEventFlags.RightUp, (uint) clickPoint.X, (uint) clickPoint.Y, 0, 0);
        }

        private static Point GetTopPoint(Rect rectangle)
        {
            var x = (int) (rectangle.Left + 50);
            var y = (int) (rectangle.Top + 5);
            return new Point(x, y);
        }

        private static Point GetCenterPoint(Rect rectangle)
        {
            var x = (int) ((rectangle.Left + rectangle.Right)/2);
            var y = (int) (rectangle.Top + rectangle.Bottom)/2;
            return new Point(x, y);
        }

        public static void DragDropToNode(Rect dragRectangle, Rect dropRectangle)
        {
            var startPoint = GetCenterPoint(dragRectangle);
            var endPoint = GetTopPoint(dropRectangle);
            SetCursorPos(startPoint.X, startPoint.Y);
            mouse_event(MouseEventFlags.LeftDown, (uint)startPoint.X, (uint)startPoint.Y, 0, 0);
            const double dragStepCount = 10;
            const float dragStepFraction = (float) (1.0/dragStepCount);
            for (var i = 1; i <= dragStepCount; i++)
            {
                double newX = startPoint.X + (endPoint.X - startPoint.X)*(dragStepFraction*i);
                double newY = startPoint.Y + (endPoint.Y - startPoint.Y)*(dragStepFraction*i);
                Thread.Sleep(100);
                SetCursorPos((int) newX, (int) newY);
            }
            mouse_event(MouseEventFlags.LeftUp, (uint) endPoint.X, (uint) endPoint.Y, 0, 0);
            
        }

        public static void DragDrop(Rect dragRectangle, Rect dropRectangle)
        {
            var startPoint = GetCenterPoint(dragRectangle);
            var endPoint = GetCenterPoint(dropRectangle);
            SetCursorPos(startPoint.X, startPoint.Y);
            mouse_event(MouseEventFlags.LeftDown, (uint)startPoint.X, (uint)startPoint.Y, 0, 0);
            const double dragStepCount = 20;
            const float dragStepFraction = (float)(1.0 / dragStepCount);
            for (var i = 1; i <= dragStepCount; i++)
            {
                double newX = startPoint.X + (endPoint.X - startPoint.X) * (dragStepFraction * i);
                double newY = startPoint.Y + (endPoint.Y - startPoint.Y) * (dragStepFraction * i);
                Thread.Sleep(100);
                SetCursorPos((int)newX, (int)newY);
            }
            mouse_event(MouseEventFlags.LeftUp, (uint)endPoint.X, (uint)endPoint.Y, 0, 0);
        }

        public static void DragDropByPoint(Rect dragRectangle, ClickablePoint dropRectangle)
        {
            var startPoint = GetCenterPoint(dragRectangle);
            //var endPoint = GetCenterPoint(dropRectangle);
            SetCursorPos(startPoint.X, startPoint.Y);
            mouse_event(MouseEventFlags.LeftDown, (uint)startPoint.X, (uint)startPoint.Y, 0, 0);
            const double dragStepCount = 10;
            const float dragStepFraction = (float)(1.0 / dragStepCount);
            for (var i = 1; i <= dragStepCount; i++)
            {
                double newX = startPoint.X + (dropRectangle.X - startPoint.X) * (dragStepFraction * i);
                double newY = startPoint.Y + (dropRectangle.Y - startPoint.Y) * (dragStepFraction * i);
                Thread.Sleep(100);
                SetCursorPos((int)newX, (int)newY);
            }
            mouse_event(MouseEventFlags.LeftUp, (uint)dropRectangle.X, (uint)dragRectangle.Y, 0, 0);

        }

        public static void DoubleClick(Rect dragRectangle)
        {
            var startPoint = GetCenterPoint(dragRectangle);
            SetCursorPos(startPoint.X, startPoint.Y);
            mouse_event(MouseEventFlags.LeftDown, (uint)startPoint.X, (uint)startPoint.Y, 0, 0);
            mouse_event(MouseEventFlags.LeftUp, (uint) startPoint.X, (uint) startPoint.Y, 0, 0);
            mouse_event(MouseEventFlags.LeftDown, (uint)startPoint.X, (uint)startPoint.Y, 0, 0);
            mouse_event(MouseEventFlags.LeftUp, (uint)startPoint.X, (uint)startPoint.Y, 0, 0);
        }

        public static void SingleClick(Rect dragRectangle)
        {
            var startPoint = GetCenterPoint(dragRectangle);
            SetCursorPos(startPoint.X, startPoint.Y);
            mouse_event(MouseEventFlags.LeftDown, (uint)startPoint.X, (uint)startPoint.Y, 0, 0);
            mouse_event(MouseEventFlags.LeftUp, (uint)startPoint.X, (uint)startPoint.Y, 0, 0);
        }

        [DllImport("user32.dll")]
        public static extern void mouse_event(MouseEventFlags dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);


        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int x, int y);
    }
}
