using UnityEngine;

namespace Auroratide.Omnixis.Behaviour {
  using Auroratide.Omnixis.Model;

  public class AutoBlockBehaviour : BlockBehaviour<AutoBlockBehaviourConfig> {
    private int frame;

    public override Movement MovementStrategy() {
      return new UniDirectionalMovement(new Translation(0, 1));
    }

    public override void UpdateBlock() {
      if(++frame % config.framesDelay == 0)
        block.Update();
    }
  }

  [System.Serializable] public class AutoBlockBehaviourConfig : BlockBehaviourConfig {
    public int framesDelay = 60;
  }
}
