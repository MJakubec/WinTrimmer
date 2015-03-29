using System;
using System.Xml.Linq;

namespace AsBest.WinTrimmer
{
  public static class LookupCommand
  {
    public static void Execute(string captionText)
    {
      IntPtr[] handles = WindowHelper.EnumVisibleWindows();

      foreach (IntPtr handle in handles)
      {
        string text = WindowHelper.GetCaptionText(handle);
        if (text != captionText)
          continue;
        Template template = Template.FromHandle(handle);
        XElement templateElement = template.ToXml();
        Console.WriteLine(templateElement);
      }
    }
  }
}
