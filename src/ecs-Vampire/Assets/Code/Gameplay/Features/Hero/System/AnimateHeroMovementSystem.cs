using Entitas;
using NotImplementedException = System.NotImplementedException;

namespace Code.Gameplay.Features.Hero.System
{
    public class AnimateHeroMovementSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _heroes;

        public AnimateHeroMovementSystem(GameContext gameContext)
        {
            _heroes = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Hero,
                    GameMatcher.HeroAnimator));
        }
        
        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            {
                if(hero.isMoving)
                    hero.HeroAnimator.PlayMove();
                else
                    hero.HeroAnimator.PlayIdle();
            }
        }
    }
}