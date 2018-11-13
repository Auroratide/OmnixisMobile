using System.Collections.Generic;

namespace Auroratide.Omnixis.Model {
  public class MergeIntoSelf : MergeStrategy {
    private List<BlockGroup> groups;
    
    public MergeIntoSelf(List<BlockGroup> groups) {
      this.groups = groups;
    }

    public void Merge(BlockGroup group, Translation lastTranslation) {
      groups.ForEach(g => {
        if(group.Overlaps(g)) {
          g.Translate(lastTranslation);
          group.Merge(g);
        }
      });
    }
  }
}