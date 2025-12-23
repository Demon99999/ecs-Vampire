using Code.Common.Destruct.System;
using Code.Infrastructure.Systems;

namespace Code.Common.Destruct
{
    public class ProcessDestructedFeature : Feature
    {
        public ProcessDestructedFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<SelfDestructTimerSystem>());
            Add(systemFactory.Create<CleanupMetaDestructedSystem>());
            Add(systemFactory.Create<CleanupGameDestructedViewSystem>());
            Add(systemFactory.Create<CleanupGameDestructedSystem>());
        }
    }
}