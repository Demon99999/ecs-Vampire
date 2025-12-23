using Code.Gameplay.Features.EffectApplication.System;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.EffectApplication
{
    public class EffectApplicationFeature : Feature
    {
        public EffectApplicationFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<ApplyEffectsOnTargetsSystem>());
            Add(systemFactory.Create<ApplyStatusesOnTargetsSystem>());
            //Add(systemFactory.Create<DamageSystem>());
        }
    }
}