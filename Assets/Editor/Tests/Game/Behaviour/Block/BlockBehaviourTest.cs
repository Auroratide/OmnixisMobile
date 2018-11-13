using UnityEngine;
using NUnit.Framework;

namespace Auroratide.Omnixis.Test.Behaviour {
  using Auroratide.Omnixis.Behaviour;
  using Auroratide.Omnixis.Model;

  public class BlockBehaviourTest {
    private GameObject obj;
    private BlockBehaviour.Config config;
    private BlockBehaviour behaviour;

    [SetUp] public void Init() {
      obj = new GameObject();

      config = new BlockBehaviour.Config();
      config.moveScale = 1.0f;

      behaviour = obj.AddComponent<BlockBehaviour>();
      behaviour.Configure(config);

      behaviour.Awake();
    }

    [Test] public void ShouldUpdateTransformWhenBlockMoves() {
      Block block = behaviour.GetBlock();

      block.Move(new Translation(1, 0));
      behaviour.Update();
      Assert.That(behaviour.transform.position.x, Is.EqualTo(1.0f));
      Assert.That(behaviour.transform.position.y, Is.EqualTo(0));

      block.Move(new Translation(0, -1));
      behaviour.Update();
      Assert.That(behaviour.transform.position.x, Is.EqualTo(1.0f));
      Assert.That(behaviour.transform.position.y, Is.EqualTo(-1.0f));
    }
  }
}