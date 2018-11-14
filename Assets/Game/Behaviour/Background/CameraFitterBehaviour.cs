using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auroratide.Omnixis.Behaviour {

  // https://answers.unity.com/questions/1231701/fitting-bounds-into-orthographic-2d-camera.html
  [RequireComponent(typeof(Camera))]
  public class CameraFitterBehaviour : MonoBehaviour {

    [SerializeField] private Config config;
    private Camera camera;
    private Bounds bounds;

    public void Start() {
      camera = GetComponent<Camera>();
      bounds = config.fitTo.bounds;
    }

    public void LateUpdate() {
      float screenRatio = (float)Screen.width / (float)Screen.height;
      float targetRatio = bounds.size.x / bounds.size.y;

      if(screenRatio > targetRatio) {
        camera.orthographicSize = bounds.size.y / 2;
      } else {
        float difference = targetRatio / screenRatio;
        camera.orthographicSize = bounds.size.y / 2 * difference;
      }

      transform.position = new Vector3(bounds.center.x, bounds.center.y, transform.position.z);
    }

    [System.Serializable] public class Config {
      public Renderer fitTo;
    }
  }
}
