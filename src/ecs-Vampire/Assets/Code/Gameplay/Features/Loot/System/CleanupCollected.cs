using Entitas;

namespace Code.Gameplay.Features.Loot.System
{
  public class CleanupCollected : ICleanupSystem
  {
    private readonly IGroup<GameEntity> _collected;

    public CleanupCollected(GameContext contextParameter)
    {
      _collected = contextParameter.GetGroup(GameMatcher.Collected);
    }

    public void Cleanup()
    {
      foreach (GameEntity collected in _collected)
      {
        collected.isDestructed = true;
      }
    }
  }
}