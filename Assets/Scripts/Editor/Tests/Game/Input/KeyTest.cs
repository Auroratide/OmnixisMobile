using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.Omnixis.Test.Model {
  using Auroratide.Omnixis.Model;

  public class KeyTest {
    [Test] public void ShouldReturnFalseWhenKeyIsNotPressed() {
      Key key = new Key(() => false);

      Assert.That(key.IsActive(), Is.False);
    }

    [Test] public void ShouldReturnTrueWhenKeyIsPressedForFirstTime() {
      Key key = new Key(() => true);

      Assert.That(key.IsActive(), Is.True);
    }

    [Test] public void ShouldReturnFalseWhenKeyIsHeldLongerForOneFrame() {
      Key key = new Key(() => true);
      key.IsActive();

      Assert.That(key.IsActive(), Is.False);
    }

    [Test] public void ShouldReturnTrueWhenKeyIsPressedThenLetGoThenPressedAgain() {
      bool isPressed = true;
      Key key = new Key(() => isPressed);
      key.IsActive();
      isPressed = false;
      key.IsActive();
      isPressed = true;

      Assert.That(key.IsActive(), Is.True);
    }
  }
}