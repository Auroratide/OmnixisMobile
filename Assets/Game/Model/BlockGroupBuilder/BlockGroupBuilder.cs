using System;
using System.Collections.Generic;

namespace Auroratide.Omnixis.Model {
  public class BlockGroupBuilder {
    private Position position;
    private Movement movement;
    private MergeStrategy merging;
    private List<Block> blocks;

    public BlockGroupBuilder(Position position, Movement movement, MergeStrategy merging) {
      this.position = position;
      this.movement = movement;
      this.merging = merging;
      this.blocks = new List<Block>();
    }

    public BlockGroupBuilder WithBlockOffset(int x, int y) {
      blocks.Add(new Block(position.Offset(x, y)));
      return this;
    }

    public BlockGroupBuilder ForEachBlock(Action<Block> action) {
      blocks.ForEach(action);
      return this;
    }

    public BlockGroup Build() {
      return new BlockGroup(blocks, movement, merging);
    }
  }
}