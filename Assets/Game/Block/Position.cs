using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auroratide.Omnixis.Model {
  public struct Position {
    private int x;
    private int y;

    public Position(int x, int y) {
      this.x = x;
      this.y = y;
    }

    public Position Translate(Vector3 translation) {
      return new Position(
        this.x + Mathf.RoundToInt(translation.x),
        this.y + Mathf.RoundToInt(translation.y)
      );
    }

    public Vector3 ToVector() {
      return new Vector3(this.x, this.y, 0);
    }
  }
}
