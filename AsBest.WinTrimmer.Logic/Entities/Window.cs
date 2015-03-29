using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace AsBest.WinTrimmer
{
  public class Window
  {
    private string name;
    private bool? marker;
    private string classText;
    private string captionText;
    private int? controlId;
    private bool? visible;
    private readonly List<Window> children = new List<Window>();

    public string Name
    {
      get { return name; }
      set { name = value; }
    }

    public string ClassText
    {
      get { return classText; }
      set { classText = value; }
    }

    public string CaptionText
    {
      get { return captionText; }
      set { captionText = value; }
    }

    public int? ControlId
    {
      get { return controlId; }
      set { controlId = value; }
    }

    public List<Window> Children
    {
      get { return children; }
    }

    public bool? Marker
    {
      get { return marker; }
      set { marker = value; }
    }

    public bool? Visible
    {
      get { return visible; }
      set { visible = value; }
    }

    public XElement ToXml()
    {
      XElement windowElement = new XElement("window");
      windowElement.SetAttributeValue("name", name);
      windowElement.SetAttributeValue("marker", marker);
      windowElement.SetAttributeValue("class", classText);
      windowElement.SetAttributeValue("controlId", controlId);
      windowElement.SetAttributeValue("visible", visible);
      windowElement.SetAttributeValue("caption", captionText);
      IEnumerable<XElement> elements = children.Select(window => window.ToXml());
      windowElement.Add(elements);
      return windowElement;
    }

    public static Window FromXml(XElement windowElement)
    {
      return new Window(windowElement);
    }

    public static Window FromHandle(IntPtr handle)
    {
      return new Window(handle);
    }

    public Window(XElement windowElement)
    {
      name = (string)windowElement.Attribute("name");
      marker = (bool?)windowElement.Attribute("marker");
      controlId = XmlHelper.GetNumericValue(windowElement, "controlId");
      classText = (string)windowElement.Attribute("class");
      captionText = (string)windowElement.Attribute("caption");
      visible = (bool?)windowElement.Attribute("visible");
      IEnumerable<Window> windows = windowElement.Elements().Select(FromXml);
      children.AddRange(windows);
    }

    public override string ToString()
    {
      return name;
    }

    private bool MatchChildren(IntPtr windowHandle, WindowMapper mapper)
    {
      IntPtr[] childHandles = WindowHelper.EnumChildWindows(windowHandle);

      bool lowChildrenCount = (childHandles.Length < children.Count);
      if (lowChildrenCount)
        return false;

      List<Window> pendingChildren = new List<Window>(children);

      foreach (IntPtr childHandle in childHandles)
      {
        Window matchingWindow = pendingChildren.FirstOrDefault(
          window => window.Match(childHandle, mapper));
        bool childMatched = (matchingWindow != null);
        if (childMatched)
          pendingChildren.Remove(matchingWindow);
      }

      bool hasAllChildrenMatched = (pendingChildren.Count == 0);

      return hasAllChildrenMatched;
    }

    public bool Match(IntPtr windowHandle, WindowMapper mapper)
    {
      bool? result = null;

      if (classText != null)
        result = (WindowHelper.GetClassName(windowHandle) == classText);
      if (result == false)
        return false;
      if (captionText != null)
        result = (WindowHelper.GetCaptionText(windowHandle) == captionText);
      if (result == false)
        return false;
      if (visible.HasValue)
        result = (PlatformHelper.IsWindowVisible(windowHandle) == visible.Value);
      if (result == false)
        return false;
      if (controlId.HasValue)
        result = (WindowHelper.GetControlID(windowHandle) == controlId.Value);
      if (result == false)
        return false;

      if (children.Count > 0)
        result = MatchChildren(windowHandle, mapper);

      if (!result.HasValue)
        throw new InvalidOperationException("Window template does not have any window specifier.");

      if (result.Value)
        mapper.Add(windowHandle, this);

      return result.Value;
    }

    public Window(IntPtr handle)
    {
      Infer(handle);
    }

    public void Infer(IntPtr handle)
    {
      name = string.Concat("0x", handle.ToString("X8"));
      classText = WindowHelper.GetClassName(handle);
      captionText = WindowHelper.GetCaptionText(handle);
      visible = PlatformHelper.IsWindowVisible(handle);
      controlId = WindowHelper.GetControlID(handle);
      UpdateChildren(handle);
    }

    private void UpdateChildren(IntPtr handle)
    {
      IntPtr[] childHandles = WindowHelper.EnumChildWindows(handle);

      children.Clear();

      foreach (IntPtr childHandle in childHandles)
      {
        Window childWindow = new Window(childHandle);
        children.Add(childWindow);
      }
    }
  }
}
