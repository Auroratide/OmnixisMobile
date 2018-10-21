using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auroratide.Omnixis.Model {
  [RequireComponent(typeof(PlayerInput))]
  public class Block : MonoBehaviour {
    private Position position;
    private PlayerInput input;

    [SerializeField] private Config config;

    public void Awake() {
      this.input = GetComponent<PlayerInput>();
    }

    public void Start() {
      StartCoroutine(Move());
    }

    public void Update() {
      transform.position = new Vector3(position.x * config.moveScale, position.y * config.moveScale, 0);
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

    [System.Serializable] public class Config {
      public float moveScale = 0.25f;
    }
  }
}
