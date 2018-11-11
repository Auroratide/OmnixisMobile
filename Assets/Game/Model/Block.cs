namespace Auroratide.Omnixis.Model {
  public class Block {
    private Position position;
    
    public Block(Position position) {
      this.position = position;
    }

    public void Move(Translation translation) {
      position.Translate(translation);
    }
  }
}