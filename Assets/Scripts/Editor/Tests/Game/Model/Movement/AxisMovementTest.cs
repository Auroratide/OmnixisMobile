using NUnit.Framework;
using Auroratide.NBehave;

namespace Auroratide.Omnixis.Test.Model {
  using Auroratide.Omnixis.Model;

  public class AxisMovementTest {
    private Axis axis;
    private AxisMovement movement;

    [SetUp] public void Init() {
      axis = Mock.Basic<Axis>();
      movement = new AxisMovement(axis);
    }

    [Test] public void ShouldTranslateLeftWhenHorizontalIsNegative() {
      When.Called(() => axis.Horizontal()).Then.Return(-1).Always();
      Translation translation = movement.Translation();

      Assert.That(translation.X, Is.EqualTo(-1));
      Assert.That(translation.Y, Is.EqualTo(0));
    }

    [Test] public void ShouldTranslateRightWhenHorizontalIsPositive() {
      When.Called(() => axis.Horizontal()).Then.Return(1).Always();
      Translation translation = movement.Translation();

      Assert.That(translation.X, Is.EqualTo(1));
      Assert.That(translation.Y, Is.EqualTo(0));
    }

    [Test] public void ShouldTranslateDownWhenHorizontalIsNegative() {
      When.Called(() => axis.Vertical()).Then.Return(-1).Always();
      Translation translation = movement.Translation();

      Assert.That(translation.X, Is.EqualTo(0));
      Assert.That(translation.Y, Is.EqualTo(-1));
    }

    [Test] public void ShouldTranslateUpWhenHorizontalIsPositive() {
      When.Called(() => axis.Vertical()).Then.Return(1).Always();
      Translation translation = movement.Translation();

      Assert.That(translation.X, Is.EqualTo(0));
      Assert.That(translation.Y, Is.EqualTo(1));
    }

    [Test] public void ShouldNotTranslateWhenTheInputIsNeutral() {
      When.Called(() => axis.Horizontal()).Then.Return(0).Always();
      When.Called(() => axis.Vertical()).Then.Return(0).Always();
      Translation translation = movement.Translation();

      Assert.That(translation.X, Is.EqualTo(0));
      Assert.That(translation.Y, Is.EqualTo(0));
    }
  }
}