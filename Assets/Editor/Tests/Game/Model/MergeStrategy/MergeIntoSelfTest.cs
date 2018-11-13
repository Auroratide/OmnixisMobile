using System.Collections.Generic;
using NUnit.Framework;
using Auroratide.NBehave;

namespace Auroratide.Omnixis.Test.Model {
  using Auroratide.Omnixis.Model;

  public class MergeIntoSelfTest {
    private Position corePosition;
    private Block coreBlock;
    private BlockGroup core;
    private MergeIntoSelf merging;

    private Position groupPosition;
    private Block groupBlock;
    private BlockGroup group;

    [SetUp] public void Init() {
      groupPosition = new Position(0, 0);
      groupBlock = new Block(groupPosition);
      group = new BlockGroup(new List<Block>{ groupBlock }, Mock.Basic<Movement>(), Mock.Basic<MergeStrategy>());

      merging = new MergeIntoSelf(new List<BlockGroup>{ group });
    }

    [Test] public void ShouldNotChangeWhenThereIsNoOverlapBetweenGroups() {
      corePosition = new Position(-1, 0);
      coreBlock = new Block(corePosition);
      core = new BlockGroup(new List<Block>{ coreBlock }, Mock.Basic<Movement>(), merging);

      merging.Merge(core, new Translation(1, 0));

      Assert.That(corePosition, Is.EqualTo(new Position(-1, 0)));
      Assert.That(groupPosition, Is.EqualTo(new Position(0, 0)));
      Assert.That(core.IsEmpty(), Is.False);
      Assert.That(group.IsEmpty(), Is.False);
    }

    [Test] public void ShouldMergeGroupIntoCoreIfItOverlap() {
      corePosition = new Position(0, 0);
      coreBlock = new Block(corePosition);
      core = new BlockGroup(new List<Block>{ coreBlock }, Mock.Basic<Movement>(), merging);

      merging.Merge(core, new Translation(1, 0));

      Assert.That(corePosition, Is.EqualTo(new Position(0, 0)));
      Assert.That(groupPosition, Is.EqualTo(new Position(1, 0)));
      Assert.That(core.IsEmpty(), Is.False);
      Assert.That(group.IsEmpty(), Is.True);
    }
  }
}