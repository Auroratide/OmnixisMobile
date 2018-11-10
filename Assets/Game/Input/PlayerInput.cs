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

    public Vector3 Translation() {
      if(left.IsActive())  return new Vector3(-1, 0, 0);
      if(right.IsActive()) return new Vector3(1, 0, 0);
      if(up.IsActive())    return new Vector3(0, 1, 0);
      if(down.IsActive())  return new Vector3(0, -1, 0);

      return new Vector3(0, 0, 0);
    }
  }
}
