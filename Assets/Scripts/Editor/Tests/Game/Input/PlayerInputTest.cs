using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using Auroratide.NBehave;
using Auroratide.NBehave.Unity;

namespace Auroratide.Omnixis.Test.Model {
  using Auroratide.Omnixis.Model;

  public class PlayerInputTest {
    private GameObject obj;
    private RawInput input;
    private PlayerInput playerInput;

    [SetUp] public void Init() {
      obj = new GameObject();
      input = obj.AddMockComponent<RawInput>();
      playerInput = obj.AddComponent<PlayerInput>();

      playerInput.Awake();
    }

    [Test] public void ShouldTranslateLeftWhenHorizontalInputIsNegative() {
      When.Called(() => input.Horizontal()).Then.Return(-1.0f).Always();
      Vector3 translation = playerInput.Translation();

      Assert.That(translation.x, Is.EqualTo(-1));
      Assert.That(translation.y, Is.EqualTo(0));
    }

    [Test] public void ShouldTranslateRightWhenHorizontalInputPositive() {
      When.Called(() => input.Horizontal()).Then.Return(1.0f).Always();
      Vector3 translation = playerInput.Translation();

      Assert.That(translation.x, Is.EqualTo(1));
      Assert.That(translation.y, Is.EqualTo(0));
    }

    [Test] public void ShouldTranslateUpWhenVerticalInputIsPositive() {
      When.Called(() => input.Vertical()).Then.Return(1.0f).Always();
      Vector3 translation = playerInput.Translation();

      Assert.That(translation.x, Is.EqualTo(0));
      Assert.That(translation.y, Is.EqualTo(1));
    }

    [Test] public void ShouldTranslateDownWhenVerticalInputIsNegative() {
      When.Called(() => input.Vertical()).Then.Return(-1.0f).Always();
      Vector3 translation = playerInput.Translation();

      Assert.That(translation.x, Is.EqualTo(0));
      Assert.That(translation.y, Is.EqualTo(-1));
    }

    [Test] public void ShouldNotTranslateWhenNoInputIsPressed() {
      When.Called(() => input.Horizontal()).Then.Return(0f).Always();
      When.Called(() => input.Vertical()).Then.Return(0f).Always();

      Vector3 translation = playerInput.Translation();

      Assert.That(translation.x, Is.EqualTo(0));
      Assert.That(translation.y, Is.EqualTo(0));
    }
  }
}