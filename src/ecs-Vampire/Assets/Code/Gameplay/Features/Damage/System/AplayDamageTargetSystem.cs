using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Damage.System
{
    public class AplayDamageTargetSystem : IExecuteSystem
    {
        private GameContext _gameContext;
        private readonly IGroup<GameEntity> _damageDilers;

        public AplayDamageTargetSystem(GameContext gameContext)
        {
            _gameContext = gameContext;
            
            _damageDilers = gameContext.GetGroup(GameMatcher
                .AllOf(GameMatcher.TargetBuffer,
                    GameMatcher.Damage));
        }
        
        public void Execute()
        {
            foreach (GameEntity diler in  _damageDilers)
            foreach (int targetId in diler.TargetBuffer)
            {
                Debug.Log(targetId + "ffffffffffffffffffff");
                GameEntity target = _gameContext.GetEntityWithId(targetId);

                if (_gameContext == null)
                {
                    Debug.Log("GameContex=0");
                }
                
                if (target == null)
                {
                    Debug.Log("0");
                }
                
                if (target.hasCurrentHp)
                {
                    target.ReplaceCurrentHp(target.CurrentHp - diler.Damage);

                    if (target.hasDamageTakenAnimator)
                    {
                        target.DamageTakenAnimator.PlayDamageTaken();
                    }
                }
            }
            
        }
    }
}
