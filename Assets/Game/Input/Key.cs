using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auroratide.Omnixis.Model {
  public class Key {
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