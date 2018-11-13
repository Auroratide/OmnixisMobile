namespace Auroratide.Omnixis.Model {
  public class MergeIntoCore : MergeStrategy {
    private BlockGroup core;
    
    public MergeIntoCore(BlockGroup core) {
      this.core = core;
    }

    public void Merge(BlockGroup group, Translation lastTranslation) {
      if(group.Overlaps(core)) {
        group.Translate(lastTranslation.Negate());
        core.Merge(group);
      }
    }
  }
}