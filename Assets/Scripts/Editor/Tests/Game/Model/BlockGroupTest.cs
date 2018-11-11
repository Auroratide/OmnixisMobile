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
  }
}