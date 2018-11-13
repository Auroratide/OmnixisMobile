namespace Auroratide.Omnixis.Model {
  public class Block {
    private Position position;
    
    public Block(Position position) {
      this.position = position;
    }

    public Position Position {
      get { return position; }
    }

    public virtual void Move(Translation translation) {
      position.Translate(translation);
    }

    public virtual bool Overlaps(Block other) {
      return this.position.Equals(other.position);
    }
  }
}