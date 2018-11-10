using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auroratide.Omnixis.Model {
  public class Block {
    private Position position;
    private Movement movement;
    
    public Block(Position position, Movement movement) {
      this.position = position;
      this.movement = movement;
    }

    public void Update() {
      position.Translate(movement.Translation());
    }
  }
}