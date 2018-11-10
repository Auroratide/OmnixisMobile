using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auroratide.Omnixis.Model {
  public class RawInput : MonoBehaviour {
    public virtual float Horizontal() {
      return Input.GetAxisRaw("Horizontal");
    }

    public virtual float Vertical() {
      return Input.GetAxisRaw("Vertical");
    }
  }
}
