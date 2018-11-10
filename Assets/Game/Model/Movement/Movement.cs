namespace Auroratide.Omnixis.Model {
  public class Movement {
    private ControlledBool left;
    private ControlledBool right;
    private ControlledBool up;
    private ControlledBool down;

    public Movement(Axis axis) {
      left = new ControlledBool(() => axis.Horizontal() < 0);
      right = new ControlledBool(() => axis.Horizontal() > 0);
      up = new ControlledBool(() => axis.Vertical() > 0);
      down = new ControlledBool(() => axis.Vertical() < 0);
    }

    public Translation Translation() {
      if(left.IsActive())  return new Translation(-1, 0);
      if(right.IsActive()) return new Translation(1, 0);
      if(up.IsActive())    return new Translation(0, 1);
      if(down.IsActive())  return new Translation(0, -1);

      return new Translation(0, 0);
    }
  }
}