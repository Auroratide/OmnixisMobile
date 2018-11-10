using UnityEngine;

namespace Auroratide.Omnixis.Behaviour {
  using Auroratide.Omnixis.Model;

  public class InputAxis : MonoBehaviour, Axis {
    public int Horizontal() {
      return Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));
    }

    public int Vertical() {
      return Mathf.RoundToInt(Input.GetAxisRaw("Vertical"));
    }
  }
}