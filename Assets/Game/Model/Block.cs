namespace Auroratide.Omnixis.Model {
  public class Block {
    private Position position;
    private AxisMovement movement;
    
    public Block(Position position, AxisMovement movement) {
      this.position = position;
      this.movement = movement;
    }

    public void Update() {
      position.Translate(movement.Translation());
    }
  }
}