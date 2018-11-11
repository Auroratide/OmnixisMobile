using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auroratide.Omnixis.Behaviour {
  using Auroratide.Omnixis.Model;

  [RequireComponent(typeof(BlockGroupFactory))]
  public class BlockManager : MonoBehaviour {
    private BlockGroupFactory factory;
    private List<BlockGroup> groups;

    public void Awake() {
      factory = GetComponent<BlockGroupFactory>();
      groups = new List<BlockGroup>();
      groups.Add(factory.CreateCore());
    }

    public void Update() {
      groups.ForEach(group => group.Update());
    }
  }
}
