using NUnit.Framework;

namespace Auroratide.Omnixis.Test.Model {
  using Auroratide.Omnixis.Model;

  public class HeartbeatTest {
    [Test] public void ShouldBecomeReadyAfterReadyIsCalledTheGivenNumberOfBeats() {
      Heartbeat heartbeat = new Heartbeat(3);

      Assert.That(heartbeat.Ready(), Is.False);
      Assert.That(heartbeat.Ready(), Is.False);
      Assert.That(heartbeat.Ready(), Is.True);
    }

    [Test] public void ShouldResetAfterEveryTimeTheBeatRateIsReached() {
      Heartbeat heartbeat = new Heartbeat(2);

      Assert.That(heartbeat.Ready(), Is.False);
      Assert.That(heartbeat.Ready(), Is.True);
      Assert.That(heartbeat.Ready(), Is.False);
      Assert.That(heartbeat.Ready(), Is.True);
      Assert.That(heartbeat.Ready(), Is.False);
    }
  }
}