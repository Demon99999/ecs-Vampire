using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Effects.System
{
  public class ProcessDamageEffectSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _effects;

    public ProcessDamageEffectSystem(GameContext game)
    {
      _effects = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.DamageEffect,
          GameMatcher.EffectValue,
          GameMatcher.TargetId));
    }

    public void Execute()
    {
      foreach (GameEntity effect in _effects)
      {
        GameEntity target = effect.Target();
        
        Debug.Log(_effects.count);
        
        effect.isProcessed = true;
       
        if (target.isDead)
          continue;
        
        target.ReplaceCurrentHp(target.CurrentHp - effect.EffectValue);

        if(target.hasDamageTakenAnimator)
          target.DamageTakenAnimator.PlayDamageTaken();
      }
    }
  }
}