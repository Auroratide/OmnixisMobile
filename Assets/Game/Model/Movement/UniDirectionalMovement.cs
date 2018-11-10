namespace Auroratide.Omnixis.Model {
  public class UniDirectionalMovement : Movement {
    private Translation translation;

    public UniDirectionalMovement(Translation translation) {
      this.translation = translation;
    }

    public Translation Translation() {
      return translation;
    }
  }
}