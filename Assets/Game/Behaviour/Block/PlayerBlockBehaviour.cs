using UnityEngine;

namespace Auroratide.Omnixis.Behaviour {
  using Auroratide.Omnixis.Model;

  [RequireComponent(typeof(InputAxis))]
  public class PlayerBlockBehaviour : MonoBehaviour {
    private Position position;
    private Block block;

    [SerializeField] private Config config;

    public void Awake() {
      Axis axis = GetComponent<Axis>();
      position = new Position(0, 0);
      block = new Block(position, new AxisMovement(axis));
    }

    public void Update() {
      block.Update();

      transform.position = PositionToVector() * config.moveScale;
    }

    private Vector3 PositionToVector() {
      return new Vector3(position.X, position.Y, 0);
    }

    public void Configure(Config config) {
      this.config = config;
    }

    [System.Serializable] public class Config {
      public float moveScale = 0.25f;
    }
  }
}
