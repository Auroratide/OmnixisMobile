using UnityEngine;

namespace Auroratide.Omnixis.Behaviour {
  using Auroratide.Omnixis.Model;

  public class BlockBehaviour : MonoBehaviour {
    private Block block;

    [SerializeField] private Config config;

    public void Awake() {
      block = new Block(new Position(config.x, config.y));
    }

    public void Update() {
      transform.position = PositionToVector(block.Position);
    }

    public Block GetBlock() {
      return block;
    }

    public BlockBehaviour InstantiateWith(Block block, Transform parent) {
      BlockBehaviour behaviour = Instantiate(this, PositionToVector(block.Position), Quaternion.identity, parent);
      behaviour.block = block;
      return behaviour;
    }

    private Vector3 PositionToVector(Position position) {
      return new Vector3(position.X, position.Y, 0) * config.moveScale;
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
