using Code.Gameplay.Features.TargetCollection.System;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.TargetCollection
{
  public sealed class CollectTargetsFeature : Feature
  {
    public CollectTargetsFeature(ISystemFactory systems)
    {
      
      Add(systems.Create<CollectTargetsIntervalSystem>());
      Add(systems.Create<TargetSystem>());
      
      //Add(systems.Create<CastForTargetsNoLimitSystem>());
      //Add(systems.Create<CastForTargetsWithLimitSystem>());
      //Add(systems.Create<MarkReachedSystem>());
      
      //Add(systems.Create<CleanupTargetBuffersSystem>());
    }
  }
}