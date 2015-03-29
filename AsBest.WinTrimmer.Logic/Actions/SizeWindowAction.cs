using System;
using System.Xml.Linq;

namespace AsBest.WinTrimmer
{
  internal sealed class SizeWindowAction : WindowAction
  {
    private int width;
    private int height;

    protected override void FillXml(XElement actionElement)
    {
      actionElement.SetAttributeValue("width", width);
      actionElement.SetAttributeValue("height", height);
    }

    protected override string ElementName
    {
      get
      {
        return "size";
      }
    }

    public int Width
    {
      get { return width; }
      set { width = value; }
    }

    public int Height
    {
      get { return height; }
      set { height = value; }
    }

    protected override void Execute(IntPtr handle)
    {
      Rectangle rectangle = WindowHelper.GetWindowRectangle(handle);
      WindowHelper.MoveWindow(handle, rectangle.Left, rectangle.Top, width, height);
    }

    public SizeWindowAction(XElement actionElement) : base(actionElement)
    {
      width = (int)actionElement.Attribute("width");
      height = (int)actionElement.Attribute("height");
    }
  }
}
