using System;
using System.Runtime.InteropServices;
using System.Text;

namespace AsBest.WinTrimmer
{
  internal static class PlatformHelper
  {
    private const string ModuleUser32 = "user32.dll";
    private const string ModuleAdvapi32 = "advapi32.dll";
    private const string ModuleKernel32 = "kernel32.dll";

    [DllImport(ModuleUser32, ExactSpelling = true, SetLastError = true)]
    public static extern bool MoveWindow(IntPtr window, int x, int y, int width, int height, bool repaint);

    [DllImport(ModuleUser32, ExactSpelling = true, SetLastError = true)]
    public static extern bool ShowWindow(IntPtr window, WindowShowStyle style);

    [DllImport(ModuleUser32, ExactSpelling = true, SetLastError = true)]
    public static extern bool EnumWindows(EnumWindowsProc callback, IntPtr param);

    [DllImport(ModuleUser32, ExactSpelling = true, SetLastError = true)]
    public static extern bool EnumChildWindows(IntPtr parent, EnumWindowsProc callback, IntPtr param);

    [DllImport(ModuleUser32, ExactSpelling = true, SetLastError = true)]
    public static extern bool GetWindowRect(IntPtr window, out Rectangle rectangle);

    [DllImport(ModuleUser32, ExactSpelling = true, SetLastError = true)]
    public static extern bool SetWindowLong(IntPtr window, int index, int value);

    [DllImport(ModuleUser32, ExactSpelling = true, SetLastError = true)]
    public static extern int GetWindowLong(IntPtr window, int index);

    [DllImport(ModuleUser32, CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern int GetClassName(IntPtr window, StringBuilder classNameBuffer, int maxCount);

    [DllImport(ModuleUser32, ExactSpelling = true)]
    public static extern bool IsWindowVisible(IntPtr window);

    [DllImport(ModuleUser32, ExactSpelling = true)]
    public static extern IntPtr GetParent(IntPtr window);

    [DllImport(ModuleUser32, ExactSpelling = true)]
    public static extern int GetDlgCtrlID(IntPtr window);

    [DllImport(ModuleUser32, CharSet = CharSet.Unicode)]
    public static extern IntPtr SendMessage(IntPtr window, int message, IntPtr wParam, IntPtr lParam);

    [DllImport(ModuleUser32, ExactSpelling = true)]
    public static extern bool ScreenToClient(IntPtr window, ref Point point);

    [DllImport(ModuleAdvapi32, CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern bool LogonUser(
        string lpszUsername,
        string lpszDomain,
        string lpszPassword,
        int dwLogonType,
        int dwLogonProvider,
        out IntPtr phToken
        );

    [DllImport(ModuleKernel32, ExactSpelling = true, SetLastError = true)]
    public static extern bool CloseHandle(IntPtr hObject);

    [DllImport(ModuleUser32, ExactSpelling = true, SetLastError = true)]
    public static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

    [DllImport(ModuleKernel32, ExactSpelling = true, SetLastError = true)]
    public static extern IntPtr OpenProcess(int desiredAccess, bool inheritHandle, int processId);

    [DllImport(ModuleKernel32, CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern bool QueryFullProcessImageName(IntPtr processHandle, int flags, StringBuilder executableName, ref int size);
  }
}
