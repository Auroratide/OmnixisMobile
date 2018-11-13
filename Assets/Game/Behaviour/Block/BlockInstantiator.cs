using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auroratide.Omnixis.Behaviour {
  using Auroratide.Omnixis.Model;

  public class BlockInstantiator : MonoBehaviour {

    [SerializeField] private Config config;

    public BlockBehaviour InstantiateBlock(Block block) {
      return config.white.InstantiateWith(block, this.transform);
    }

    [System.Serializable] public class Config {
      public BlockBehaviour white;
      public BlockBehaviour yellow;
    }
  }
}
