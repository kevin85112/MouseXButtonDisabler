using System;
using System.Runtime.InteropServices;

namespace MouseXButtonDisabler
{
    public static class WindowsKeyboard
    {
        const int WH_MOUSE_LL = 14;
        const int WM_XBUTTONDOWN = 0x20B;
        const int WM_XBUTTONUP = 0x20C;
        static int m_MouseHookHandle = 0;
        delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);
        static HookProc m_MouseHookProc;

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr GetModuleHandle(string lpModuleName);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        static extern bool UnhookWindowsHookEx(int idHook);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        static extern int CallNextHookEx(int idHook, int nCode, IntPtr wParam, IntPtr lParam);

        static private int MouseHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                if ((int)wParam == WM_XBUTTONDOWN || (int)wParam == WM_XBUTTONUP)
                {
                    return -1;
                }
            }
            return CallNextHookEx(m_MouseHookHandle, nCode, wParam, lParam);
        }
        static public bool HookMouse()
        {
            if (m_MouseHookHandle == 0)
            {
                using (System.Diagnostics.Process curProcess = System.Diagnostics.Process.GetCurrentProcess())
                {
                    using (System.Diagnostics.ProcessModule curModule = curProcess.MainModule)
                    {
                        m_MouseHookProc = new HookProc(MouseHookProc);
                        m_MouseHookHandle = SetWindowsHookEx(WH_MOUSE_LL, m_MouseHookProc, GetModuleHandle(curModule.ModuleName), 0);
                    }
                }
                if (m_MouseHookHandle == 0)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            return true;
        }
        static public bool UnhookMouse()
        {
            if (m_MouseHookHandle != 0)
            {
                if (UnhookWindowsHookEx(m_MouseHookHandle))
                {
                    m_MouseHookHandle = 0;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
