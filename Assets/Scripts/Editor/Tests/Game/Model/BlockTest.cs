using System.Collections.Generic;
using NUnit.Framework;
using Auroratide.NBehave;

namespace Auroratide.Omnixis.Test.Model {
  using Auroratide.Omnixis.Model;

  public class BlockTest {
    [Test] public void ShouldMoveTheBlockPosition() {
      Position position = new Position(0, 0);
      Block block = new Block(position);

      block.Move(new Translation(1, 1));

      Assert.That(position, Is.EqualTo(new Position(1, 1)));
    }

    [Test] public void ShouldReturnTrueWhenBlocksOccupySamePosition() {
      Block apple = new Block(new Position(0, 0));
      Block orange = new Block(new Position(0, 0));

      Assert.That(apple.Overlaps(orange), Is.True);
    }

    [Test] public void ShouldReturnFalseWhenBlocksDoNotOccupySamePosition() {
      Block apple = new Block(new Position(0, 0));
      Block orange = new Block(new Position(0, 1));

      Assert.That(apple.Overlaps(orange), Is.False);
    }
  }
}