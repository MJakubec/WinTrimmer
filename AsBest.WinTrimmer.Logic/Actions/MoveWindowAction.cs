using System;
using System.Xml.Linq;

namespace AsBest.WinTrimmer
{
  internal sealed class MoveWindowAction : WindowAction
  {
    private int left;
    private int top;

    protected override string ElementName
    {
      get
      {
        return "move";
      }
    }

    public int Left
    {
      get { return left; }
      set { left = value; }
    }

    public int Top
    {
      get { return top; }
      set { top = value; }
    }

    protected override void Execute(IntPtr handle)
    {
      Rectangle rectangle = WindowHelper.GetWindowRectangle(handle);
      WindowHelper.MoveWindow(handle, left, top, rectangle.Width, rectangle.Height);
    }

    public MoveWindowAction(XElement actionElement) : base(actionElement)
    {
      left = (int)actionElement.Attribute("left");
      top = (int)actionElement.Attribute("top");
    }

    public static new WindowAction FromXml(XElement actionElement)
    {
      return new MoveWindowAction(actionElement);
    }
  }
}
