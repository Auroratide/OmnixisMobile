using System.Linq;
using System.Collections.Generic;

namespace Auroratide.Omnixis.Model {
  public class BlockGroup {
    private List<Block> blocks;
    private Movement movement;
    private Translation lastTranslation;

    public BlockGroup(List<Block> blocks, Movement movement) {
      this.blocks = blocks;
      this.movement = movement;
    }

    public void Update() {
      lastTranslation = movement.Translation();
      Translate(lastTranslation);
    }

    public void UndoLastMovement() {
      Translate(lastTranslation.Negate());
    }

    public void Translate(Translation translation) {
      blocks.ForEach(block => block.Move(translation));
    }

    public Translation GetLastTranslation() {
      return lastTranslation;
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
  }
}