using System;
using System.Xml.Linq;

namespace AsBest.WinTrimmer
{
  internal sealed class ShowWindowAction: WindowAction
  {
    protected override string ElementName
    {
      get
      {
        return "show";
      }
    }

    public ShowWindowAction(XElement actionElement) : base(actionElement)
    {
    }

    protected override void Execute(IntPtr handle)
    {
      WindowHelper.ShowWindow(handle);
    }
  }
}
