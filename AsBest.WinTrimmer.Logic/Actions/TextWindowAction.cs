using System;
using System.Xml.Linq;

namespace AsBest.WinTrimmer
{
  internal sealed class TextWindowAction : WindowAction
  {
    private string value;

    protected override string ElementName
    {
      get
      {
        return "text";
      }
    }

    protected override void FillXml(XElement actionElement)
    {
      actionElement.SetAttributeValue("value", value);
    }

    public string Value
    {
      get { return value; }
      set { this.value = value; }
    }

    protected override void Execute(IntPtr handle)
    {
      WindowHelper.SetCaptionText(handle, value);
    }

    public TextWindowAction(XElement actionElement) : base(actionElement)
    {
      value = (string)actionElement.Attribute("value");
    }

    public static new WindowAction FromXml(XElement actionElement)
    {
      return new TextWindowAction(actionElement);
    }
  }
}
