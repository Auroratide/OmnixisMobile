using System.Linq;
using System.Collections.Generic;

namespace Auroratide.Omnixis.Model {
  public class BlockGroup {
    protected List<Block> blocks;
    protected Movement movement;

    public BlockGroup(List<Block> blocks, Movement movement) {
      this.blocks = blocks;
      this.movement = movement;
    }

    public virtual void Update(CoreBlockGroup core) {
      Translation translation = movement.Translation();
      Translate(translation);

      if(this.Overlaps(core)) {
        Translate(translation.Negate());
        core.Merge(this);
      }
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