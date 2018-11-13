using NUnit.Framework;

namespace Auroratide.Omnixis.Test.Model {
  using Auroratide.Omnixis.Model;

  public class ControlledBoolTest {
    [Test] public void ShouldReturnFalseWhenInputIsFalse() {
      ControlledBool b = new ControlledBool(() => false);

      Assert.That(b.IsActive(), Is.False);
    }

    [Test] public void ShouldReturnTrueWhenInputIsTrue() {
      ControlledBool b = new ControlledBool(() => true);

      Assert.That(b.IsActive(), Is.True);
    }

    [Test] public void ShouldReturnFalseAfterTrueInputHasAlreadyBeenChecked() {
      ControlledBool b = new ControlledBool(() => true);

      Assert.That(b.IsActive(), Is.True);
      Assert.That(b.IsActive(), Is.False);
    }

    [Test] public void ShouldReturnTrueAfterInputHasBeenResetToFalseForAtLeastOneCheck() {
      bool input = true;
      ControlledBool b = new ControlledBool(() => input);

      Assert.That(b.IsActive(), Is.True);

      input = false;
      Assert.That(b.IsActive(), Is.False);

      input = true;
      Assert.That(b.IsActive(), Is.True);
    }
  }
}