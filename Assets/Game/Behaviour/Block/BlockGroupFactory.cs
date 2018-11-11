using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auroratide.Omnixis.Behaviour {
  using Auroratide.Omnixis.Model;

  [RequireComponent(typeof(InputAxis))]
  public class BlockGroupFactory : MonoBehaviour {

    [SerializeField] private Config config;

    public BlockGroup CreateCore() {
      List<Block> blocks = new List<Block>();
      blocks.Add(CreateBlock(new Position(-1, -1)).GetBlock());
      blocks.Add(CreateBlock(new Position(-1, 0)).GetBlock());
      blocks.Add(CreateBlock(new Position(-1, 1)).GetBlock());
      blocks.Add(CreateBlock(new Position(0, -1)).GetBlock());
      blocks.Add(CreateBlock(new Position(0, 0)).GetBlock());
      blocks.Add(CreateBlock(new Position(0, 1)).GetBlock());
      blocks.Add(CreateBlock(new Position(1, -1)).GetBlock());
      blocks.Add(CreateBlock(new Position(1, 0)).GetBlock());
      blocks.Add(CreateBlock(new Position(1, 1)).GetBlock());

      return new BlockGroup(blocks, new AxisMovement(GetComponent<Axis>()));
    }

    private BlockBehaviour CreateBlock(Position position) {
      BlockBehaviour.Config config = new BlockBehaviour.Config();
      config.x = position.X;
      config.y = position.Y;

      this.config.white.Configure(config);

      return Instantiate(this.config.white, this.transform);
    }

    [System.Serializable] public class Config {
      public BlockBehaviour white;
    }
  }
}
