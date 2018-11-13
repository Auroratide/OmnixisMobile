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
    private Heartbeat heartbeat;

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

      heartbeat = new Heartbeat(config.heartbeat);
    }

    public void Update() {
      core.Update();

      if(heartbeat.Ready())
        groups.ForEach(group => group.Update());
      
      groups.RemoveAll(group => group.IsEmpty());
    }

    [System.Serializable] public class Config {
      public int heartbeat = 60;
    }
  }
}
