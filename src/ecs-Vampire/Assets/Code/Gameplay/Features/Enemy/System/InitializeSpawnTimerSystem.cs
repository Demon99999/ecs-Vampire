using Code.Common.Entity;
using Code.Gameplay.Common;
using Entitas;

namespace Code.Gameplay.Features.Enemy.System
{
  public class InitializeSpawnTimerSystem : IInitializeSystem
  {
    public void Initialize()
    {
      CreateEntity.Empty()
        .AddSpawnTimer(GameplayConstants.EnemySpawnTimer);
    }
  }
}