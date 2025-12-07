using Code.Gameplay.Features.Damage.System;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Damage
{
    public class DamageFeature : Feature
    {
        public DamageFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<AplayDamageTargetSystem>());
        }
    }
}