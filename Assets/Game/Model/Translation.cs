namespace Auroratide.Omnixis.Model {
  public struct Translation {
    private int x;
    private int y;

    public Translation(int x, int y) {
      this.x = x;
      this.y = y;
    }

    public int X {
      get { return x; }
    }

    public int Y {
      get { return y; }
    }
  }
}
