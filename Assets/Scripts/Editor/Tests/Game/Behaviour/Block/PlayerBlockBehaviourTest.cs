using UnityEngine;
using NUnit.Framework;
using Auroratide.NBehave;
using Auroratide.NBehave.Unity;

namespace Auroratide.Omnixis.Test.Behaviour {
  using Auroratide.Omnixis.Behaviour;
  using Auroratide.Omnixis.Model;

  public class PlayerBlockBehaviourTest {
    private GameObject obj;
    private Axis axis;
    private PlayerBlockBehaviour behaviour;

    private BlockBehaviourConfig config;

    [SetUp] public void Init() {
      obj = new GameObject();
      axis = obj.AddMockComponent<Axis>();
      behaviour = obj.AddComponent<PlayerBlockBehaviour>();

      config = new BlockBehaviourConfig();
      config.moveScale = 1.0f;

      behaviour.Configure(config);
      
      obj.AllowRunInEditMode();
      obj.SendMessage("Awake");
    }

    [Test] public void ShouldMoveAsTheAxisChanges() {
      When.Called(() => axis.Horizontal())
        .Then.Return(1).Then.Return(1)
        .Then.Return(0).Then.Return(0);
      When.Called(() => axis.Vertical())
        .Then.Return(0).Then.Return(-1);

      Update();

      Assert.That(obj.transform.position.x, Is.EqualTo(1));
      Assert.That(obj.transform.position.y, Is.EqualTo(0));

      Update();

      Assert.That(obj.transform.position.x, Is.EqualTo(1));
      Assert.That(obj.transform.position.y, Is.EqualTo(-1));
    }

    private void Update() {
      obj.SendMessage("Update");
    }
  }
}