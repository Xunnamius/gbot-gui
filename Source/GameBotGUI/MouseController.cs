using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using GameBotGUI.Record.Types.Click;

namespace GameBotGUI
{
    static sealed class MouseController
    {
        private const int MouseEventDelayMS = 2;
        
        [Flags]
        internal enum MouseEventFlags : uint
        {
            LeftDown = 0x00000002,
            LeftUp = 0x00000004,
            MiddleDown = 0x00000020,
            MiddleUp = 0x00000040,
            Move = 0x00000001,
            Absolute = 0x00008000,
            RightDown = 0x00000008,
            RightUp = 0x00000010
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public int mouseData;
            public MouseEventFlags dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        internal struct INPUT
        {
            public uint type;
            public MOUSEINPUT mi;
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint SendInput(uint nInputs, ref INPUT pInputs, int cbSize);

        public static void SmoothClickMouseTo(Point dest, Int32 totalDuration, ClickRecordType clickType)
        {
            Point start = Cursor.Position;
            PointF iterPoint = start;
            Int32 steps = totalDuration / MouseEventDelayMS;

            // Find the slope of the line segment defined by start and dest
            PointF slope = new PointF(dest.X - start.X, dest.Y - start.Y);

            // Divide by the number of steps
            slope.X = slope.X / steps;
            slope.Y = slope.Y / steps;

            // Move the mouse to each iterative point.
            for(int i = 0; i < steps; i++)
            {
                iterPoint = new PointF(iterPoint.X + slope.X, iterPoint.Y + slope.Y);
                Cursor.Position = Point.Round(iterPoint);
                System.Threading.Thread.Sleep(MouseEventDelayMS + (new Random()).Next(4));
            }

            // Move the mouse to the final destination.
            Cursor.Position = dest;
            DoClickMouse(clickType);
        }

        public static void DoClickMouse(ClickRecordType clickType)
        {
            INPUT mouseInput = new INPUT()
            {
                type = 0, // Mouse input
                mi = new MOUSEINPUT()
            };

            switch(clickType)
            {
                case ClickRecordType.LeftClick:
                    mouseInput.mi.dwFlags = MouseEventFlags.LeftDown;
                    SendInput(1, ref mouseInput, Marshal.SizeOf(new INPUT()));
                    System.Threading.Thread.Sleep(150);
                    mouseInput.mi.dwFlags = MouseEventFlags.LeftUp;
                    SendInput(1, ref mouseInput, Marshal.SizeOf(new INPUT()));
                    break;

                case ClickRecordType.RightClick:
                    mouseInput.mi.dwFlags = MouseEventFlags.RightDown;
                    SendInput(1, ref mouseInput, Marshal.SizeOf(new INPUT()));
                    System.Threading.Thread.Sleep(150);
                    mouseInput.mi.dwFlags = MouseEventFlags.RightUp;
                    SendInput(1, ref mouseInput, Marshal.SizeOf(new INPUT()));
                    break;

                case ClickRecordType.MiddleClick:
                    mouseInput.mi.dwFlags = MouseEventFlags.MiddleDown;
                    SendInput(1, ref mouseInput, Marshal.SizeOf(new INPUT()));
                    System.Threading.Thread.Sleep(150);
                    mouseInput.mi.dwFlags = MouseEventFlags.MiddleUp;
                    SendInput(1, ref mouseInput, Marshal.SizeOf(new INPUT()));
                    break;
            }
        }
    }
}
