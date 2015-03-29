using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace AsBest.WinTrimmer
{
  public class Template
  {
    private string name;
    private string processImagePath;
    private int? majorSystemVersion;
    private int? minorSystemVersion;
    private Window window;
    private readonly List<WindowAction> actions = new List<WindowAction>();

    private string location = string.Empty;
    private string fileName = string.Empty;
    private bool enabled = true;

    public string Name
    {
      get { return name; }
      set { name = value; }
    }

    public string ProcessImagePath
    {
      get { return processImagePath; }
      set { processImagePath = value; }
    }

    public int? MajorSystemVersion
    {
      get { return majorSystemVersion; }
      set { majorSystemVersion = value; }
    }

    public int? MinorSystemVersion
    {
      get { return minorSystemVersion; }
      set { minorSystemVersion = value; }
    }

    public Window Window
    {
      get { return window; }
      set { window = value; }
    }

    public bool Enabled
    {
      get { return enabled; }
      set { enabled = value; }
    }

    public string FileName
    {
      get { return fileName; }
      set { fileName = value; }
    }

    public string Location
    {
      get { return location; }
      set { location = value; }
    }

    private XElement FindElement(XElement parentElement, string elementName)
    {
      XElement element = parentElement.Element(elementName);
      if (element == null)
      {
        string message = string.Format("There is no <{0}> element in a template.", elementName);
        throw new InvalidOperationException(message);
      }
      return element;
    }

    public Template(XElement templateElement)
    {
      XElement lookupElement = FindElement(templateElement, "lookup");
      XElement windowElement = FindElement(lookupElement, "window");
      XElement setupElement = FindElement(templateElement, "setup");
      XElement[] actionElements = setupElement.Elements().ToArray();

      name = (string)templateElement.Attribute("name");
      majorSystemVersion = XmlHelper.GetNumericValue(templateElement, "majorSystemVersion");
      minorSystemVersion = XmlHelper.GetNumericValue(templateElement, "minorSystemVersion");
      processImagePath = (string)lookupElement.Attribute("image");
      window = Window.FromXml(windowElement);
      actions.AddRange(actionElements.Select(WindowAction.FromXml));
    }

    public Template(IntPtr handle)
    {
      window = new Window(handle);
      name = window.CaptionText;

      majorSystemVersion = Environment.OSVersion.Version.Major;
      minorSystemVersion = Environment.OSVersion.Version.Minor;

      processImagePath = WindowHelper.GetWindowProcessFileName(handle);
    }

    public XElement ToXml()
    {
      XElement templateElement = new XElement("template");
      templateElement.SetAttributeValue("name", name);
      templateElement.SetAttributeValue("majorSystemVersion", majorSystemVersion);
      templateElement.SetAttributeValue("minorSystemVersion", minorSystemVersion);
      XElement lookupElement = new XElement("lookup");
      lookupElement.SetAttributeValue("image", processImagePath);
      lookupElement.Add(window.ToXml());
      templateElement.Add(lookupElement);
      XElement setupElement = new XElement("setup");
      templateElement.Add(setupElement);
      setupElement.Add(Enumerable.Select(actions, a => a.ToXml()).ToArray());
      return templateElement;
    }

    public void Execute(WindowMapper mapper)
    {
      foreach (WindowAction action in actions)
        action.Execute(mapper);
    }

    public override string ToString()
    {
      return name;
    }

    public static Template FromHandle(IntPtr handle)
    {
      return new Template(handle);
    }

    public static Template FromXml(XElement templateElement)
    {
      return new Template(templateElement);
    }

    public static Template FromFile(string file)
    {
      XElement templateElement = XElement.Load(file);
      Template template = Template.FromXml(templateElement);
      template.Location = Path.GetDirectoryName(file);
      template.FileName = Path.GetFileName(file);
      return template;
    }
  }
}
