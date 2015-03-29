using System.ComponentModel;
using System.Windows.Forms;

namespace AsBest.WinTrimmer
{
  public partial class NotificationComponent : Component
  {
    private readonly MainForm mainForm = new MainForm();

    public NotificationComponent()
    {
      InitializeComponent();
    }

    private void MenuConfigure_Click(object sender, System.EventArgs e)
    {
      mainForm.Show();
      mainForm.Activate();
    }

    private void MenuExit_Click(object sender, System.EventArgs e)
    {
      Application.Exit();
    }

    private void LookupTimer_Tick(object sender, System.EventArgs e)
    {
      TrimmingManager.Instance.LookupMatchingWindows();
      mainForm.UpdateTemplateHitCount();
    }
  }
}
