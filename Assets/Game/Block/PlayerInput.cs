using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auroratide.Omnixis.Model {
  public class PlayerInput : MonoBehaviour {
    private Key left;
    private Key right;
    private Key up;
    private Key down;

    public void Awake() {
      left = new Key(() => Input.GetAxisRaw("Horizontal") < 0);
      right = new Key(() => Input.GetAxisRaw("Horizontal") > 0);
      up = new Key(() => Input.GetAxisRaw("Vertical") > 0);
      down = new Key(() => Input.GetAxisRaw("Vertical") < 0);
    }

    public bool Left() {
      return left.IsActive();
    }

    public bool Right() {
      return right.IsActive();
    }

    public bool Up() {
      return up.IsActive();
    }

    public bool Down() {
      return down.IsActive();
    }

    private class Key {
      private Func<bool> IsPressed;
      private bool pressed;

      public Key(Func<bool> IsPressed) {
        this.IsPressed = IsPressed;
        this.pressed = false;
      }

      public bool IsActive() {
        if(pressed) {
          pressed = IsPressed();
          return false;
        } else {
          pressed = IsPressed();
          return pressed;
        }
      }
    }
  }
}
