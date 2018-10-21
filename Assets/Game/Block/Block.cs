using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auroratide.Omnixis.Model {
  [RequireComponent(typeof(PlayerInput))]
  public class Block : MonoBehaviour {
    private Position position;
    private PlayerInput input;

    public void Awake() {
      this.input = GetComponent<PlayerInput>();
    }

    public void Start() {
      StartCoroutine(Move());
    }

    public void Update() {
      transform.position = new Vector3(position.x, position.y, 0);
    }

    private IEnumerator Move() {
      while(true) {
        if(input.Left())  position.x -= 1;
        if(input.Right()) position.x += 1;
        if(input.Up())    position.y += 1;
        if(input.Down())  position.y -= 1;

        yield return null;
      }
    }
  }
}
