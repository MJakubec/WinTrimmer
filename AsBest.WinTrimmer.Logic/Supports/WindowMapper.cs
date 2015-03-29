using System;
using System.Collections.Generic;
using System.Linq;

namespace AsBest.WinTrimmer
{
  public sealed class WindowMapper
  {
    private const int InvalidIndexValue = -1;

    private readonly List<IntPtr> handles = new List<IntPtr>();
    private readonly List<Window> windows = new List<Window>();
    private readonly List<string> names = new List<string>();

    public Window FindWindow(IntPtr handle)
    {
      int index = handles.IndexOf(handle);
      if (index == InvalidIndexValue)
        return null;
      return windows[index];
    }

    public Window FindWindow(string name)
    {
      int index = names.IndexOf(name);
      if (index == InvalidIndexValue)
        return null;
      return windows[index];
    }

    public IntPtr FindHandle(Window window)
    {
      int index = windows.IndexOf(window);
      if (index == InvalidIndexValue)
        return IntPtr.Zero;
      return handles[index];
    }

    public IntPtr FindHandle(string name)
    {
      int index = names.IndexOf(name);
      if (index == InvalidIndexValue)
        return IntPtr.Zero;
      return handles[index];
    }

    public Window LookupWindow(IntPtr handle)
    {
      Window window = FindWindow(handle);
      if (window == null)
        throw new InvalidOperationException("There is no window for the specified handle.");
      return window;
    }

    public Window LookupWindow(string name)
    {
      Window window = FindWindow(name);
      if (window == null)
        throw new InvalidOperationException("There is no window for the specified name.");
      return window;
    }

    public IntPtr LookupHandle(Window window)
    {
      IntPtr handle = FindHandle(window);
      if (handle == IntPtr.Zero)
        throw new InvalidOperationException("There is no handle for the specified window object.");
      return handle;
    }

    public IntPtr LookupHandle(string name)
    {
      IntPtr handle = FindHandle(name);
      if (handle == IntPtr.Zero)
        throw new InvalidOperationException("There is no handle for the specified window name.");
      return handle;
    }

    public void Clear()
    {
      handles.Clear();
      windows.Clear();
      names.Clear();
    }

    public void Add(IntPtr handle, Window window)
    {
      handles.Add(handle);
      windows.Add(window);
      names.Add(window.Name);
    }

    public IntPtr LookupMarkerHandle()
    {
      Window window = windows.SingleOrDefault(w => w.Marker == true);
      IntPtr handle = FindHandle(window);
      if (handle != IntPtr.Zero)
        return handle;
      return LookupRootHandle();
    }

    public IntPtr LookupRootHandle()
    {
      if (handles.Count == 0)
        return IntPtr.Zero;
      int index = handles.Count - 1;
      return handles[index];
    }

    public bool IsWindowMapped(Window window)
    {
      return windows.Contains(window);
    }
  }
}
