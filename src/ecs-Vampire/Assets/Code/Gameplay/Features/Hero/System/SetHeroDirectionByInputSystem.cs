using Entitas;
using NotImplementedException = System.NotImplementedException;

namespace Code.Gameplay.Features.Hero.System
{
    public class SetHeroDirectionByInputSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _heros;
        private IGroup<InputEntity> _inputs;

        public SetHeroDirectionByInputSystem(GameContext gameContext, InputContext input)
        {
            _heros = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.Hero, GameMatcher.MovementAvailable));
            _inputs = input.GetGroup(InputMatcher.Input);
        }
        
        public void Execute()
        {
            foreach (InputEntity input in _inputs)
            foreach (GameEntity hero in _heros)
            {
                hero.isMoving = input.hasAxisInput;

                if (input.hasAxisInput)
                    hero.ReplaceDirection(input.AxisInput.normalized);
            }
            
        }
    }
}