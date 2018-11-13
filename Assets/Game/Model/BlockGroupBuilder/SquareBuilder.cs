using System.Collections.Generic;

namespace Auroratide.Omnixis.Model {
  public class SquareBuilder : BlockGroupBuilder {
    public SquareBuilder(Position position, BlockGroup core)
    : base(position, new UniDirectionalMovement(new Translation(0, 1)), new MergeIntoCore(core)) {
      WithBlockOffset(0, 0);
      WithBlockOffset(0, 1);
      WithBlockOffset(1, 0);
      WithBlockOffset(1, 1);
    }
  }
}