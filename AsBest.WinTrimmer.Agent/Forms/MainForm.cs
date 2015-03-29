using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace AsBest.WinTrimmer
{
  public partial class MainForm : Form
  {
    public MainForm()
    {
      InitializeComponent();
    }

    private void buttonClose_Click(object sender, EventArgs e)
    {
      this.Hide();
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (e.CloseReason == CloseReason.UserClosing)
      {
        e.Cancel = true;
        this.Hide();
      }
    }

    private static string GetTemplateHitCountText(Template template)
    {
      int hitCount = TrimmingManager.Instance.Mappers.Count(m => m.IsWindowMapped(template.Window));
      string hitCountText = hitCount.ToString(CultureInfo.InvariantCulture);
      return hitCountText;
    }

    private static void UpdateItemValues(Template template, ListViewItem item)
    {
      string stateText = (template.Enabled ? "Enabled" : "Disabled");
      string hitCountText = GetTemplateHitCountText(template);
      item.SubItems.Clear();
      item.Text = template.Name;
      item.SubItems.Add(template.Location);
      item.SubItems.Add(template.FileName);
      item.SubItems.Add(template.ProcessImagePath);
      item.SubItems.Add(stateText);
      item.SubItems.Add(hitCountText);
      item.Tag = template;
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
      LoadTemplateItems();
      UpdateButtonState();
    }

    private void LoadTemplateItems()
    {
      foreach (Template template in TrimmingManager.Instance.Templates)
      {
        ListViewItem item = new ListViewItem(template.Name);
        UpdateItemValues(template, item);
        listTemplates.Items.Add(item);
      }
    }

    private void UpdateButtonState()
    {
      bool hasEnabledItems = false;
      bool hasDisabledItems = false;

      foreach (ListViewItem item in listTemplates.SelectedItems)
      {
        Template template = (Template)item.Tag;

        if (template.Enabled)
          hasEnabledItems = true;
        else
          hasDisabledItems = true;
      }

      buttonEnable.Enabled = hasDisabledItems;
      buttonDisable.Enabled = hasEnabledItems;
    }

    private void ChangeSelectedTemplateState(bool state)
    {
      foreach (ListViewItem item in listTemplates.SelectedItems)
      {
        Template template = (Template)item.Tag;
        template.Enabled = state;
        UpdateItemValues(template, item);
      }
    }

    private void listTemplates_SelectedIndexChanged(object sender, EventArgs e)
    {
      UpdateButtonState();
    }

    private void buttonEnable_Click(object sender, EventArgs e)
    {
      ChangeSelectedTemplateState(true);
      UpdateButtonState();
    }

    private void buttonDisable_Click(object sender, EventArgs e)
    {
      ChangeSelectedTemplateState(false);
      UpdateButtonState();
    }

    public void UpdateTemplateHitCount()
    {
      foreach (ListViewItem item in listTemplates.Items)
      {
        Template template = (Template)item.Tag;
        string hitCountText = GetTemplateHitCountText(template);
        int columnIndex = listTemplates.Columns.IndexOf(columnTemplateHitCount);
        ListViewItem.ListViewSubItem subItem = item.SubItems[columnIndex];
        bool unchanged = (subItem.Text == hitCountText);
        if (unchanged)
          continue;
        subItem.Text = hitCountText;
      }
    }
  }
}
