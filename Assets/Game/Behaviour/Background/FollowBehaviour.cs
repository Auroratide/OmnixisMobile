using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auroratide.Omnixis.Behaviour {
  public class FollowBehaviour : MonoBehaviour {
    [SerializeField] private Config config;
    private GameObject follow;

    public void Awake() {
      follow = gameObject;
    }

    public void Update() {
      Vector3 p = follow.transform.position;
      transform.position = new Vector3(p.x - config.offsetX, p.y - config.offsetY, transform.position.z);
    }

    public void Follow(GameObject obj) {
      this.follow = obj;
    }

    [System.Serializable] public class Config {
      public float offsetX = 0.125f;
      public float offsetY = 0.125f;
    }
  }
}