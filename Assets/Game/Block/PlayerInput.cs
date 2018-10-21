using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auroratide.Omnixis.Model {
  public class PlayerInput : MonoBehaviour {
    public bool Left() {
      return Input.GetAxisRaw("Horizontal") < 0;
    }

    public bool Right() {
      return Input.GetAxisRaw("Horizontal") > 0;
    }

    public bool Up() {
      return Input.GetAxisRaw("Vertical") > 0;
    }

    public bool Down() {
      return Input.GetAxisRaw("Vertical") < 0;
    }
  }
}
