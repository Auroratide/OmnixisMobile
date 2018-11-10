using System;
namespace Auroratide.Omnixis.Model {
  public class ControlledBool {
    private Func<bool> Bool;
    private bool wasActiveLast;

    public ControlledBool(Func<bool> Bool) {
      this.Bool = Bool;
      this.wasActiveLast = false;
    }

    public bool IsActive() {
      if(wasActiveLast) {
        wasActiveLast = Bool();
        return false;
      } else {
        wasActiveLast = Bool();
        return wasActiveLast;
      }
    }
  }
}