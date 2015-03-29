using System;
using System.IO;
using System.Threading;

namespace AsBest.WinTrimmer
{
  public static class ApplyCommand
  {
    private const int WindowDetectionDelay = 100;

    private static void ExecuteWindowLoop()
    {
      while (!Console.KeyAvailable)
      {
        TrimmingManager.Instance.LookupMatchingWindows();
        Thread.Sleep(WindowDetectionDelay);
      }
    }

    public static void Execute(string templatePath)
    {
      string defaultPath = Path.Combine(Environment.CurrentDirectory, "Templates");
      bool hasParameter = (templatePath != null);
      string currentPath = (hasParameter ? templatePath : defaultPath);

      TrimmingManager.Instance.LoadTemplates(currentPath);
      ExecuteWindowLoop();
    }
  }
}
