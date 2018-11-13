using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auroratide.Omnixis.Behaviour {
  using Auroratide.Omnixis.Model;

  [RequireComponent(typeof(InputAxis))]
  [RequireComponent(typeof(BlockInstantiator))]
  public class BlockManager : MonoBehaviour {
    private BlockInstantiator instantiator;
    private BlockGroup core;
    private List<BlockGroup> groups;
    private int frame;

    [SerializeField] private Config config;

    public void Awake() {
      instantiator = GetComponent<BlockInstantiator>();
      groups = new List<BlockGroup>();
      core = new CoreGroupBuilder(new Position(0, 0), GetComponent<Axis>(), groups)
        .ForEachBlock(block => instantiator.InstantiateBlock(block))
        .Build();

      groups.Add(new SquareBuilder(new Position(0, -7), core)
        .ForEachBlock(block => instantiator.InstantiateBlock(block))
        .Build());

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
