using Code.Gameplay.Features.Enemy.System;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Enemy
{
  public sealed class EnemyFeature : Feature
  {
    public EnemyFeature(ISystemFactory systems)
    {
      Add(systems.Create<InitializeSpawnTimerSystem>());
      
      Add(systems.Create<EnemySpawnSystem>());
      
      Add(systems.Create<EnemyChaseHeroSystem>());
      Add(systems.Create<EnemyDeathSystem>());
      Add(systems.Create<EnemyDropLootSystem>());
      
      Add(systems.Create<FinalizeEnemyDeathProcessingSystem>());
    }
  }
}