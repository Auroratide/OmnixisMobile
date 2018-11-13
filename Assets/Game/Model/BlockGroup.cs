using System.Linq;
using System.Collections.Generic;

namespace Auroratide.Omnixis.Model {
  public class BlockGroup {
    protected List<Block> blocks;
    protected Movement movement;
    protected MergeStrategy merging;

    public BlockGroup(List<Block> blocks, Movement movement, MergeStrategy merging) {
      this.blocks = blocks;
      this.movement = movement;
      this.merging = merging;
    }

    public virtual void Update() {
      Translation translation = movement.Translation();
      Translate(translation);

      merging.Merge(this, translation);
    }

    public bool Overlaps(BlockGroup other) {
      return this.blocks.Any(thisBlock =>
        other.blocks.Any(otherBlock =>
          thisBlock.Overlaps(otherBlock)
        )
      );
    }

    public void Merge(BlockGroup other) {
      this.blocks.AddRange(other.blocks);
      other.blocks.RemoveAll(_ => true);
    }

    public void Translate(Translation translation) {
      blocks.ForEach(block => block.Move(translation));
    }
  }
}