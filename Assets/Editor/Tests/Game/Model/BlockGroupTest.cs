using System.Collections.Generic;
using NUnit.Framework;
using Auroratide.NBehave;

namespace Auroratide.Omnixis.Test.Model {
  using Auroratide.Omnixis.Model;

  public class BlockGroupTest {
    private Movement movement;
    private MergeStrategy merging;

    [SetUp] public void Init() {
      movement = Mock.Basic<Movement>();
      merging = Mock.Basic<MergeStrategy>();
    }

    [Category("BlockGroup::Translate")]
    [Test] public void ShouldMoveEachBlockInTheGroupByTheSameTranslation() {
      // GIVEN
      Block apple = Mock.Basic<Block>();
      Block orange = Mock.Basic<Block>();
      BlockGroup group = CreateBlockGroup(apple, orange);
      
      Translation translation = new Translation(1, 1);

      // WHEN
      group.Translate(translation);

      // THEN
      Verify.That(() => apple.Move(translation)).IsCalled();
      Verify.That(() => orange.Move(translation)).IsCalled();
    }

    [Category("BlockGroup::Overlaps")]
    [Test] public void ShouldReturnTrueWhenAtLeastOneBlockOverlaps() {
      Block apple = CreateBlock(1, 2);
      Block orange = CreateBlock(1, 1);
      BlockGroup fruit = CreateBlockGroup(apple, orange);

      Block tomato = CreateBlock(2, 2);
      Block carrot = CreateBlock(1, 2);
      BlockGroup vegetables = CreateBlockGroup(tomato, carrot);

      Assert.That(fruit.Overlaps(vegetables), Is.True);
    }

    [Category("BlockGroup::Overlaps")]
    [Test] public void ShouldReturnFalseWhenNoBlocksOverlap() {
      Block apple = CreateBlock(1, 2);
      Block orange = CreateBlock(1, 1);
      BlockGroup fruit = CreateBlockGroup(apple, orange);

      Block tomato = CreateBlock(2, 2);
      Block carrot = CreateBlock(2, 3);
      BlockGroup vegetables = CreateBlockGroup(tomato, carrot);

      Assert.That(fruit.Overlaps(vegetables), Is.False);
    }

    [Category("BlockGroup::Merge")]
    [Test] public void ShouldMoveAllTheBlocksFromOneGroupIntoTheOther() {
      List<Block> fruit = new List<Block>() { CreateBlock(1, 1) };
      List<Block> vegetables = new List<Block>() { CreateBlock(1, 2) };
      BlockGroup fruitGroup = new BlockGroup(fruit, movement, merging);
      BlockGroup vegetableGroup = new BlockGroup(vegetables, movement, merging);

      fruitGroup.Merge(vegetableGroup);

      Assert.That(fruit.Count, Is.EqualTo(2));
      Assert.That(vegetables.Count, Is.EqualTo(0));
    }

    private Block CreateBlock(int x, int y) {
      return new Block(new Position(x, y));
    }

    private BlockGroup CreateBlockGroup(params Block[] blocks) {
      return new BlockGroup(new List<Block>(blocks), movement, merging);
    }
  }
}