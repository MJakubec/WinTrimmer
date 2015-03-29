using System.ComponentModel;
using System.Windows.Forms;

namespace AsBest.WinTrimmer
{
  partial class NotificationComponent
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotificationComponent));
      this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
      this.menuNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.menuConfigure = new System.Windows.Forms.ToolStripMenuItem();
      this.menuSeparator = new System.Windows.Forms.ToolStripSeparator();
      this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
      this.lookupTimer = new System.Windows.Forms.Timer(this.components);
      this.menuNotify.SuspendLayout();
      // 
      // notifyIcon
      // 
      this.notifyIcon.ContextMenuStrip = this.menuNotify;
      this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
      this.notifyIcon.Text = "AsBEST WinTrimmer";
      this.notifyIcon.Visible = true;
      // 
      // menuNotify
      // 
      this.menuNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuConfigure,
            this.menuSeparator,
            this.menuExit});
      this.menuNotify.Name = "menuNotify";
      this.menuNotify.Size = new System.Drawing.Size(137, 54);
      // 
      // menuConfigure
      // 
      this.menuConfigure.Name = "menuConfigure";
      this.menuConfigure.Size = new System.Drawing.Size(136, 22);
      this.menuConfigure.Text = "&Configure...";
      this.menuConfigure.Click += new System.EventHandler(this.MenuConfigure_Click);
      // 
      // menuSeparator
      // 
      this.menuSeparator.Name = "menuSeparator";
      this.menuSeparator.Size = new System.Drawing.Size(133, 6);
      // 
      // menuExit
      // 
      this.menuExit.Name = "menuExit";
      this.menuExit.Size = new System.Drawing.Size(136, 22);
      this.menuExit.Text = "E&xit";
      this.menuExit.Click += new System.EventHandler(this.MenuExit_Click);
      // 
      // lookupTimer
      // 
      this.lookupTimer.Enabled = true;
      this.lookupTimer.Tick += new System.EventHandler(this.LookupTimer_Tick);
      this.menuNotify.ResumeLayout(false);

    }

    #endregion

    private NotifyIcon notifyIcon;
    private ContextMenuStrip menuNotify;
    private ToolStripMenuItem menuConfigure;
    private ToolStripMenuItem menuExit;
    private ToolStripSeparator menuSeparator;
    private Timer lookupTimer;
  }
}
