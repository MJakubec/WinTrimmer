using System;
using System.Windows.Forms;

namespace AsBest.WinTrimmer.Client
{
  internal static class StartupManager
  {
    private static readonly NotificationComponent notificationComponent;

    static StartupManager() 
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      notificationComponent = new NotificationComponent();
    }

    [STAThread]
    private static void Main()
    {
      TrimmingManager.Instance.LoadTemplates();
      Application.Run();
      notificationComponent.Dispose();
    }
  }
}
