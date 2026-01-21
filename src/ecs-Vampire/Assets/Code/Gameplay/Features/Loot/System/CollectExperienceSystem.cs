using Code.Gameplay.Features.LevelUp.Services;
using Entitas;

namespace Code.Gameplay.Features.Loot.System
{
  public class CollectExperienceSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _collected;
    private readonly IGroup<GameEntity> _heroes;
    private readonly ILevelUpService _levelUpService;

    public CollectExperienceSystem(GameContext game, ILevelUpService levelUpService)
    {
      _levelUpService = levelUpService;
      
      _collected = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Collected,
          GameMatcher.Experience));
      
      _heroes = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Hero, 
          GameMatcher.WorldPosition));

    }

    public void Execute()
    {
      foreach (GameEntity colect in _collected)
      foreach (GameEntity hero in _heroes)
      {
        _levelUpService.AddExperience(colect.Experience);
        hero.ReplaceExperience(_levelUpService.CurrentExperience);
      }
    }
  }
}