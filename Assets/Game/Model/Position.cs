namespace Auroratide.Omnixis.Model {
  public class Position {
    private int x;
    private int y;

    public Position(int x, int y) {
      this.x = x;
      this.y = y;
    }

    public int X {
      get { return x; }
    }

    public int Y {
      get { return y; }
    }

    public void Translate(Translation translation) {
      this.x += translation.X;
      this.y += translation.Y;
    }
  }
}
