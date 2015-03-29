namespace AsBest.WinTrimmer
{
  partial class MainForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.listTemplates = new System.Windows.Forms.ListView();
      this.columnTemplateName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnTemplateLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnTemplateFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnTemplateImage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnTemplateState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnTemplateHitCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.labelTemplates = new System.Windows.Forms.Label();
      this.buttonEdit = new System.Windows.Forms.Button();
      this.buttonNew = new System.Windows.Forms.Button();
      this.buttonDelete = new System.Windows.Forms.Button();
      this.buttonEnable = new System.Windows.Forms.Button();
      this.buttonDisable = new System.Windows.Forms.Button();
      this.buttonCopy = new System.Windows.Forms.Button();
      this.buttonClose = new System.Windows.Forms.Button();
      this.buttonExport = new System.Windows.Forms.Button();
      this.buttonImport = new System.Windows.Forms.Button();
      this.buttonLookup = new System.Windows.Forms.Button();
      this.buttonRename = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // listTemplates
      // 
      this.listTemplates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.listTemplates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnTemplateName,
            this.columnTemplateLocation,
            this.columnTemplateFile,
            this.columnTemplateImage,
            this.columnTemplateState,
            this.columnTemplateHitCount});
      this.listTemplates.FullRowSelect = true;
      this.listTemplates.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.listTemplates.HideSelection = false;
      this.listTemplates.Location = new System.Drawing.Point(13, 32);
      this.listTemplates.Name = "listTemplates";
      this.listTemplates.ShowGroups = false;
      this.listTemplates.Size = new System.Drawing.Size(555, 358);
      this.listTemplates.TabIndex = 1;
      this.listTemplates.UseCompatibleStateImageBehavior = false;
      this.listTemplates.View = System.Windows.Forms.View.Details;
      this.listTemplates.SelectedIndexChanged += new System.EventHandler(this.listTemplates_SelectedIndexChanged);
      // 
      // columnTemplateName
      // 
      this.columnTemplateName.Text = "Name";
      this.columnTemplateName.Width = 126;
      // 
      // columnTemplateLocation
      // 
      this.columnTemplateLocation.Text = "Location";
      this.columnTemplateLocation.Width = 96;
      // 
      // columnTemplateFile
      // 
      this.columnTemplateFile.Text = "File";
      this.columnTemplateFile.Width = 150;
      // 
      // columnTemplateImage
      // 
      this.columnTemplateImage.Text = "Image";
      // 
      // columnTemplateState
      // 
      this.columnTemplateState.Text = "State";
      this.columnTemplateState.Width = 53;
      // 
      // columnTemplateHitCount
      // 
      this.columnTemplateHitCount.Text = "Hit Count";
      // 
      // labelTemplates
      // 
      this.labelTemplates.AutoSize = true;
      this.labelTemplates.Location = new System.Drawing.Point(10, 13);
      this.labelTemplates.Name = "labelTemplates";
      this.labelTemplates.Size = new System.Drawing.Size(160, 13);
      this.labelTemplates.TabIndex = 0;
      this.labelTemplates.Text = "&Templates available for trimming:";
      // 
      // buttonEdit
      // 
      this.buttonEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonEdit.Location = new System.Drawing.Point(582, 61);
      this.buttonEdit.Name = "buttonEdit";
      this.buttonEdit.Size = new System.Drawing.Size(88, 23);
      this.buttonEdit.TabIndex = 3;
      this.buttonEdit.Text = "&Edit...";
      this.buttonEdit.UseVisualStyleBackColor = true;
      this.buttonEdit.Visible = false;
      // 
      // buttonNew
      // 
      this.buttonNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonNew.Location = new System.Drawing.Point(582, 32);
      this.buttonNew.Name = "buttonNew";
      this.buttonNew.Size = new System.Drawing.Size(88, 23);
      this.buttonNew.TabIndex = 2;
      this.buttonNew.Text = "&New...";
      this.buttonNew.UseVisualStyleBackColor = true;
      this.buttonNew.Visible = false;
      // 
      // buttonDelete
      // 
      this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonDelete.Location = new System.Drawing.Point(582, 90);
      this.buttonDelete.Name = "buttonDelete";
      this.buttonDelete.Size = new System.Drawing.Size(88, 23);
      this.buttonDelete.TabIndex = 4;
      this.buttonDelete.Text = "&Delete...";
      this.buttonDelete.UseVisualStyleBackColor = true;
      this.buttonDelete.Visible = false;
      // 
      // buttonEnable
      // 
      this.buttonEnable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonEnable.Location = new System.Drawing.Point(582, 287);
      this.buttonEnable.Name = "buttonEnable";
      this.buttonEnable.Size = new System.Drawing.Size(88, 23);
      this.buttonEnable.TabIndex = 10;
      this.buttonEnable.Text = "&Enable";
      this.buttonEnable.UseVisualStyleBackColor = true;
      this.buttonEnable.Click += new System.EventHandler(this.buttonEnable_Click);
      // 
      // buttonDisable
      // 
      this.buttonDisable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonDisable.Location = new System.Drawing.Point(582, 316);
      this.buttonDisable.Name = "buttonDisable";
      this.buttonDisable.Size = new System.Drawing.Size(88, 23);
      this.buttonDisable.TabIndex = 11;
      this.buttonDisable.Text = "&Disable";
      this.buttonDisable.UseVisualStyleBackColor = true;
      this.buttonDisable.Click += new System.EventHandler(this.buttonDisable_Click);
      // 
      // buttonCopy
      // 
      this.buttonCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonCopy.Location = new System.Drawing.Point(582, 119);
      this.buttonCopy.Name = "buttonCopy";
      this.buttonCopy.Size = new System.Drawing.Size(88, 23);
      this.buttonCopy.TabIndex = 5;
      this.buttonCopy.Text = "&Copy...";
      this.buttonCopy.UseVisualStyleBackColor = true;
      this.buttonCopy.Visible = false;
      // 
      // buttonClose
      // 
      this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.buttonClose.Location = new System.Drawing.Point(582, 367);
      this.buttonClose.Name = "buttonClose";
      this.buttonClose.Size = new System.Drawing.Size(88, 23);
      this.buttonClose.TabIndex = 12;
      this.buttonClose.Text = "Close";
      this.buttonClose.UseVisualStyleBackColor = true;
      this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
      // 
      // buttonExport
      // 
      this.buttonExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonExport.Location = new System.Drawing.Point(582, 148);
      this.buttonExport.Name = "buttonExport";
      this.buttonExport.Size = new System.Drawing.Size(88, 23);
      this.buttonExport.TabIndex = 6;
      this.buttonExport.Text = "E&xport...";
      this.buttonExport.UseVisualStyleBackColor = true;
      this.buttonExport.Visible = false;
      // 
      // buttonImport
      // 
      this.buttonImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonImport.Location = new System.Drawing.Point(582, 177);
      this.buttonImport.Name = "buttonImport";
      this.buttonImport.Size = new System.Drawing.Size(88, 23);
      this.buttonImport.TabIndex = 7;
      this.buttonImport.Text = "&Import...";
      this.buttonImport.UseVisualStyleBackColor = true;
      this.buttonImport.Visible = false;
      // 
      // buttonLookup
      // 
      this.buttonLookup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonLookup.Location = new System.Drawing.Point(582, 206);
      this.buttonLookup.Name = "buttonLookup";
      this.buttonLookup.Size = new System.Drawing.Size(88, 23);
      this.buttonLookup.TabIndex = 8;
      this.buttonLookup.Text = "&Lookup...";
      this.buttonLookup.UseVisualStyleBackColor = true;
      this.buttonLookup.Visible = false;
      // 
      // buttonRename
      // 
      this.buttonRename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonRename.Location = new System.Drawing.Point(582, 235);
      this.buttonRename.Name = "buttonRename";
      this.buttonRename.Size = new System.Drawing.Size(88, 23);
      this.buttonRename.TabIndex = 9;
      this.buttonRename.Text = "&Rename...";
      this.buttonRename.UseVisualStyleBackColor = true;
      this.buttonRename.Visible = false;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.buttonClose;
      this.ClientSize = new System.Drawing.Size(684, 402);
      this.Controls.Add(this.buttonCopy);
      this.Controls.Add(this.buttonClose);
      this.Controls.Add(this.buttonDisable);
      this.Controls.Add(this.buttonRename);
      this.Controls.Add(this.buttonLookup);
      this.Controls.Add(this.buttonImport);
      this.Controls.Add(this.buttonExport);
      this.Controls.Add(this.buttonEnable);
      this.Controls.Add(this.buttonDelete);
      this.Controls.Add(this.buttonNew);
      this.Controls.Add(this.buttonEdit);
      this.Controls.Add(this.labelTemplates);
      this.Controls.Add(this.listTemplates);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MinimumSize = new System.Drawing.Size(700, 440);
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "AsBEST WinTrimmer - Template Manager";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ListView listTemplates;
    private System.Windows.Forms.ColumnHeader columnTemplateName;
    private System.Windows.Forms.ColumnHeader columnTemplateLocation;
    private System.Windows.Forms.Label labelTemplates;
    private System.Windows.Forms.Button buttonEdit;
    private System.Windows.Forms.Button buttonNew;
    private System.Windows.Forms.Button buttonDelete;
    private System.Windows.Forms.Button buttonEnable;
    private System.Windows.Forms.Button buttonDisable;
    private System.Windows.Forms.Button buttonCopy;
    private System.Windows.Forms.Button buttonClose;
    private System.Windows.Forms.Button buttonExport;
    private System.Windows.Forms.Button buttonImport;
    private System.Windows.Forms.Button buttonLookup;
    private System.Windows.Forms.Button buttonRename;
    private System.Windows.Forms.ColumnHeader columnTemplateFile;
    private System.Windows.Forms.ColumnHeader columnTemplateHitCount;
    private System.Windows.Forms.ColumnHeader columnTemplateImage;
    private System.Windows.Forms.ColumnHeader columnTemplateState;
  }
}

