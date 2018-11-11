using UnityEngine;

namespace Auroratide.Omnixis.Behaviour {
  using Auroratide.Omnixis.Model;

  public class BlockBehaviour : MonoBehaviour {
    private Position position;
    private Block block;

    [SerializeField] private Config config;

    public void Awake() {
      position = new Position(config.x, config.y);
      block = new Block(position);
    }

    public void Update() {
      transform.position = PositionToVector() * config.moveScale;
    }

    public Block GetBlock() {
      return block;
    }

    private Vector3 PositionToVector() {
      return new Vector3(position.X, position.Y, 0);
    }

    public void Configure(Config config) {
      this.config = config;
    }

    [System.Serializable] public class Config {
      public float moveScale = 0.25f;
      public int x = 0;
      public int y = 0;
    }

  }
}
