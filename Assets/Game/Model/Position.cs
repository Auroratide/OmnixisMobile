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

    public Position Offset(int x, int y) {
      return new Position(this.x + x, this.y + y);
    }

    public override bool Equals(object obj) {
      Position other = obj as Position;
      return this.x == other.x && this.y == other.y;
    }

    public override int GetHashCode() {
      return x * 31 + y;
    }
  }
}
