using Entitas;

namespace Code.Gameplay.Features.EffectApplication.System
{
    public class DamageSystem : IExecuteSystem
    {
        private GameContext _game;
        private IGroup<GameEntity> _damegeDilers;


        public DamageSystem(GameContext game)
        {
            _game = game;

            _damegeDilers = _game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TargetBuffer, 
                    GameMatcher.Damage));
            
        }
        
        public void Execute()
        {
            foreach (var diler in _damegeDilers)
            foreach (int targetId in diler.TargetBuffer)
            {
                GameEntity entity = _game.GetEntityWithId(targetId);
                
                if (entity.hasCurrentHp)
                {
                    entity.ReplaceCurrentHp(entity.CurrentHp - diler.Damage);
                }
                
                if(entity.hasDamageTakenAnimator)
                    entity.DamageTakenAnimator.PlayDamageTaken();
            }
        }
    }
}