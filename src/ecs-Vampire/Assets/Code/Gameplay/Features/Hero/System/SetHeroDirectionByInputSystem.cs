using Entitas;
using NotImplementedException = System.NotImplementedException;

namespace Code.Gameplay.Features.Hero.System
{
    public class SetHeroDirectionByInputSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _heros;
        private IGroup<GameEntity> _inputs;

        public SetHeroDirectionByInputSystem(GameContext gameContext)
        {
            _heros = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.Hero, GameMatcher.MovementAvailable));
            _inputs = gameContext.GetGroup(GameMatcher.Input);
        }
        
        public void Execute()
        {
            foreach (GameEntity input in _inputs)
            foreach (GameEntity hero in _heros)
            {
                hero.isMoving = input.hasAxisInput;

                if (input.hasAxisInput)
                    hero.ReplaceDirection(input.AxisInput.normalized);
            }
            
        }
    }
}