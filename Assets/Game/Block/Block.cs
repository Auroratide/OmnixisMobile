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
      transform.position = position.ToVector() * config.moveScale;
    }

    private IEnumerator Move() {
      while(true) {
        position = position.Translate(input.Translation());
        yield return null;
      }
    }

    [System.Serializable] public class Config {
      public float moveScale = 0.25f;
    }
  }
}
