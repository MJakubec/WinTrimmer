using System;
using System.Xml.Linq;

namespace AsBest.WinTrimmer
{
  internal abstract class WindowAction
  {
    private string name;

    public string Name
    {
      get { return name; }
      set { name = value; }
    }

    protected WindowAction(XElement actionElement)
    {
      name = (string)actionElement.Attribute("name");
    }

    protected abstract void Execute(IntPtr handle);

    public void Execute(WindowMapper mapper)
    {
      IntPtr handle = mapper.LookupHandle(name);
      Execute(handle);
    }

    public static WindowAction FromXml(XElement actionElement)
    {
      string actionName = actionElement.Name.LocalName;

      switch (actionName)
      {
        case "show":
          return new ShowWindowAction(actionElement);
        case "hide":
          return new HideWindowAction(actionElement);
        case "move":
          return new MoveWindowAction(actionElement);
        case "size":
          return new SizeWindowAction(actionElement);
        case "text":
          return new TextWindowAction(actionElement);
      }

      throw new InvalidOperationException("An invalid action name has been specified in a template.");
    }

    public override string ToString()
    {
      return name;
    }

    protected abstract string ElementName
    {
      get;
    }

    protected virtual void FillXml(XElement actionElement)
    {
    }

    public virtual XElement ToXml()
    {
      XElement actionElement = new XElement(this.ElementName);
      actionElement.SetAttributeValue("name", name);
      FillXml(actionElement);
      return actionElement;
    }
  }
}
