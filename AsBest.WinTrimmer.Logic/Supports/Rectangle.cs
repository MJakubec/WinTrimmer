using System.Globalization;
using System.Runtime.InteropServices;

namespace AsBest.WinTrimmer
{
  [StructLayout(LayoutKind.Sequential)]
  public struct Rectangle
  {
    private const string TextFormatTemplate = "{{Left={0},Top={1},Right={2},Bottom={3}}}";

    private int left;
    private int top;
    private int right;
    private int bottom;

    public Rectangle(int left, int top, int right, int bottom)
    {
      this.left = left;
      this.top = top;
      this.right = right;
      this.bottom = bottom;
    }

    public int Height
    {
      get { return Bottom - Top; }
      set { Bottom = value + Top; }
    }

    public int Width
    {
      get { return Right - Left; }
      set { Right = value + Left; }
    }

    public Point Location
    {
      get { return new Point(Left, Top); }
    }

    public int Left
    {
      get { return left; }
      set { left = value; }
    }

    public int Top
    {
      get { return top; }
      set { top = value; }
    }

    public int Right
    {
      get { return right; }
      set { right = value; }
    }

    public int Bottom
    {
      get { return bottom; }
      set { bottom = value; }
    }

    public override string ToString()
    {
      return string.Format(
        CultureInfo.CurrentCulture,
        TextFormatTemplate,
        Left,
        Top,
        Right,
        Bottom);
    }
  }

}
