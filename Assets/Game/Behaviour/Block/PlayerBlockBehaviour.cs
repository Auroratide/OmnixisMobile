using UnityEngine;

namespace Auroratide.Omnixis.Behaviour {
  using Auroratide.Omnixis.Model;

  [RequireComponent(typeof(InputAxis))]
  public class PlayerBlockBehaviour : BlockBehaviour<BlockBehaviourConfig> {
    public override Movement MovementStrategy() {
      return new AxisMovement(GetComponent<Axis>());
    }

    public override void UpdateBlock() {
      block.Update();
    }
  }
}
