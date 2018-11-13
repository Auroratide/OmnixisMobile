using System.Collections.Generic;

namespace Auroratide.Omnixis.Model {
  public class BlockGroupFactory {
    public static BlockGroup CreateCore(Position p, Axis axis, List<BlockGroup> otherGroups) {
      List<Block> blocks = new List<Block>();
      blocks.Add(new Block(p.Offset(-1, -1)));
      blocks.Add(new Block(p.Offset(-1, 0)));
      blocks.Add(new Block(p.Offset(-1, 1)));
      blocks.Add(new Block(p.Offset(0, -1)));
      blocks.Add(new Block(p.Offset(0, 0)));
      blocks.Add(new Block(p.Offset(0, 1)));
      blocks.Add(new Block(p.Offset(1, -1)));
      blocks.Add(new Block(p.Offset(1, 0)));
      blocks.Add(new Block(p.Offset(1, 1)));

      return new BlockGroup(blocks, new AxisMovement(axis), new MergeIntoSelf(otherGroups));
    }

    public static BlockGroup CreateSquare(Position p, BlockGroup core) {
      List<Block> blocks = new List<Block>();
      blocks.Add(new Block(p));
      blocks.Add(new Block(p.Offset(1, 0)));
      blocks.Add(new Block(p.Offset(0, 1)));
      blocks.Add(new Block(p.Offset(1, 1)));

      return new BlockGroup(blocks, new UniDirectionalMovement(new Translation(0, 1)), new MergeIntoCore(core));
    }
  }
}