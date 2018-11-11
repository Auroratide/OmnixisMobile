using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auroratide.Omnixis.Behaviour {
  using Auroratide.Omnixis.Model;

  [RequireComponent(typeof(BlockGroupFactory))]
  public class BlockManager : MonoBehaviour {
    private BlockGroupFactory factory;
    private BlockGroup core;
    private List<BlockGroup> groups;
    private int frame;

    [SerializeField] private Config config;

    public void Awake() {
      factory = GetComponent<BlockGroupFactory>();
      groups = new List<BlockGroup>();
      groups.Add(factory.CreateSquare(new Position(0, -7)));
      core = factory.CreateCore();
      frame = 0;
    }

    public void Update() {
      core.Update();
      groups.ForEach(group => {
        if(core.Overlaps(group)) {
          group.Translate(core.GetLastTranslation());
          core.Merge(group);
        }
      });

      if(++frame % config.updateDelay == 0)
        groups.ForEach(group => group.Update());

      groups.ForEach(group => {
        if(core.Overlaps(group)) {
          group.UndoLastMovement();
          core.Merge(group);
        }
      });
    }

    [System.Serializable] public class Config {
      public int updateDelay = 60;
    }
  }
}
