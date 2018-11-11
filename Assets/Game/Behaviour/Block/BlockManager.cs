using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auroratide.Omnixis.Behaviour {
  using Auroratide.Omnixis.Model;

  [RequireComponent(typeof(InputAxis))]
  public class BlockManager : MonoBehaviour {
    private List<BlockGroup> groups;

    [SerializeField] private Config config;

    public void Awake() {
      groups = new List<BlockGroup>();

      BlockBehaviour blockBehaviour = Instantiate(config.blockTemplate, this.transform);
      List<Block> blocks = new List<Block>();
      blocks.Add(blockBehaviour.GetBlock());
      groups.Add(new BlockGroup(blocks, new AxisMovement(GetComponent<Axis>())));
    }

    public void Update() {
      groups.ForEach(group => group.Update());
    }

    [System.Serializable] public class Config {
      public BlockBehaviour blockTemplate;
    }
  }
}
