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
      blocks.Add(CreateBlock(new Position(-1, -1), Color.White).GetBlock());
      blocks.Add(CreateBlock(new Position(-1, 0), Color.White).GetBlock());
      blocks.Add(CreateBlock(new Position(-1, 1), Color.White).GetBlock());
      blocks.Add(CreateBlock(new Position(0, -1), Color.White).GetBlock());
      blocks.Add(CreateBlock(new Position(0, 0), Color.White).GetBlock());
      blocks.Add(CreateBlock(new Position(0, 1), Color.White).GetBlock());
      blocks.Add(CreateBlock(new Position(1, -1), Color.White).GetBlock());
      blocks.Add(CreateBlock(new Position(1, 0), Color.White).GetBlock());
      blocks.Add(CreateBlock(new Position(1, 1), Color.White).GetBlock());

      return new BlockGroup(blocks, new AxisMovement(GetComponent<Axis>()));
    }

    public BlockGroup CreateSquare(Position p) {
      List<Block> blocks = new List<Block>();
      blocks.Add(CreateBlock(p, Color.Yellow).GetBlock());
      blocks.Add(CreateBlock(p.Offset(1, 0), Color.Yellow).GetBlock());
      blocks.Add(CreateBlock(p.Offset(0, 1), Color.Yellow).GetBlock());
      blocks.Add(CreateBlock(p.Offset(1, 1), Color.Yellow).GetBlock());

      return new BlockGroup(blocks, new UniDirectionalMovement(new Translation(0, 1)));
    }

    private enum Color {
      White, Yellow
    }

    private BlockBehaviour CreateBlock(Position position, Color color) {
      BlockBehaviour template;
      switch(color) {
        case Color.White: template = this.config.white; break;
        case Color.Yellow: template = this.config.yellow; break;
        default: template = this.config.white; break;
      }

      BlockBehaviour.Config config = new BlockBehaviour.Config();
      config.x = position.X;
      config.y = position.Y;

      template.Configure(config);

      return Instantiate(template, this.transform);
    }

    [System.Serializable] public class Config {
      public BlockBehaviour white;
      public BlockBehaviour yellow;
    }
  }
}
