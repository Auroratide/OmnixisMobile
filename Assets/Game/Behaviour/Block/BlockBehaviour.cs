using UnityEngine;

namespace Auroratide.Omnixis.Behaviour {
  using Auroratide.Omnixis.Model;

  public abstract class BlockBehaviour<T> : MonoBehaviour where T : BlockBehaviourConfig {
    protected Position position;
    protected Block block;

    [SerializeField] protected T config;

    public abstract Movement MovementStrategy();
    public abstract void UpdateBlock();

    public void Awake() {
      position = new Position(0, 0);
      block = new Block(position, MovementStrategy());
    }

    public void Update() {
      UpdateBlock();

      transform.position = PositionToVector() * config.moveScale;
    }

    private Vector3 PositionToVector() {
      return new Vector3(position.X, position.Y, 0);
    }

    public void Configure(T config) {
      this.config = config;
    }
  }

  [System.Serializable] public class BlockBehaviourConfig {
      public float moveScale = 0.25f;
    }
}
