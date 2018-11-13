namespace Auroratide.Omnixis.Model {
  public class Heartbeat {
    private int rate;
    private int beat;

    public Heartbeat(int rate) {
      this.rate = rate;
      this.beat = 0;
    }

    public bool Ready() {
      return ++beat % rate == 0;
    }
  }
}