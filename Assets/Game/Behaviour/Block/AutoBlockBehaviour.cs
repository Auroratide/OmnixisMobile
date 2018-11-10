using UnityEngine;

namespace Auroratide.Omnixis.Behaviour {
  using Auroratide.Omnixis.Model;

  public class AutoBlockBehaviour : MonoBehaviour {
    private Position position;
    private Block block;
    private int frame;

    [SerializeField] private Config config;

    public void Awake() {
      position = new Position(0, 0);
      block = new Block(position, new UniDirectionalMovement(new Translation(0, 1)));
    }

    public void Update() {
      if(++frame % config.framesDelay == 0)
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
      public int framesDelay = 60;
    }
  }
}
