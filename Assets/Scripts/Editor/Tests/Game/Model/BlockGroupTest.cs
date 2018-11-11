using System.Collections.Generic;
using NUnit.Framework;
using Auroratide.NBehave;

namespace Auroratide.Omnixis.Test.Model {
  using Auroratide.Omnixis.Model;

  public class BlockGroupTest {
    [Test] public void ShouldMoveEachBlockInTheGroupByTheSameTranslation() {
      // GIVEN
      Block apple = Mock.Basic<Block>();
      Block orange = Mock.Basic<Block>();

      Movement movement = Mock.Basic<Movement>();
      Translation translation = new Translation(1, 1);
      When.Called(() => movement.Translation()).Then.Return(translation);

      List<Block> blocks = new List<Block>();
      blocks.Add(apple);
      blocks.Add(orange);
      BlockGroup group = new BlockGroup(blocks, movement);

      // WHEN
      group.Update();

      // THEN
      Verify.That(() => apple.Move(translation)).IsCalled();
      Verify.That(() => orange.Move(translation)).IsCalled();
    }

    [Test] public void ShouldReturnTrueWhenAtLeastOneBlockOverlaps() {
      Movement movement = Mock.Basic<Movement>();

      Block apple = CreateBlock(1, 2);
      Block orange = CreateBlock(1, 1);
      BlockGroup fruit = new BlockGroup(new List<Block> { apple, orange }, movement);

      Block tomato = CreateBlock(2, 2);
      Block carrot = CreateBlock(1, 2);
      BlockGroup vegetables = new BlockGroup(new List<Block> { tomato, carrot }, movement);

      Assert.That(fruit.Overlaps(vegetables), Is.True);
    }

    [Test] public void ShouldReturnFalseWhenNoBlocksOverlap() {
      Movement movement = Mock.Basic<Movement>();

      Block apple = CreateBlock(1, 2);
      Block orange = CreateBlock(1, 1);
      BlockGroup fruit = new BlockGroup(new List<Block> { apple, orange }, movement);

      Block tomato = CreateBlock(2, 2);
      Block carrot = CreateBlock(2, 3);
      BlockGroup vegetables = new BlockGroup(new List<Block> { tomato, carrot }, movement);

      Assert.That(fruit.Overlaps(vegetables), Is.False);
    }

    [Test] public void ShouldMoveAllTheBlocksFromOneGroupIntoTheOther() {
      Movement movement = Mock.Basic<Movement>();
      List<Block> fruit = new List<Block>() { CreateBlock(1, 1) };
      List<Block> vegetables = new List<Block>() { CreateBlock(1, 2) };
      BlockGroup fruitGroup = new BlockGroup(fruit, movement);
      BlockGroup vegetableGroup = new BlockGroup(vegetables, movement);

      fruitGroup.Merge(vegetableGroup);

      Assert.That(fruit.Count, Is.EqualTo(2));
      Assert.That(vegetables.Count, Is.EqualTo(0));
    }

    private Block CreateBlock(int x, int y) {
      return new Block(new Position(x, y));
    }
  }
}