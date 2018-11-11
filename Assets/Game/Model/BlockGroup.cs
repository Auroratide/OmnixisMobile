using System.Collections.Generic;

namespace Auroratide.Omnixis.Model {
  public class BlockGroup {
    private List<Block> blocks;
    private Movement movement;

    public BlockGroup(List<Block> blocks, Movement movement) {
      this.blocks = blocks;
      this.movement = movement;
    }

    public void Update() {
      blocks.ForEach(block => block.Move(movement.Translation()));
    }
  }
}