using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;

namespace AsBest.WinTrimmer
{
  public static class WindowHelper
  {
    private const int MaximumCharacterCount = 1024;
    private const int CharacterSize = 2;
    private const int TerminatorCharacterCount = 1;
    private const int StringBufferSize = ((MaximumCharacterCount + TerminatorCharacterCount) * CharacterSize);

    private const string HandleNotValidMessage = "Specified window handle is not valid.";

    private static Exception PrepareException(string message)
    {
      Win32Exception innerException = null;

      int errorCode = Marshal.GetLastWin32Error();
      if (errorCode != 0)
        innerException = new Win32Exception(errorCode);

      return new InvalidOperationException(message, innerException);
    }

    public static void SetWindowStyle(IntPtr window, WindowShowStyle style)
    {
      PlatformHelper.ShowWindow(window, style);
    }

    public static void ShowWindow(IntPtr window)
    {
      SetWindowStyle(window, WindowShowStyle.Show);
    }

    public static void HideWindow(IntPtr window)
    {
      SetWindowStyle(window, WindowShowStyle.Hide);
    }

    public static void MoveWindow(IntPtr window, int x, int y, int width, int height)
    {
      bool succeeded = PlatformHelper.MoveWindow(window, x, y, width, height, true);
      if (!succeeded)
        throw PrepareException(HandleNotValidMessage);
    }

    public static string GetClassName(IntPtr window)
    {
      StringBuilder builder = new StringBuilder(MaximumCharacterCount);
      int length = PlatformHelper.GetClassName(window, builder, builder.Capacity);
      if (length == builder.Capacity)
        throw new InvalidOperationException("Text buffer too small to retrieve a window class name.");
      return builder.ToString();
    }

    public static string GetCaptionText(IntPtr window)
    {
      IntPtr buffer = IntPtr.Zero;

      try
      {
        buffer = Marshal.AllocHGlobal(StringBufferSize);
        int length = (int)PlatformHelper.SendMessage(window, (int)PlatformConstants.WM_GETTEXT, (IntPtr)MaximumCharacterCount, buffer);
        string text = Marshal.PtrToStringUni(buffer, length);
        return text.Trim('\r', '\n', '\t', ' ', '\0');
      }
      finally
      {
        if (buffer != IntPtr.Zero)
          Marshal.FreeHGlobal(buffer);
      }
    }

    public static int GetControlID(IntPtr window)
    {
      return PlatformHelper.GetDlgCtrlID(window);
    }

    public static IntPtr[] EnumVisibleWindows()
    {
      List<IntPtr> windows = new List<IntPtr>();

      EnumWindowsProc callback =
        (window, param) =>
        {
          bool visible = PlatformHelper.IsWindowVisible(window);
          if (visible)
            windows.Add(window);
          return true;
        };

      bool succeeded = PlatformHelper.EnumWindows(callback, IntPtr.Zero);
      if (!succeeded)
        throw PrepareException(HandleNotValidMessage);

      return windows.ToArray();
    }

    public static IntPtr[] EnumChildWindows(IntPtr parent)
    {
      List<IntPtr> windows = new List<IntPtr>();

      EnumWindowsProc callback =
        (window, param) =>
        {
          if (PlatformHelper.GetParent(window) == parent)
            windows.Add(window);
          return true;
        };

      PlatformHelper.EnumChildWindows(parent, callback, IntPtr.Zero);

      return windows.ToArray();
    }

    public static Point ScreenToClient(IntPtr handle, Point point)
    {
      bool succeeded = PlatformHelper.ScreenToClient(handle, ref point);
      if (!succeeded)
        throw PrepareException(HandleNotValidMessage);
      return point;
    }

    public static Rectangle GetWindowRectangle(IntPtr handle)
    {
      Rectangle rectangle;

      bool succeeded = PlatformHelper.GetWindowRect(handle, out rectangle);
      if (!succeeded)
        throw PrepareException(HandleNotValidMessage);

      Point topLeft = new Point(rectangle.Left, rectangle.Top);
      Point bottomRight = new Point(rectangle.Right, rectangle.Bottom);

      IntPtr parentHandle = PlatformHelper.GetParent(handle);

      topLeft = ScreenToClient(parentHandle, topLeft);
      bottomRight = ScreenToClient(parentHandle, bottomRight);

      rectangle = new Rectangle(topLeft.X, topLeft.Y, bottomRight.X, bottomRight.Y);

      return rectangle;
    }

    public static void SetCaptionText(IntPtr handle, string value)
    {
      IntPtr buffer = IntPtr.Zero;

      try
      {
        buffer = Marshal.StringToHGlobalUni(value);
        int result = (int)PlatformHelper.SendMessage(handle, (int)PlatformConstants.WM_SETTEXT, IntPtr.Zero, buffer);
        if (result == 0)
          throw PrepareException(HandleNotValidMessage);
      }
      finally
      {
        if (buffer != IntPtr.Zero)
          Marshal.FreeHGlobal(buffer);
      }
    }

    public static IntPtr LogonUser(string userName, string password)
    {
      IntPtr token;
      bool suceeded = PlatformHelper.LogonUser(userName, string.Empty, password, (int) PlatformConstants.LOGON32_LOGON_NETWORK,
        (int) PlatformConstants.LOGON32_PROVIDER_DEFAULT, out token);
      if (!suceeded)
        throw PrepareException(HandleNotValidMessage);
      return token;
    }

    public static string GetWindowProcessFileName(IntPtr windowHandle)
    {
      IntPtr processHandle = IntPtr.Zero;

      try
      {
        int processId;
        PlatformHelper.GetWindowThreadProcessId(windowHandle, out processId);
        processHandle = PlatformHelper.OpenProcess(
          (int) PlatformConstants.PROCESS_QUERY_LIMITED_INFORMATION,
          false,
          processId);
        StringBuilder builder = new StringBuilder(WindowHelper.MaximumCharacterCount);
        int fileNameSize = builder.Capacity;
        bool succeeded = PlatformHelper.QueryFullProcessImageName(processHandle, 0, builder, ref fileNameSize);
        if (!succeeded)
          throw PrepareException(HandleNotValidMessage);
        return builder.ToString();
      }
      finally
      {
        if (processHandle != IntPtr.Zero)
          PlatformHelper.CloseHandle(processHandle);
      }
    }
  }
}
