using System.Collections.Generic;
using NUnit.Framework;
using Auroratide.NBehave;

namespace Auroratide.Omnixis.Test.Model {
  using Auroratide.Omnixis.Model;

  public class MergeIntoCoreTest {
    private Position corePosition;
    private Block coreBlock;
    private BlockGroup core;
    private MergeIntoCore merging;

    private Position groupPosition;
    private Block groupBlock;
    private BlockGroup group;

    [SetUp] public void Init() {
      corePosition = new Position(0, 0);
      coreBlock = new Block(corePosition);
      core = new BlockGroup(new List<Block>{ coreBlock }, Mock.Basic<Movement>(), Mock.Basic<MergeStrategy>());

      merging = new MergeIntoCore(core);
    }

    [Test] public void ShouldNotChangeWhenThereIsNoOverlapBetweenGroups() {
      groupPosition = new Position(-1, 0);
      groupBlock = new Block(groupPosition);
      group = new BlockGroup(new List<Block>{ groupBlock }, Mock.Basic<Movement>(), merging);

      merging.Merge(group, new Translation(1, 0));

      Assert.That(corePosition, Is.EqualTo(new Position(0, 0)));
      Assert.That(groupPosition, Is.EqualTo(new Position(-1, 0)));
      Assert.That(core.IsEmpty(), Is.False);
      Assert.That(group.IsEmpty(), Is.False);
    }

    [Test] public void ShouldMergeGroupIntoCoreIfItOverlap() {
      groupPosition = new Position(0, 0);
      groupBlock = new Block(groupPosition);
      group = new BlockGroup(new List<Block>{ groupBlock }, Mock.Basic<Movement>(), merging);

      merging.Merge(group, new Translation(1, 0));

      Assert.That(corePosition, Is.EqualTo(new Position(0, 0)));
      Assert.That(groupPosition, Is.EqualTo(new Position(-1, 0)));
      Assert.That(core.IsEmpty(), Is.False);
      Assert.That(group.IsEmpty(), Is.True);
    }
  }
}