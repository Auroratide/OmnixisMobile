using NUnit.Framework;

namespace Auroratide.Omnixis.Test.Model {
  using Auroratide.Omnixis.Model;

  public class PositionTest {
    [Test] public void ShouldReturnTrueWhenPositionsAreTheSame() {
      Position position = new Position(1, 2);

      Assert.That(position, Is.EqualTo(new Position(1, 2)));
    }

    [Test] public void ShouldReturnFalseWhenPositionsAreDifferent() {
      Position position = new Position(1, 2);

      Assert.That(position, Is.Not.EqualTo(new Position(2, 1)));
    }
  }
}