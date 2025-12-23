using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Effects.System
{
  public class CleanupProcessedEffects : ICleanupSystem
  {
    private readonly IGroup<GameEntity> _effects;
    private readonly List<GameEntity> _buffer = new List<GameEntity>(32);

    public CleanupProcessedEffects(GameContext game)
    {
      _effects = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Effect,
          GameMatcher.Processed));
    }

    public void Cleanup()
    {
      foreach (GameEntity effect in _effects.GetEntities(_buffer))
      {
        effect.Destroy();
      }
    }
  }
}