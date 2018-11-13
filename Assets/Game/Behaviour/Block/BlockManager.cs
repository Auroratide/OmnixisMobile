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
      core = factory.CreateCore(groups);

      groups.Add(factory.CreateSquare(new Position(0, -7), core));
      frame = 0;
    }

    public void Update() {
      core.Update();

      if(++frame % config.updateDelay == 0)
        groups.ForEach(group => group.Update());
    }

    [System.Serializable] public class Config {
      public int updateDelay = 60;
    }
  }
}
