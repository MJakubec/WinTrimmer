﻿namespace AsBest.WinTrimmer
{
  public struct Point
  {
    private int x;
    private int y;

    public Point(int x, int y)
    {
      this.x = x;
      this.y = y;
    }

    public int X
    {
      get { return x; }
      set { x = value; }
    }

    public int Y
    {
      get { return y; }
      set { y = value; }
    }
  }
}
