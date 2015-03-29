using System;
using System.Xml.Linq;

namespace AsBest.WinTrimmer
{
  internal sealed class HideWindowAction : WindowAction
  {
    protected override string ElementName
    {
      get
      {
        return "hide";
      }
    }
    
    public HideWindowAction(XElement actionElement)
      : base(actionElement)
    {
    }

    protected override void Execute(IntPtr handle)
    {
      WindowHelper.HideWindow(handle);
    }
  }
}
