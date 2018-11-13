namespace Auroratide.Omnixis.Model {
  public interface MergeStrategy {
    void Merge(BlockGroup group, Translation lastTranslation);
  }
}