using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Cameras.System;
using Code.Gameplay.Features.Hero.System;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Hero
{
    public class HeroFeature : Feature
    {
        public HeroFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<InitializeHeroSystem>());
            Add(systemFactory.Create<SetHeroDirectionByInputSystem>());

            Add(systemFactory.Create<CameraFollowHeroSystem>());

            Add(systemFactory.Create<AnimateHeroMovementSystem>());
            
            Add(systemFactory.Create<HeroDeathSystem>());
      
            Add(systemFactory.Create<FinalizeHeroDeathProcessingSystem>());
        }
    }
}