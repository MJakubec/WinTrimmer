using System;
using System.Globalization;
using System.Xml.Linq;

namespace AsBest.WinTrimmer
{
  internal static class XmlHelper
  {
    private const string HexadecimalPrefix = "0x";

    public static int? GetNumericValue(XElement element, string attributeName)
    {
      string text = (string)element.Attribute(attributeName);
      if (text == null)
        return null;
      if (text.Length == 0)
        throw new InvalidOperationException("A numeric value cannot be empty.");
      bool isHexa = text.StartsWith("0x", StringComparison.InvariantCultureIgnoreCase);
      if (isHexa)
        return int.Parse(text.Substring(HexadecimalPrefix.Length), NumberStyles.HexNumber);
      return int.Parse(text);
    }
  }
}
