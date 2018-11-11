using System.Linq;
using System.Collections.Generic;

namespace Auroratide.Omnixis.Model {
  public class CoreBlockGroup : BlockGroup {
    private List<BlockGroup> groups;

    public CoreBlockGroup(List<Block> blocks, Movement movement, List<BlockGroup> groups)
    : base(blocks, movement) {
      this.groups = groups;
    }

    public override void Update(CoreBlockGroup core) {
      Translation translation = movement.Translation();
      Translate(translation);

      groups.ForEach(group => {
        if(core.Overlaps(group)) {
          group.Translate(translation);
          core.Merge(group);
        }
      });
    }
  }
}