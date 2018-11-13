using System.Collections.Generic;

namespace Auroratide.Omnixis.Model {
  public class CoreGroupBuilder : BlockGroupBuilder {
    public CoreGroupBuilder(Position position, Axis axis, List<BlockGroup> otherGroups)
    : base(position, new AxisMovement(axis), new MergeIntoSelf(otherGroups)) {
      WithBlockOffset(-1, -1);
      WithBlockOffset(-1, 0);
      WithBlockOffset(-1, 1);
      WithBlockOffset(0, -1);
      WithBlockOffset(0, 0);
      WithBlockOffset(0, 1);
      WithBlockOffset(1, -1);
      WithBlockOffset(1, 0);
      WithBlockOffset(1, 1);
    }
  }
}